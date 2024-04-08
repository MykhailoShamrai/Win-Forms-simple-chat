using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatWinForms
{
    public class Client
    {
        Thread checkConnectionThread;
        private StreamReader? StreamReader;
        private StreamWriter? StreamWriter;

        private TcpClient? tcpClient;
        private string? _userName;
        public string? UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        private string? _password;
        public string? Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string? _address = null;
        private string? _port = null;

        public Client()
        {
            _userName = null;
            _password = null;
            checkConnectionThread = new Thread(ReadOnThread);
        }
        
        public void setClientsParameters(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }
        /// <summary>
        /// Event on connecting with server
        /// </summary>
        public event Action? Connected;
        public void OnConnected()
        {
            Connected!.Invoke();
        }

        /// <summary>
        /// Event on disconnection with server
        /// </summary>
        public event Action? Disconnected;

        public void OnDisconnected()
        {
            Disconnected!.Invoke();
        }

        public event Action<string>? BadHostname;

        public void OnBadHostname(string mesg)
        {
            BadHostname!.Invoke(mesg); 
        }

        public event Action ConnectionEstablished;
        public void OnConnectionEstablished()
        {
            ConnectionEstablished.Invoke();
        }
        public event Action<string>? ErronOnConnectionEstablishing;
        public void OnErrorOnConnectionEstablishing(string msg)
        {
            ErronOnConnectionEstablishing?.Invoke(msg);
        }

        //public event Action<string> 
       

        private async Task<int> TryToConnect(IPAddress address, int port)
        {
            try
            {
                await tcpClient!.ConnectAsync(address, port);
            }
            catch (SocketException ex)
            {
                _address = null;
                _port = null;
                tcpClient = null;
                OnErrorOnConnectionEstablishing(ex.Message);
                return -1;
            }
            OnConnectionEstablished();
            return 0;
        }
        
            

        /// <summary>
        /// One solid function for connection and authorizing routine
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        public async void ConnectToServer (string address, string port)
        {
            IPAddress addr;
            try
            {
                addr = Dns.GetHostAddresses(address).FirstOrDefault()!;
            }
            catch (SocketException ex)
            {
                OnBadHostname(ex.Message);
                return;
            }

            tcpClient = new TcpClient();
            // Trying to connect
            int res = await TryToConnect(addr, int.Parse(port));
            if (res == -1)
            {
                return;
            }

            _address = address;
            _port = port;

            StreamWriter = new StreamWriter(tcpClient.GetStream());
            StreamWriter.AutoFlush = true;
            StreamReader = new StreamReader(tcpClient.GetStream());


            // Sending authorization
            // Must be async
            AskAuthorization();

            // Waiting for a response (must be async)
            if (await CheckAuthorization())
            {
                OnConnected();
                checkConnectionThread.Start();
                
                return;
            }
            else
            {
                MessageBox.Show("Unable to authorize");
                EndOfWork();
                return;
            }

            // Good connection
        }

        private async void SendRequest(string message)
        {
           if (StreamWriter != null)
            {
                try
                {
                    await StreamWriter.WriteLineAsync(message);
                }
                catch (SocketException ex)
                {
                    OnErrorOnConnectionEstablishing(ex.Message);
                    return;
                }
           }
           else
           {
                return;
           }
        }


        private async Task<string?> HaveAnAnswer()
        {
            if (StreamReader != null)
            {
                string? res = await StreamReader.ReadLineAsync()!;
                if (res == null)
                {
                    OnDisconnected();
                }
                return res;
            }
            else
            {
                return null;
            }
        }

        private void AskAuthorization()
        {
            ChatWinForms.Messages.Authorization authorization = new ChatWinForms.Messages.Authorization(UserName!, Password!);
            string mes = JsonSerializer.Serialize(authorization);
            SendRequest(mes);
        }

        private async Task<bool> CheckAuthorization()
        {
            string? autStr = await HaveAnAnswer();
            if (autStr != null)
            {
                ChatWinForms.Messages.Message msg = JsonSerializer.Deserialize<ChatWinForms.Messages.Message>(autStr)!;
                return (msg.Text == ChatWinForms.Messages.Message.Authorized);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method for clearing streams, tcp clients and all variables;
        /// </summary>
        private void EndOfWork()
        {
            if (StreamWriter != null)
            {
                StreamWriter.Close();
            }
            if (StreamReader != null)
            {
                StreamReader.Close();
            }
            if (tcpClient != null)
            {
                tcpClient.Close();
            }
            //OnConnectionFormDisPose();
        }

        //private void CheckConnection()
        //{
        //    while (true)
        //    {
        //        if (!tcpClient!.Connected)
        //        {
        //            OnDisconnected();
        //            return;
        //        }
        //    }
        //}

        private void ReadOnThread()
        {
            bool disconnected = false;

            while (!disconnected)
            {
                string str = StreamReader!.ReadLine()!;
                if (str == null)
                    disconnected = true;   
            }
            OnDisconnected();
            EndOfWork();
        }
    }
}
