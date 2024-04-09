using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace ChatWinForms
{
    public partial class MainChatWindow : Form
    {
        private Client client;
        public Client Client
        {
            get { return client; }
        }

        public static event Action<ChatWinForms.Messages.Message>? MessageSend;
        private void OnMessageSend(ChatWinForms.Messages.Message mesg)
        {
            MessageSend?.Invoke(mesg);
        }

        public MainChatWindow()
        {
            client = new Client();
            InitializeComponent();
            checkScrollBar();
            client.Connected += OnConnected;
            client.Disconnected += OnDisconnected;
            client.MessageReceived += addingMessageOnReceived;
        }


        private void buttonSend_Click(object sender, EventArgs e)
        {
            string user = "You";
            if (client.IsConnected)
            {
                ChatWinForms.Messages.Message message = new ChatWinForms.Messages.Message(client.UserName!, sendTextBox.Text, DateTime.Now);
                var a = SendMessageToServ(message);
            }
            addMessange(sendTextBox.Text, DateTime.Now, user, true);
            sendTextBox.Text = "";
        }



        void addMessange(string messange, DateTime time, string userName, bool isYourth)
        {
            chatMesgBox msgBox = new chatMesgBox()
            {
                Message = messange,
                Date = time.ToString("HH:mm"),
                User = userName
            };
            if (isYourth)
            {
                msgBox.Margin = new Padding(50, 0, 5, 5);
            }
            else
            {
                msgBox.Margin = new Padding(5, 0, 50, 5);
            }
            msgBox.Width = mainWindowFlowLayout.Width - msgBox.Margin.Left - msgBox.Margin.Right;
            checkScrollBar();
            mainWindowFlowLayout.Controls.Add(msgBox);
            panelForMainLayared.ScrollControlIntoView(msgBox);
        }

        void checkScrollBar()
        {
            if (panelForMainLayared.Height > mainWindowFlowLayout.Height)
            {
                panelForMainLayared.AutoScroll = false;
                panelForMainLayared.VerticalScroll.Enabled = true;
                panelForMainLayared.VerticalScroll.Visible = true;
            }
            else
            {
                panelForMainLayared.AutoScroll = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSend_Click(sender, e);
            }
        }

        private void mainWindowFlowLayout_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control msgBox in mainWindowFlowLayout.Controls)
            {
                msgBox.Width = mainWindowFlowLayout.ClientSize.Width - msgBox.Margin.Left - msgBox.Margin.Right;
            }
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectionForm connectionForm = new ConnectionForm(this);
            connectionForm.ShowDialog();

            connectionForm.Dispose();
        }
        /// <summary>
        /// Adding a new label to a Form with Connected text, enabling button Disconnect and disabling button Connect
        /// </summary>
        private void OnConnected()
        {
            client.IsConnected = true;
            connectToolStripMenuItem.Enabled = false;
            disconnectToolStripMenuItem.Enabled = true;
            Label label = new Label();
            label.Text = "Connected";
            label.ForeColor = Color.DarkGray;
            label.TextAlign = ContentAlignment.MiddleCenter;
            Invoke(() => mainWindowFlowLayout.Controls.Add(label));
            panelForMainLayared.ScrollControlIntoView(label);

        }


        /// <summary>
        /// Adding a new labl to a Form with Disconnected text, enabling button Connect and disabling button Disconnect
        /// </summary>
        private void OnDisconnected()
        {
            client.IsConnected = false;
            connectToolStripMenuItem.Enabled = true;
            disconnectToolStripMenuItem.Enabled = false;
            Label label = new Label();
            label.Text = "Disconnected";
            label.ForeColor = Color.DarkGray;
            label.TextAlign = ContentAlignment.MiddleCenter;
            Invoke(() => mainWindowFlowLayout.Controls.Add(label));
            Invoke(() => panelForMainLayared.ScrollControlIntoView(label));

        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client.EndOfWork();
        }

        private void addingMessageOnReceived(ChatWinForms.Messages.Message message)
        {
            Invoke(() => addMessange(message.Text, message.Time, message.Sender, false));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client.EndOfWork();
            Close();
        }

        private async Task SendMessageToServ(ChatWinForms.Messages.Message msg)
        {
            string srt = JsonSerializer.Serialize(msg);
            int res = await client.SendRequest(srt);
            if (res == -1)
            {
                client.Disconnect();
            }
        }
    }
}
