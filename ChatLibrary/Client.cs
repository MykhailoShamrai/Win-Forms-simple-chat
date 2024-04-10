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
        public bool IsConnected { get; set; }
        private Thread? checkConnectionThread;
        private StreamReader? StreamReader;
        private StreamWriter? StreamWriter;

        public TcpClient? tcpClient { get; set; }
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
            IsConnected = false;
            _userName = null;
            _password = null;
        }
        
        public void SetClientsTcpClient(TcpClient client)
        {
            tcpClient = client;
            StreamReader = new StreamReader(client.GetStream());
            StreamWriter = new StreamWriter(client.GetStream());
            StreamWriter.AutoFlush = true;
        }
        public void SetClientsParameters(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        /// <summary>
        /// Event on connecting with server
        /// </summary>
        public event Action? Connected;
        private void OnConnected()
        {
            Connected?.Invoke();
        }

        /// <summary>
        /// Event on disconnection with server
        /// </summary>
        public event Action? Disconnected;

        private void OnDisconnected()
        {
            Disconnected?.Invoke();
        }

        public event Action<int>? DisconnectedFromServer;
        private void OnDisconnectedFromServer(int Id)
        {
            DisconnectedFromServer?.Invoke(Id);
        }

        /// <summary>
        /// Event on bad hostname
        /// </summary>
        public event Action<string>? BadHostname;

        private void OnBadHostname(string mesg)
        {
            BadHostname?.Invoke(mesg); 
        }

        /// <summary>
        /// Action while trying to establish connection
        /// </summary>
        public event Action ConnectionEstablishing;
        private void OnConnectionEstablished()
        {
            ConnectionEstablishing?.Invoke();
        }

        /// <summary>
        /// Action for error while trying to establish connection
        /// </summary>
        public event Action<string>? ErronOnConnectionEstablishing;
        private void OnErrorOnConnectionEstablishing(string msg)
        {
            ErronOnConnectionEstablishing?.Invoke(msg);
        }

        /// <summary>
        /// Action while sanding an authorisation data
        /// </summary>
        public event Action SendedAuthorisation;
        private void OnSendedAuthorisation()
        {
            SendedAuthorisation?.Invoke();
        }

        /// <summary>
        /// Action on error ocured while sending authorisation data
        /// </summary>
        public event Action<string>? ErrorOnSendingAuthorisation;
        private void OnErrorOnSendingAuthorisation(string msg)
        {
            ErrorOnSendingAuthorisation?.Invoke(msg);
        }

        /// <summary>
        /// Action on checking an authorisation
        /// </summary>
        public event Action CheckingAuthorisation;
        private void OnCheckingAuthorisation()
        {
            CheckingAuthorisation?.Invoke();
        }

        /// <summary>
        /// 
        /// </summary>
        public event Action AcceptedAuthorisation;
        private void OnAcceptedAuthorisation()
        {
            AcceptedAuthorisation?.Invoke();
        }

        /// <summary>
        /// Action on rejected authorisation
        /// </summary>
        public event Action<string>? RejectedAuthorisation;
        private void OnRejectedAuthorisation(string msg)
        {
            RejectedAuthorisation?.Invoke(msg);
        }

        public event Action<ChatWinForms.Messages.Message> MessageReceived;
        private void OnMessageReceived(ChatWinForms.Messages.Message msg)
        {
            MessageReceived?.Invoke(msg);
        }

        public event Action<ChatWinForms.Messages.Message, int> MessageReceivedFrom;
        private void OnMessageReceivedFrom(ChatWinForms.Messages.Message msg, int Id)
        {
            MessageReceivedFrom?.Invoke(msg, Id);
        }


        /// <summary>
        /// Asynchronous method for trying to establish connection between tcpClient and server.
        /// </summary>
        /// <param name="address">IPAddress of address where connection is required</param>
        /// <param name="port">Port for connection</param>
        /// <returns>-1 if error occurs, 0 if succeed</returns>
        private async Task<int> TryToConnect(IPAddress address, int port)
        {
            OnConnectionEstablished();
            try
            {
                await tcpClient!.ConnectAsync(address, port);
            }
            catch (SocketException ex)
            {
                OnErrorOnConnectionEstablishing(ex.Message);
                return -1;
            }
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
                addr = Dns.GetHostAddresses(address, AddressFamily.InterNetwork).FirstOrDefault()!;
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
                OnAcceptedAuthorisation();
            }
            else
            {
                OnRejectedAuthorisation("Authorisation was rejected");
                EndOfWork();
                return;
            }

            // Good connection
            OnConnected();
            StartCheckingIncoming();
        }

        public async Task<int> SendRequest(string message)
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
                catch (IOException) // On closed stream
                {
                    return -1;
                }
                return 0;
           }
           else
           {
                return -1;
           }
        }


        /// <summary>
        /// Function for waiting until message comes
        /// </summary>
        /// <returns>null if disconnected.</returns>
        public async Task<string?> HaveAnAnswer()
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
        public void EndOfWork()
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

        public void StartCheckingIncoming()
        {
            checkConnectionThread = new Thread(ReadOnThreadClient);
            checkConnectionThread.IsBackground = true;
            checkConnectionThread.Start();
        }

        public void StartCheckingIncoming(int Id)
        {
            checkConnectionThread = new Thread(() => ReadOnThreadClientInServer(Id));
            checkConnectionThread.IsBackground = true;
            checkConnectionThread.Start();
        }

         void ReadOnThreadClient()
        {
            string? str = null;

            while (true)
            {
                try
                {
                    str = StreamReader!.ReadLine()!;
                }
                catch (IOException)
                {
                    Disconnect();
                    return;
                }
                if (str == null)
                {
                    break;
                }
                OnMessageReceived(JsonSerializer.Deserialize<ChatWinForms.Messages.Message>(str!)!);
            }
            Disconnect();
        }

        void ReadOnThreadClientInServer(int Id)
        {
            string? str = null;

            while (true)
            {
                try
                {
                    str = StreamReader!.ReadLine()!;
                }
                catch (IOException)
                {
                    Disconnect();
                    return;
                }
                if (str == null)
                {
                    break;
                }
                OnMessageReceivedFrom(JsonSerializer.Deserialize<ChatWinForms.Messages.Message>(str!)!, Id);
            }
            DisconnectFromServer(Id);
        }


        /// <summary>
        /// Disconnecting routine, Closing streams, closing a client; Also OnDisconnected event is invoked
        /// </summary>
        public void Disconnect()
        {
            EndOfWork();
            OnDisconnected();
        }

        public void DisconnectFromServer(int Id)
        {
            EndOfWork();
            OnDisconnectedFromServer(Id);
        }
    }
}
