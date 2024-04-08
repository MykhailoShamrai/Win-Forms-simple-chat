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
            checkConnectionThread.IsBackground = true;
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
            ConnectionEstablished?.Invoke();
        }
        public event Action<string>? ErronOnConnectionEstablishing;
        public void OnErrorOnConnectionEstablishing(string msg)
        {
            ErronOnConnectionEstablishing?.Invoke(msg);
        }

        public event Action SendedAuthorisation;
        public void OnSendedAuthorisation()
        {
            SendedAuthorisation?.Invoke();
        }

        public event Action<string>? ErrorOnSendingAuthorisation;
        public void OnErrorOnSendingAuthorisation(string msg)
        {
            ErrorOnSendingAuthorisation?.Invoke(msg);
        }

        public event Action CheckingAuthorisation;
        public void OnCheckingAuthorisation()
        {
            CheckingAuthorisation?.Invoke();
        }

        public event Action AcceptedAuthorisation;
        public void OnAcceptedAuthorisation()
        {
            AcceptedAuthorisation?.Invoke();
        }

        public event Action<string>? RejectedAuthorisation;
        public void OnRejectedAuthorisation(string msg)
        {
            RejectedAuthorisation?.Invoke(msg);
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
                addr = Dns.GetHostAddresses(address).LastOrDefault()!;
            }
            catch (Exception ex)
            {
                OnBadHostname(ex.Message);
                return;
            }

            tcpClient = new TcpClient();
            // Trying to connect
            int res = await TryToConnect(addr, int.Parse(port));
            if (res == -1)
            {
                EndOfWork();
                return;
            }

            _address = address;
            _port = port;

            StreamWriter = new StreamWriter(tcpClient.GetStream());
            StreamWriter.AutoFlush = true;
            StreamReader = new StreamReader(tcpClient.GetStream());


            // Sending authorization
            int askres = await AskAuthorization();
            if (askres == -1)
            {
                EndOfWork();
                return;
            }
            // completed 

            // Waiting for a response (must be async)
            if (await CheckAuthorization())
            {
                OnConnected();
                //return;
            }
            else
            {
                OnRejectedAuthorisation("Authorisation was rejected");
                EndOfWork();
                return;
            }

            // Good connection
            OnConnected();
            checkConnectionThread.Start();

        }

        private async Task<int> SendRequest(string message)
        {
           if (StreamWriter != null)
            {
                try
                {
                    await StreamWriter.WriteLineAsync(message);
                }
                catch (SocketException ex)
                {
                    OnErrorOnSendingAuthorisation(ex.Message);
                    return -1;
                }
                return 0;
           }
           else
           {
                return -1;
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

        private async Task<int> AskAuthorization()
        {
            ChatWinForms.Messages.Authorization authorization = new ChatWinForms.Messages.Authorization(UserName!, Password!);
            string mes = JsonSerializer.Serialize(authorization);
            int res = await SendRequest(mes);
            {
                if (res == -1)
                {
                    return -1;
                }
            }
            OnSendedAuthorisation();
            return 0;
        }

        private async Task<bool> CheckAuthorization()
        {
            OnCheckingAuthorisation();
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
            _address = null;
            _port = null;
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
            
        }

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
