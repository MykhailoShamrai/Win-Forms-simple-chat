using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatWinForms
{
    public partial class ConnectionForm : Form
    {
        MainChatWindow parent = null;
        public ConnectionForm()
        {
            InitializeComponent();
        }

        public ConnectionForm(MainChatWindow parent)
        {
            this.parent = parent;
            InitializeComponent();
            AddAllHandlers();
        }

        private void checkBoxVisibleKey_CheckedChanged(object sender, EventArgs e)
        {
            textBoxKey.UseSystemPasswordChar = (checkBoxVisibleKey.Checked) ? false : true;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            buttonConnect.Enabled = false;
            checkBoxVisibleKey.Enabled = false;
            string addres = textBoxAddress.Text;
            string port = textBoxPort.Text;
            string userName = textBoxUser.Text;
            string key = textBoxKey.Text;

            // Setting client properties.
            parent.Client.SetClientsParameters(userName, key);
            // Trying to connect to a server from parent's client
            parent.Client.ConnectToServer(addres, port);
        }

        private void ShowSuccessDialog()
        {
            string message = "Connected Succesfully";
            string title = "Connected";
            MessageBox.Show(message, title);
            Close();
        }

        private void ShowErrorDialog(string msg)
        {
            progressConnection.Value = 0;
            string message = msg;
            string tittle = "Error";
            MessageBox.Show(message, tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            buttonConnect.Enabled = true;
            checkBoxVisibleKey.Enabled = true;
        }

        private void AddProgress()
        {
            progressConnection.PerformStep();
        }

        private void AddAllHandlers()
        {
            parent.Client.Connected += ShowSuccessDialog;
            parent.Client.ConnectionEstablishing += AddProgress;
            parent.Client.SendedAuthorisation += AddProgress;
            parent.Client.CheckingAuthorisation += AddProgress;
            parent.Client.AcceptedAuthorisation += AddProgress;
            parent.Client.BadHostname += ShowErrorDialog;
            parent.Client.ErrorOnSendingAuthorisation += ShowErrorDialog;
            parent.Client.ErronOnConnectionEstablishing += ShowErrorDialog;
            parent.Client.ErrorOnSendingAuthorisation += ShowErrorDialog;
            parent.Client.RejectedAuthorisation += ShowErrorDialog;
        }

        private void CleanAllHandlers()
        {
            parent.Client.Connected -= ShowSuccessDialog;
            parent.Client.ConnectionEstablishing -= AddProgress;
            parent.Client.SendedAuthorisation -= AddProgress;
            parent.Client.CheckingAuthorisation -= AddProgress;
            parent.Client.AcceptedAuthorisation -= AddProgress;
            parent.Client.BadHostname -= ShowErrorDialog;
            parent.Client.ErrorOnSendingAuthorisation -= ShowErrorDialog;
            parent.Client.ErronOnConnectionEstablishing -= ShowErrorDialog;
            parent.Client.ErrorOnSendingAuthorisation -= ShowErrorDialog;
            parent.Client.RejectedAuthorisation -= ShowErrorDialog;
        }

        private void ConnectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CleanAllHandlers();
        }
    }
}
    