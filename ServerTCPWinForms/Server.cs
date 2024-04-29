using ChatWinForms;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;

namespace ServerTCPWinForms
{
    internal class Server
    {
        public CancellationTokenSource tokenS = new CancellationTokenSource();
        public static readonly object idLock = new object();
        // id for newly added clients. May be shared between threads, than must be with lock statement
        int id = 1;
        public string Address {  get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        private TcpListener? listener = null;

        public Server(string address, int port, string username, string key)
        {
            Address = address;
            Port = port;
            UserName = username;
            Password = key;
        }

        /// <summary>
        /// Event for listening on TcpListener.
        /// </summary>
        public event Action? Listening;
        private void OnListening()
        {
            Listening?.Invoke();
        }

        /// <summary>
        /// Event when new client is ready to be added to list.
        /// </summary>
        public event Action<int, ClientsInformation>? Added;
        private void OnAdded(int Id, ClientsInformation info)
        {
            Added?.Invoke(Id, info);
        }
        
        /// <summary>
        /// Event on bad name of hostname.
        /// </summary>
        public event Action<string>? BadHostname;
        private void OnBadHostname(string mesg)
        {
            BadHostname?.Invoke(mesg);
        }

        public event Action<IPAddress, int>? WaitingOnSocket;
        private void OnWaitingInSocket(IPAddress addr, int port)
        {
            WaitingOnSocket?.Invoke(addr, port);
        }

        /// <summary>
        /// Event on checkin an authorisation from data.
        /// </summary>
        public event Action<string>? CheckingAnAuthorisation;
        private void OnCheckingAnAuthorisation(string mesg)
        {
            CheckingAnAuthorisation?.Invoke(mesg);
        }

        /// <summary>
        /// Event that is invoked if authorisation data are bad.
        /// </summary>
        public event Action<string>? BadAuthorisation;
        private void OnBadAuthorisation(string mesg)
        {
            BadAuthorisation?.Invoke(mesg);
        }

        /// <summary>
        /// Event on connected user.
        /// </summary>
        public event Action<string>? UserConnected;
        private void OnUserConnected(string mesg)
        {
            BadAuthorisation?.Invoke(mesg);
        }   

        /// <summary>
        /// Event on received message.
        /// </summary>
        public event Action<DateTime, string, string>? MessageReceived;
        private void OnMessageReceived(DateTime timestamp, string user, string message)
        {
            MessageReceived?.Invoke(timestamp, user, message);
        }

        /// <summary>
        /// Event for disconnected from specifeied client.
        /// </summary>
        public event Action<int>? DisconnectedFrom;
        private void OnDisconnectedFrom(int Id)
        {
            DisconnectedFrom?.Invoke(Id);
        }

        /// <summary>
        /// Event, that is invoked when server need to disconnect all users.
        /// </summary>
        public event Action? DisconnectAll;
        private void OnDisconnectAll()
        {
            DisconnectAll?.Invoke();
        }

        public event Action<string>? SocketErrorWhileListenerStarting;
        private void OnSocketError(string msg)
        {
            SocketErrorWhileListenerStarting?.Invoke(msg);
        }

        /// <summary>
        /// Method that parses address from field of a class.
        /// </summary>
        /// <returns>Returns IPAddress address if parsing was successful. Otherwise null is returned.</returns>
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

        /// <summary>
        /// Async method for listening on TcpListener for new clients connections. After connection establishing, client is added to a list of clients.
        /// </summary>
        /// <returns></returns>
        public async Task StartListening()
        {
            IPAddress? addr;
            if ((addr = TryToParseIP()) == null)
            {
                return;
            }
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
            while (true)
            {
                try
                {
                    listener.Start();
                }
                catch (SocketException ex)
                {
                    EndOfWork();
                    OnSocketError(ex.Message);
                    return;
                }

                // Listening.
                Client client = new Client();
                var token = tokenS.Token;
                TcpClient tmpClient;
                try
                {
                    tmpClient = await listener.AcceptTcpClientAsync(token);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                client.SetClientsTcpClient(tmpClient);
                await Task.Factory.StartNew(() => { TryToAddNewClient(client); });
            }
            EndOfWork();
        }

        private async void TryToAddNewClient(Client client)
        {
            // waiting authorisation
            string? line = await client.HaveAnAnswer();
            if (line == null)
            {
                EndOfWork();
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
                    EndOfWork();
                    return;
                }
            }
            OnUserConnected($"{auth.Sender} has connected");
            client.SetClientsParameters(auth.Sender, Password);
            lock (idLock)
            {
                ClientsInformation info = new ClientsInformation(id, auth.Sender, client);
                // Adding new client to list.
                OnAdded(id, info);
                // Adding handler for event, when message is recieved
                client.MessageReceivedFrom += SendToAll;
                client.DisconnectedFromServer += DisconnectUser;
                client.StartCheckingIncoming(id);
                id = (id + 1) % int.MaxValue;
            }
        }

        /// <summary>
        /// Method that sends a message to all connectes clients.
        /// </summary>
        /// <param name="message">Message to be send</param>
        /// <param name="Id">Id, from whom message was received</param>
        public async void SendToAll(ChatWinForms.Messages.Message message, int Id)
        {
            await Database.Semaphore.WaitAsync();
            string user = message.Sender;
            if (Id != -1)
            {
                foreach (var info in Database.List)
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

            foreach (var info in Database.List)
            {
                if (info.ID != Id)
                {
                    Client tmp = info.GetClient();
                    await info.GetClient().SendRequest(toSend);
                }
            }
            Database.Semaphore.Release();
        }

        public void DisconnectUser(int Id)
        {
            OnDisconnectedFrom(Id);
        }

        private void EndOfWork()
        {
            if (listener != null)
            {
                listener.Stop();
            }
            OnDisconnectAll();
        }
    }
}
