namespace ChatWinForms
{
    partial class ConnectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            backgroundLayeredTable = new TableLayoutPanel();
            bottomTableLayout = new TableLayoutPanel();
            buttonConnect = new Button();
            progressConnection = new ProgressBar();
            panel1 = new Panel();
            checkBoxVisibleKey = new CheckBox();
            textBoxKey = new TextBox();
            textBoxPort = new TextBox();
            textBoxUser = new TextBox();
            textBoxAddress = new TextBox();
            labelKey = new Label();
            labelUserName = new Label();
            labelPort = new Label();
            labelAddress = new Label();
            backgroundLayeredTable.SuspendLayout();
            bottomTableLayout.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // backgroundLayeredTable
            // 
            backgroundLayeredTable.ColumnCount = 1;
            backgroundLayeredTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            backgroundLayeredTable.Controls.Add(bottomTableLayout, 0, 1);
            backgroundLayeredTable.Controls.Add(panel1, 0, 0);
            backgroundLayeredTable.Dock = DockStyle.Fill;
            backgroundLayeredTable.Location = new Point(0, 0);
            backgroundLayeredTable.Margin = new Padding(3, 2, 3, 2);
            backgroundLayeredTable.Name = "backgroundLayeredTable";
            backgroundLayeredTable.RowCount = 2;
            backgroundLayeredTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            backgroundLayeredTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            backgroundLayeredTable.Size = new Size(380, 158);
            backgroundLayeredTable.TabIndex = 0;
            // 
            // bottomTableLayout
            // 
            bottomTableLayout.ColumnCount = 2;
            bottomTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76.29108F));
            bottomTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.70892F));
            bottomTableLayout.Controls.Add(buttonConnect, 1, 0);
            bottomTableLayout.Controls.Add(progressConnection, 0, 0);
            bottomTableLayout.Dock = DockStyle.Fill;
            bottomTableLayout.Location = new Point(3, 130);
            bottomTableLayout.Margin = new Padding(3, 2, 3, 2);
            bottomTableLayout.Name = "bottomTableLayout";
            bottomTableLayout.RowCount = 1;
            bottomTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            bottomTableLayout.Size = new Size(374, 26);
            bottomTableLayout.TabIndex = 2;
            // 
            // buttonConnect
            // 
            buttonConnect.Dock = DockStyle.Right;
            buttonConnect.Location = new Point(289, 2);
            buttonConnect.Margin = new Padding(3, 2, 3, 2);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(82, 22);
            buttonConnect.TabIndex = 1;
            buttonConnect.Text = "Connect";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += buttonConnect_Click;
            // 
            // progressConnection
            // 
            progressConnection.Location = new Point(10, 2);
            progressConnection.Margin = new Padding(10, 2, 3, 2);
            progressConnection.Name = "progressConnection";
            progressConnection.Size = new Size(264, 21);
            progressConnection.Step = 25;
            progressConnection.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(checkBoxVisibleKey);
            panel1.Controls.Add(textBoxKey);
            panel1.Controls.Add(textBoxPort);
            panel1.Controls.Add(textBoxUser);
            panel1.Controls.Add(textBoxAddress);
            panel1.Controls.Add(labelKey);
            panel1.Controls.Add(labelUserName);
            panel1.Controls.Add(labelPort);
            panel1.Controls.Add(labelAddress);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 2);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(374, 124);
            panel1.TabIndex = 3;
            // 
            // checkBoxVisibleKey
            // 
            checkBoxVisibleKey.AutoSize = true;
            checkBoxVisibleKey.Location = new Point(256, 92);
            checkBoxVisibleKey.Margin = new Padding(3, 2, 3, 2);
            checkBoxVisibleKey.Name = "checkBoxVisibleKey";
            checkBoxVisibleKey.Size = new Size(76, 19);
            checkBoxVisibleKey.TabIndex = 8;
            checkBoxVisibleKey.Text = "Show key";
            checkBoxVisibleKey.UseVisualStyleBackColor = true;
            checkBoxVisibleKey.CheckedChanged += checkBoxVisibleKey_CheckedChanged;
            // 
            // textBoxKey
            // 
            textBoxKey.Location = new Point(234, 68);
            textBoxKey.Margin = new Padding(3, 2, 3, 2);
            textBoxKey.Name = "textBoxKey";
            textBoxKey.Size = new Size(110, 23);
            textBoxKey.TabIndex = 7;
            textBoxKey.TextAlign = HorizontalAlignment.Center;
            textBoxKey.UseSystemPasswordChar = true;
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new Point(234, 22);
            textBoxPort.Margin = new Padding(3, 2, 3, 2);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(110, 23);
            textBoxPort.TabIndex = 6;
            textBoxPort.Text = "9000";
            textBoxPort.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxUser
            // 
            textBoxUser.Location = new Point(81, 68);
            textBoxUser.Margin = new Padding(3, 2, 3, 2);
            textBoxUser.Name = "textBoxUser";
            textBoxUser.Size = new Size(110, 23);
            textBoxUser.TabIndex = 5;
            textBoxUser.Text = "user";
            textBoxUser.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(81, 22);
            textBoxAddress.Margin = new Padding(3, 2, 3, 2);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(110, 23);
            textBoxAddress.TabIndex = 4;
            textBoxAddress.Text = "localhost";
            textBoxAddress.TextAlign = HorizontalAlignment.Center;
            // 
            // labelKey
            // 
            labelKey.AutoSize = true;
            labelKey.Location = new Point(196, 73);
            labelKey.Name = "labelKey";
            labelKey.Size = new Size(29, 15);
            labelKey.TabIndex = 3;
            labelKey.Text = "Key:";
            // 
            // labelUserName
            // 
            labelUserName.AutoSize = true;
            labelUserName.Location = new Point(8, 73);
            labelUserName.Name = "labelUserName";
            labelUserName.Size = new Size(63, 15);
            labelUserName.TabIndex = 2;
            labelUserName.Text = "Username:";
            // 
            // labelPort
            // 
            labelPort.AutoSize = true;
            labelPort.Location = new Point(196, 28);
            labelPort.Name = "labelPort";
            labelPort.Size = new Size(32, 15);
            labelPort.TabIndex = 1;
            labelPort.Text = "Port:";
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Location = new Point(19, 28);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(52, 15);
            labelAddress.TabIndex = 0;
            labelAddress.Text = "Address:";
            // 
            // ConnectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 158);
            Controls.Add(backgroundLayeredTable);
            Margin = new Padding(3, 2, 3, 2);
            MaximumSize = new Size(396, 197);
            MinimumSize = new Size(396, 197);
            Name = "ConnectionForm";
            Text = "Connect";
            FormClosing += ConnectionForm_FormClosing;
            backgroundLayeredTable.ResumeLayout(false);
            bottomTableLayout.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel backgroundLayeredTable;
        private Button buttonConnect;
        private TableLayoutPanel bottomTableLayout;
        private ProgressBar progressConnection;
        private Panel panel1;
        private Label labelKey;
        private Label labelUserName;
        private Label labelPort;
        private Label labelAddress;
        private TextBox textBoxUser;
        private TextBox textBoxAddress;
        private TextBox textBoxKey;
        private TextBox textBoxPort;
        private CheckBox checkBoxVisibleKey;
    }
}