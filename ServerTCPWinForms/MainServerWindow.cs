using Microsoft.VisualBasic.ApplicationServices;
using System.ComponentModel;
using System.Net;
using System.Text;
using System.Windows.Forms;


namespace ServerTCPWinForms
{
    public partial class MainServerWindow : Form
    {

        private Server? server = null;
        bool Started = false;
        public MainServerWindow()
        {
            InitializeComponent();
            dataGridView.DataSource = Database.list;
            UserExiting += WriteOnDisconnected;
            dataGridView.CellClick += new DataGridViewCellEventHandler(dataGridView_CellClick);
        }

        public event Action<string> UserExiting;
        private void OnUserExiting(string user)
        {
            UserExiting.Invoke(user);
        }

        private void checkBoxKey_CheckedChanged(object sender, EventArgs e)
        {
            textBoxKey.UseSystemPasswordChar = (checkBoxKey.Checked) ? false : true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (!Started)
            {
                buttonStop.Text = "Stop";
                textBoxAddress.Enabled = false;
                textBoxPort.Enabled = false;
                textBoxUsername.Enabled = false;

                Started = true;
                server = new Server(textBoxAddress.Text, int.Parse(textBoxPort.Text), textBoxUsername.Text, textBoxKey.Text);

                AddHandlersToServer();
                server.StartListening();
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

        private void AddToList(int Id, ClientsInformation info)
        {
            Database.semaphore.WaitAsync();
            Invoke(() => Database.list.Add(info));
            Database.semaphore.Release();
        }

        private void ErrorAndSimpleMEssagesWriting(string mesg)
        {
            //MakeConnectingPossobleIfError();
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
            if (server != null)
            {
                server.SendToAll(msg, -1);
            }
            else
            {
                WriteToLog(msg.Time, msg.Sender, msg.Text);
            }
        }


        public async void DisconnectUser(int Id)
        {
            await Database.semaphore.WaitAsync();
            for (int i = 0; i < Database.list.Count; i++)
            {
                if (Database.list[i].ID == Id)
                {
                    var inf = Database.list[i];
                    OnUserExiting(inf.Name);
                    inf.GetClient().EndOfWork();
                    Invoke(() => Database.list.RemoveAt(i));
                    break;
                }
            }
            Database.semaphore.Release();
        }

        public async void DisconnectAll()
        {
            await Database.semaphore.WaitAsync();
            while (Database.list.Count > 0)
            {
                var inf = Database.list[0];
                string usr = inf.Name;
                OnUserExiting(usr);
                inf.GetClient().EndOfWork();
                Database.list.RemoveAt(0);

            }
            Database.list.Clear();
            Database.semaphore.Release();
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
            WriteToLog(DateTime.Now, "", $"{server!.UserName} has stopped");
            server!.tokenS.Cancel();
        }

        private void AddHandlersToServer()
        {
            server.Listening += WritingLogOnListening;
            server.DisconnectedFrom += DisconnectUser;
            server.Added += AddToList;
            server.BadHostname += ErrorAndSimpleMEssagesWriting;
            server.WaitingOnSocket += StartListeningLog;
            server.UserConnected += ErrorAndSimpleMEssagesWriting;
            server.BadAuthorisation += ErrorAndSimpleMEssagesWriting;
            server.CheckingAnAuthorisation += ErrorAndSimpleMEssagesWriting;
            server.MessageReceived += WriteToLog;
            server.DisconnectAll += DisconnectAll;
            server.SocketErrorWhileListenerStarting += ErrorAndSimpleMEssagesWriting;
            server.SocketErrorWhileListenerStarting += MakeConnectingPossible; // After error ocurs we want to make it possible again to connect
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