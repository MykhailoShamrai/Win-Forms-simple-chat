using System.ComponentModel;
using System.Net;
using System.Text;


namespace ServerTCPWinForms
{
    public partial class MainServerWindow : Form
    {

        private Server server;
        //public BindingList<ClientsInformation> list;
        public MainServerWindow()
        {
            InitializeComponent();
            //list = new BindingList<ClientsInformation>();
            //list.Add(new ClientsInformation(1, "user"));
            dataGridView.DataSource = Database.list;
        }

        private void checkBoxKey_CheckedChanged(object sender, EventArgs e)
        {
            textBoxKey.UseSystemPasswordChar = (checkBoxKey.Checked) ? false : true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            server = new Server(textBoxAddress.Text, int.Parse(textBoxPort.Text), textBoxUsername.Text, textBoxKey.Text);

            server.Listening += WritingLogOnListening;
            server.Added += AddToList;
            server.BadHostname += ErrorAndSimpleMEssagesWriting;
            server.WaitingOnSocket += StartListeningLog;
            server.UserConnected += ErrorAndSimpleMEssagesWriting;
            server.BadAuthorisation += ErrorAndSimpleMEssagesWriting;
            server.CheckingAnAuthorisation += ErrorAndSimpleMEssagesWriting;
            server.MessageReceived += WriteToLog;
            server.StartListening();
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
        }

        private void AddToList(int Id, ClientsInformation info)
        {
            Database.semaphore.WaitAsync();
            Invoke(() => Database.list.Add(info));
            Database.semaphore.Release();
        }

        private void ErrorAndSimpleMEssagesWriting(string mesg)
        {
            WriteToLog(DateTime.Now, "", mesg);
        }

        private void StartListeningLog(IPAddress addr, int port)
        {
            WriteToLog(DateTime.Now, "", $"IP: {addr}, Port: {port}");
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
    }
}
