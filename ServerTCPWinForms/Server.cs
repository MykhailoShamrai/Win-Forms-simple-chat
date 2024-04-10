﻿using ChatWinForms;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServerTCPWinForms
{
    internal class Server
    {
        public bool isWorking = false;
        // lock needed
        int id = 1;
        public string Address {  get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Server(string address, int port, string username, string key)
        {
            Address = address;
            Port = port;
            UserName = username;
            Password = key;
        }

        public event Action Listening;
        private void OnListening()
        {
            Listening.Invoke();
        }

        public event Action<int, ClientsInformation> Added;
        private void OnAdded(int Id, ClientsInformation info)
        {
            Added.Invoke(Id, info);
        }

        public event Action<string> BadHostname;
        private void OnBadHostname(string mesg)
        {
            BadHostname.Invoke(mesg);
        }

        public event Action<IPAddress, int> WaitingOnSocket;
        private void OnWaitingInSocket(IPAddress addr, int port)
        {
            WaitingOnSocket.Invoke(addr, port);
        }

        public event Action<string> CheckingAnAuthorisation;
        private void OnCheckingAnAuthorisation(string mesg)
        {
            CheckingAnAuthorisation.Invoke(mesg);
        }

        public event Action<string> BadAuthorisation;
        private void OnBadAuthorisation(string mesg)
        {
            BadAuthorisation.Invoke(mesg);
        }

        public event Action<string> UserConnected;
        private void OnUserConnected(string mesg)
        {
            BadAuthorisation.Invoke(mesg);
        }
        public event Action<DateTime, string, string> MessageReceived;
        private void OnMessageReceived(DateTime timestamp, string user, string message)
        {
            MessageReceived.Invoke(timestamp, user, message);
        }
        private IPAddress? TryToParseIP()
        {
            IPAddress? addr;
            try
            {
                addr = Dns.GetHostAddresses(Address, AddressFamily.InterNetwork).FirstOrDefault()!;
            }
            catch (SocketException ex)
            {
                OnBadHostname(ex.Message);
                return null;
            }
            catch (ArgumentException ex)
            {
                OnBadHostname("Error resolving address: " + ex.Message);
                return null;
            }
            return addr;
        }

        public async void StartListening()
        {
            IPAddress? addr;
            if ((addr = TryToParseIP()) == null)
            {
                return;
            }

            TcpListener listener;
            try
            {
                listener = new TcpListener(addr, Port);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                OnBadHostname(ex.Message);
                return;
            }
            OnListening();
            OnWaitingInSocket(addr, Port);
            isWorking = true;
            while (isWorking)
            {
                listener.Start();
                // listening
                Client client = new Client();
                TcpClient tmpClient = await listener.AcceptTcpClientAsync();
                client.SetClientsTcpClient(tmpClient);
                await Task.Factory.StartNew(() => { TryToAddNewClient(client); });
            }
        }

        private async void TryToAddNewClient(Client client)
        {
            // waiting authorisation
            string? line = await client.HaveAnAnswer();
            if (line == null)
            {
                return;
            }
            OnCheckingAnAuthorisation("New client... Authorising");
            ChatWinForms.Messages.Authorization auth = JsonSerializer.Deserialize<ChatWinForms.Messages.Authorization>(line)!;
            if (auth.Key != Password)
            {
                OnBadAuthorisation("Client failed to authorize");
                ChatWinForms.Messages.Message msg = new ChatWinForms.Messages.Message(UserName, ChatWinForms.Messages.Message.Unauthorized, DateTime.Now);
                await client.SendRequest(JsonSerializer.Serialize(msg));
                client.EndOfWork();
                return;
            }
            else 
            {
                ChatWinForms.Messages.Message msg = new ChatWinForms.Messages.Message(UserName, ChatWinForms.Messages.Message.Authorized, DateTime.Now);
                int i = await client.SendRequest(JsonSerializer.Serialize(msg));
                if (i == -1)
                {
                    // error
                    client.EndOfWork();
                    return;
                }
            }
            OnUserConnected($"{auth.Sender} has connected");
            /// list must be locked, it's multuthread
            client.SetClientsParameters(auth.Sender, Password);
            ClientsInformation info = new ClientsInformation(id, auth.Sender, client);
            // adding
            OnAdded(id, info);
            // Adding handler for event, when message is recieved
            client.MessageReceivedFrom += SendToAll;
            client.StartCheckingIncoming(id++);
        }

        public async void SendToAll(ChatWinForms.Messages.Message message, int Id)
        {
            await Database.semaphore.WaitAsync();
            string user = message.Sender;
            if (Id != -1)
            {
                foreach (var info in Database.list)
                {
                    if (info.ID == Id)
                    {
                        user = info.Name;
                    }
                }
            }
            else
            {
                user = UserName;
            }
            ChatWinForms.Messages.Message usrmsg = new ChatWinForms.Messages.Message(user, message.Text, message.Time);
            OnMessageReceived(usrmsg.Time, user, usrmsg.Text);
            string toSend = JsonSerializer.Serialize(usrmsg);

            foreach (var info in Database.list)
            {
                if (info.ID != Id)
                {
                    Client tmp = info.GetClient();
                    await info.GetClient().SendRequest(toSend);
                }
            }
            Database.semaphore.Release();
        }
    }
}