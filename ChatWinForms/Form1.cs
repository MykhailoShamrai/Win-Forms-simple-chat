using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ChatWinForms
{
    public partial class MainChatWindow : Form
    {
        private bool first = true;
        public MainChatWindow()
        {
            InitializeComponent();
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

            mainWindowFlowLayout.Controls.Add(msgBox);
            panelForMainLayared.ScrollControlIntoView(msgBox);
           
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
    }
}
