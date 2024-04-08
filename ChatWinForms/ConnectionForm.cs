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
            //parent.Client.
        }

        public ConnectionForm(MainChatWindow parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void checkBoxVisibleKey_CheckedChanged(object sender, EventArgs e)
        {
            textBoxKey.UseSystemPasswordChar = (checkBoxVisibleKey.Checked) ? false : true;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            string addres = textBoxAddress.Text;
            string port = textBoxPort.Text;
            string userName = textBoxUser.Text;
            string key = textBoxKey.Text;

            parent.Client.setClientsParameters(userName, key);
            parent.Client.ConnectToServer(addres, port);
            
            //Close();
            //Dispose();
        }


    }
}
    