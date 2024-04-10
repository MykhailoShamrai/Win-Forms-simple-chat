using ChatWinForms;
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

            ///////
            TcpListener listener = new TcpListener(addr, Port);
            OnListening();
            OnWaitingInSocket(addr, Port);
            while (true)
            {
                listener.Start();
                // listening
                Client client = new Client();
                TcpClient tmpClient = await listener.AcceptTcpClientAsync();
                client.SetClientsTcpClient(tmpClient);

        ;
                await Task.Factory.StartNew(() => { TryToAddNewClient(client); });
                // authorising



                // authorisation checked


                // adding to list
            }
        }

        private async void TryToAddNewClient(Client client)
        {
            // waiting authorisation
            string? line = await client.HaveAnAnswer();
            if (line == null)
            {
                // error on closed
                return;
            }
            // checking
            // ansering
            ChatWinForms.Messages.Authorization auth = JsonSerializer.Deserialize<ChatWinForms.Messages.Authorization>(line)!;
            if (auth.Key != Password)
            {
                ///
                ChatWinForms.Messages.Message msg = new ChatWinForms.Messages.Message(UserName, ChatWinForms.Messages.Message.Unauthorized, DateTime.Now);
                int i = await client.SendRequest(JsonSerializer.Serialize(msg));
                client.EndOfWork();
                return;
            }
            else 
            {
                /// sending good authorisation 
                ChatWinForms.Messages.Message msg = new ChatWinForms.Messages.Message(UserName, ChatWinForms.Messages.Message.Authorized, DateTime.Now);
                int i = await client.SendRequest(JsonSerializer.Serialize(msg));
                if (i == -1)
                {
                    // error
                    client.EndOfWork();
                    return;
                }
            }

            /// list must be locked, it's multuthread
            client.SetClientsParameters(auth.Sender, Password);
            ClientsInformation info = new ClientsInformation(id, auth.Sender, client);

            OnAdded(id, info);
            client.MessageReceivedFrom += SendToAll;
            client.StartCheckingIncoming(id++);
            // adding
        }

        private async void SendToAll(ChatWinForms.Messages.Message message, int Id)
        {
            foreach (var info in Database.list)
            {
                if (info.ID != Id)
                {
                    Client tmp = info.GetClient();
                    await info.GetClient().SendRequest(JsonSerializer.Serialize(message));
                }
            }
        }
    }
}
