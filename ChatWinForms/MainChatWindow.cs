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
        private Client _client;
        public Client Client
        {
            get { return _client; }
        }

        public MainChatWindow()
        {
            _client = new Client();
            InitializeComponent();
            CheckScrollBar();
            _client.Connected += OnConnected;
            _client.Disconnected += OnDisconnected;
            _client.MessageReceived += addingMessageOnReceived;
        }


        private void buttonSend_Click(object sender, EventArgs e)
        {
            string user = "You";
            if (_client.IsConnected)
            {
                ChatWinForms.Messages.Message message = new ChatWinForms.Messages.Message(_client.UserName!, sendTextBox.Text, DateTime.Now);
                var a = SendMessageToServ(message);
            }
            AddMessage(sendTextBox.Text, DateTime.Now, user, true);
            sendTextBox.Text = "";
        }


        /// <summary>
        /// Method that adds new message to space in main window, depending on information, if it's "my" or "not my" message.
        /// </summary>
        /// <param name="message">Text of a message</param>
        /// <param name="time">Time of sending message</param>
        /// <param name="userName">Name of a user that send a message</param>
        /// <param name="isYourth">bool that shows is the message "our" or another user</param>
        void AddMessage(string message, DateTime time, string userName, bool isYourth)
        {
            chatMesgBox msgBox = new chatMesgBox()
            {
                Message = message,
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
            CheckScrollBar();
            mainWindowFlowLayout.Controls.Add(msgBox);
            panelForMainLayared.ScrollControlIntoView(msgBox);
        }

        /// <summary>
        /// Makes possible that scrollbar is always visible.
        /// </summary>
        private void CheckScrollBar()
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

        /// <summary>
        /// Pressing Enter key.
        /// </summary>
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSend_Click(sender, e);
            }
        }

        /// <summary>
        /// Changing width of all controls on changing size of a window.
        /// </summary>
        private void mainWindowFlowLayout_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control contorl in mainWindowFlowLayout.Controls)
            {
                contorl.Width = mainWindowFlowLayout.ClientSize.Width - contorl.Margin.Left - contorl.Margin.Right;
            }
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectionForm connectionForm = new ConnectionForm(this);
            connectionForm.ShowDialog();
            connectionForm.Dispose();
        }
        /// <summary>
        /// Adding a new label to a Form with Connected text, enabling button Disconnect and disabling button Connect.
        /// </summary>
        private void OnConnected()
        {
            _client.IsConnected = true;
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
        /// Adding a new labl to a Form with Disconnected text, enabling button Connect and disabling button Disconnect.
        /// </summary>
        private void OnDisconnected()
        {
            _client.IsConnected = false;
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
            Client.EndOfWork();
        }

        private void addingMessageOnReceived(ChatWinForms.Messages.Message message)
        {
            Invoke(() => AddMessage(message.Text, message.Time, message.Sender, false));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async Task SendMessageToServ(ChatWinForms.Messages.Message msg)
        {
            string srt = JsonSerializer.Serialize(msg);
            int res = await _client.SendRequest(srt);
            if (res == -1)
            {
                Client.Disconnect();
            }
        }

        private void MainChatWindow_SizeChanged(object sender, EventArgs e)
        {
            CheckScrollBar();
        }

        private void MainChatWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Client.Connected -= OnConnected;
            Client.Disconnected -= OnDisconnected;
            Client.MessageReceived -= addingMessageOnReceived;
            Client.EndOfWork();
        }
    }
}
