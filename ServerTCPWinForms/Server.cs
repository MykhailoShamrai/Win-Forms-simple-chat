using ChatWinForms;
using System;
using System.Collections.Generic;
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

        private IPAddress? TryToParseIP()
        {
            IPAddress? addr;
            try
            {
                addr = Dns.GetHostAddresses(Address, AddressFamily.InterNetwork).FirstOrDefault()!;
            }
            catch (Exception ex)
            {
                return null;
            }
            return addr;
        }

        public async void StartListening()
        {
            IPAddress? addr;
            if ((addr = TryToParseIP()) == null)
            {
                /// must be error 
                return;
            }
            TcpListener listener = new TcpListener(addr, Port);

            while (true)
            {
                listener.Start();
                // listening
                Client client = new Client();
                OnListening();
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
            ChatWinForms.Messages.Authorization auth = JsonSerializer.Deserialize<ChatWinForms.Messages.Authorization>(line)!;
            // checking

            // ansering

            // adding
        }
    }
}
