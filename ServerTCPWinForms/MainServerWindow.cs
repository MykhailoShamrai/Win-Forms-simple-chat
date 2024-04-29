using System.Net;
using System.Text;


namespace ServerTCPWinForms
{
    public partial class MainServerWindow : Form
    {
        private Server? _server = null;
        bool Started = false;
        public MainServerWindow()
        {
            InitializeComponent();
            dataGridView.DataSource = Database.List;
            UserExiting += WriteOnDisconnected;
            dataGridView.CellClick += new DataGridViewCellEventHandler(dataGridView_CellClick!);
        }

        public event Action<string> UserExiting;
        private void OnUserExiting(string user)
        {
            UserExiting.Invoke(user);
        }

        private void checkBoxKey_CheckedChanged(object sender, EventArgs e)
        {
            textBoxKey.UseSystemPasswordChar = checkBoxKey.Checked ? false : true;
        }

        /// <summary>
        /// Method, that is called on Stop button clicked. 
        /// </summary>
        private async void buttonStop_Click(object sender, EventArgs e)
        {
            if (!Started)
            {
                buttonStop.Text = "Stop";
                textBoxAddress.Enabled = false;
                textBoxPort.Enabled = false;
                textBoxUsername.Enabled = false;

                Started = true;
                // Creating new server instance.
                _server = new Server(textBoxAddress.Text, int.Parse(textBoxPort.Text), textBoxUsername.Text, textBoxKey.Text);

                AddHandlersToServer();
                await _server.StartListening();
            }
            else
            {
                MakeConnectingPossible();
            }
        }

        private void WritingLogOnListening()
        {
            WriteToLog(DateTime.Now, "", "Listening for incoming connections...");
        }

        /// <summary>
        /// Method that writes a log message to textBox.
        /// </summary>
        /// <param name="time">Time of writing a log.</param>
        /// <param name="user">Name of a user.</param>
        /// <param name="message">Text of a message.</param>
        private void WriteToLog(DateTime time, string user, string message)
        {
            user = (user == "") ? "" : user + ": ";
            string mesg = $"{time.ToString("HH:mm")} | {user}{message}";
            StringBuilder sb = new StringBuilder();
            Invoke(() => { sb.Append(richTextBoxLog.Text); });
            sb.AppendLine(mesg);
            Invoke(() => { richTextBoxLog.Text = sb.ToString(); });
            Invoke(() =>
            {
                richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
                richTextBoxLog.ScrollToCaret();
            });
        }

        /// <summary>
        /// Adding new client to a list of connected clients.
        /// </summary>
        /// <param name="Id">ID of a client</param>
        /// <param name="info">Client with additional information</param>
        private void AddToList(int Id, ClientsInformation info)
        {
            Database.Semaphore.WaitAsync();
            Invoke(() => Database.List.Add(info));
            Database.Semaphore.Release();
        }

        private void ErrorAndSimpleMEssagesWriting(string mesg)
        {
            WriteToLog(DateTime.Now, "", mesg);
        }

        private void StartListeningLog(IPAddress addr, int port)
        {
            WriteToLog(DateTime.Now, "", $"IP: {addr}, Port: {port}");
        }

        private void WriteOnDisconnected(string user)
        {
            WriteToLog(DateTime.Now, "", $"{user} has disconnected");
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string text = sendTextBox.Text;
            sendTextBox.Text = "";
            ChatWinForms.Messages.Message msg = new ChatWinForms.Messages.Message(textBoxUsername.Text, text, DateTime.Now);
            if (_server != null)
            {
                _server.SendToAll(msg, -1);
            }
            else
            {
                WriteToLog(msg.Time, msg.Sender, msg.Text);
            }
        }

        /// <summary>
        /// Method for disconnecting user from server.
        /// </summary>
        /// <param name="Id">Id of a client that should be disconnected.</param>
        public async void DisconnectUser(int Id)
        {
            await Database.Semaphore.WaitAsync();
            // Finding in "Database" a client with proper id and cancelling from a list.
            for (int i = 0; i < Database.List.Count; i++)
            {
                if (Database.List[i].ID == Id)
                {
                    var inf = Database.List[i];
                    OnUserExiting(inf.Name);
                    inf.GetClient().EndOfWork();
                    Invoke(() => Database.List.RemoveAt(i));
                    break;
                }
            }
            Database.Semaphore.Release();
        }

        public async void DisconnectAll()
        {
            await Database.Semaphore.WaitAsync();
            while (Database.List.Count > 0)
            {
                var inf = Database.List[0];
                string usr = inf.Name;
                OnUserExiting(usr);
                inf.GetClient().EndOfWork();
                Database.List.RemoveAt(0);
            }
            Database.List.Clear();
            Database.Semaphore.Release();
        }

        /// <summary>
        /// string is unused beacaue of event handling
        /// </summary>
        /// <param name="str">Unused parametr</param>
        private void MakeConnectingPossible(string str = "")
        {
            textBoxAddress.Enabled = true;
            textBoxPort.Enabled = true;
            textBoxUsername.Enabled = true;
            buttonStop.Text = "Start";
            Started = false;
            WriteToLog(DateTime.Now, "", $"{_server!.UserName} has stopped");
            _server!.tokenS.Cancel();
        }

        /// <summary>
        /// Subscribing to all required events.
        /// </summary>
        private void AddHandlersToServer()
        {
            _server!.Listening += WritingLogOnListening;
            _server!.DisconnectedFrom += DisconnectUser;
            _server!.Added += AddToList;
            _server!.BadHostname += ErrorAndSimpleMEssagesWriting;
            _server!.WaitingOnSocket += StartListeningLog;
            _server!.UserConnected += ErrorAndSimpleMEssagesWriting;
            _server!.BadAuthorisation += ErrorAndSimpleMEssagesWriting;
            _server!.CheckingAnAuthorisation += ErrorAndSimpleMEssagesWriting;
            _server!.MessageReceived += WriteToLog;
            _server!.DisconnectAll += DisconnectAll;
            _server!.SocketErrorWhileListenerStarting += ErrorAndSimpleMEssagesWriting;
            _server!.SocketErrorWhileListenerStarting += MakeConnectingPossible; // After error occurs we want to make it possible again to connect
        }

        private void buttonDisconnectAll_Click(object sender, EventArgs e)
        {
            DisconnectAll();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            richTextBoxLog.Text = "";
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells. 
            var a = e;
            if (e.RowIndex < 0 || e.ColumnIndex !=
                dataGridView.Columns["colDosconnect"].Index) return;

            // Retrieve the task ID.
            int b = (int)dataGridView[dataGridView.Columns["colID"].Index, e.RowIndex].Value;

            DisconnectUser(b);
        }

        private void sendTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendButton_Click(sender, e);
            }   
        }
    }
}