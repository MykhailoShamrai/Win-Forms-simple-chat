using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace ChatWinForms
{
    public partial class MainChatWindow : Form
    {
        private Client client;
        public Client Client
        {
            get { return  client; }
           // set { client = value; }
        }
        private bool first = true;
        public MainChatWindow()
        {
            client = new Client();
            InitializeComponent();
            checkScrollBar();
            client.Connected += OnConnected;
            client.Disconnected += OnDisconnected;
        }


        private void buttonSend_Click(object sender, EventArgs e)
        {
            string user = first ? "You" : "Not You";
            addMessange(sendTextBox.Text, DateTime.Now, user);
            sendTextBox.Text = "";
            first = !first;
        }

        void addMessange(string messange, DateTime time, string userName)
        {
            chatMesgBox msgBox = new chatMesgBox()
            {
                Message = messange,
                Date = time.ToString("HH:mm"),
                User = userName
            };
            if (first)
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
            foreach (chatMesgBox msgBox in mainWindowFlowLayout.Controls)
            {
                msgBox.Width = mainWindowFlowLayout.ClientSize.Width - msgBox.Margin.Left - msgBox.Margin.Right;
            }
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
              ConnectionForm connectionForm = new ConnectionForm(this);
              connectionForm.ShowDialog();
        }

        private void OnConnected()
        {
            connectToolStripMenuItem.Enabled = false;
            disconnectToolStripMenuItem.Enabled = true;
        }

        private void OnDisconnected()
        {
            connectToolStripMenuItem.Enabled = true;
            disconnectToolStripMenuItem.Enabled = false;
        }
    }
}
