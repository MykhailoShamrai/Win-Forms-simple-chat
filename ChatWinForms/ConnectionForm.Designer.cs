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
            textBoxKey = new TextBox();
            textBoxPort = new TextBox();
            textBoxUser = new TextBox();
            textBoxAddress = new TextBox();
            labelKey = new Label();
            labelUserName = new Label();
            labelPort = new Label();
            labelAddress = new Label();
            checkBoxVisibleKey = new CheckBox();
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
            backgroundLayeredTable.Name = "backgroundLayeredTable";
            backgroundLayeredTable.RowCount = 2;
            backgroundLayeredTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            backgroundLayeredTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            backgroundLayeredTable.Size = new Size(432, 203);
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
            bottomTableLayout.Location = new Point(3, 166);
            bottomTableLayout.Name = "bottomTableLayout";
            bottomTableLayout.RowCount = 1;
            bottomTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            bottomTableLayout.Size = new Size(426, 34);
            bottomTableLayout.TabIndex = 2;
            // 
            // buttonConnect
            // 
            buttonConnect.Dock = DockStyle.Right;
            buttonConnect.Location = new Point(329, 3);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(94, 28);
            buttonConnect.TabIndex = 1;
            buttonConnect.Text = "Connect";
            buttonConnect.UseVisualStyleBackColor = true;
            // 
            // progressConnection
            // 
            progressConnection.Location = new Point(11, 3);
            progressConnection.Margin = new Padding(11, 3, 3, 3);
            progressConnection.Name = "progressConnection";
            progressConnection.Size = new Size(302, 28);
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
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(426, 157);
            panel1.TabIndex = 3;
            // 
            // textBoxKey
            // 
            textBoxKey.Location = new Point(268, 90);
            textBoxKey.Name = "textBoxKey";
            textBoxKey.Size = new Size(125, 27);
            textBoxKey.TabIndex = 7;
            textBoxKey.TextAlign = HorizontalAlignment.Center;
            textBoxKey.UseSystemPasswordChar = true;
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new Point(268, 30);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(125, 27);
            textBoxPort.TabIndex = 6;
            textBoxPort.Text = "9000";
            textBoxPort.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxUser
            // 
            textBoxUser.Location = new Point(93, 90);
            textBoxUser.Name = "textBoxUser";
            textBoxUser.Size = new Size(125, 27);
            textBoxUser.TabIndex = 5;
            textBoxUser.Text = "user";
            textBoxUser.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(93, 30);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(125, 27);
            textBoxAddress.TabIndex = 4;
            textBoxAddress.Text = "localhost";
            textBoxAddress.TextAlign = HorizontalAlignment.Center;
            // 
            // labelKey
            // 
            labelKey.AutoSize = true;
            labelKey.Location = new Point(224, 97);
            labelKey.Name = "labelKey";
            labelKey.Size = new Size(36, 20);
            labelKey.TabIndex = 3;
            labelKey.Text = "Key:";
            // 
            // labelUserName
            // 
            labelUserName.AutoSize = true;
            labelUserName.Location = new Point(9, 97);
            labelUserName.Name = "labelUserName";
            labelUserName.Size = new Size(78, 20);
            labelUserName.TabIndex = 2;
            labelUserName.Text = "Username:";
            // 
            // labelPort
            // 
            labelPort.AutoSize = true;
            labelPort.Location = new Point(224, 37);
            labelPort.Name = "labelPort";
            labelPort.Size = new Size(38, 20);
            labelPort.TabIndex = 1;
            labelPort.Text = "Port:";
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Location = new Point(22, 37);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(65, 20);
            labelAddress.TabIndex = 0;
            labelAddress.Text = "Address:";
            // 
            // checkBoxVisibleKey
            // 
            checkBoxVisibleKey.AutoSize = true;
            checkBoxVisibleKey.Location = new Point(292, 123);
            checkBoxVisibleKey.Name = "checkBoxVisibleKey";
            checkBoxVisibleKey.Size = new Size(93, 24);
            checkBoxVisibleKey.TabIndex = 8;
            checkBoxVisibleKey.Text = "Show key";
            checkBoxVisibleKey.UseVisualStyleBackColor = true;
            checkBoxVisibleKey.CheckedChanged += checkBoxVisibleKey_CheckedChanged;
            // 
            // ConnectionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(432, 203);
            Controls.Add(backgroundLayeredTable);
            MaximumSize = new Size(450, 250);
            MinimumSize = new Size(450, 250);
            Name = "ConnectionForm";
            Text = "Connect";
            TopMost = true;
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