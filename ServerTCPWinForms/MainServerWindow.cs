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
            server.BadHostname += ErrorWriting;
            server.WaitingOnSocket += StartListeningLog;
            server.StartListening();
        }

        private void WritingLogOnListening()
        {
            WriteToLog(DateTime.Now, "", "Listening for incoming connections...");
        }

        private void WriteToLog(DateTime time, string user, string message)
        {
            string mesg = $"{time.ToString("HH:mm")} | {user} {message}";
            StringBuilder sb = new StringBuilder(richTextBoxLog.Text);
            sb.AppendLine(mesg);
            richTextBoxLog.Text = sb.ToString();
        }

        private void AddToList(int Id, ClientsInformation info)
        {
            Invoke(() => Database.list.Add(info));
        }

        private void ErrorWriting(string mesg)
        {
            WriteToLog(DateTime.Now, "", mesg);
        }

        private void StartListeningLog(IPAddress addr, int port)
        {
            WriteToLog(DateTime.Now, "", $"IP: {addr}, Port: {port}");
        }
    }
}
