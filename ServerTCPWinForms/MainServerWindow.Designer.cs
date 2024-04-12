namespace ServerTCPWinForms
{
    partial class MainServerWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            mainBackgroundTableLayout = new TableLayoutPanel();
            dataGridView = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colDosconnect = new DataGridViewButtonColumn();
            leftSideTableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            sendTextBox = new TextBox();
            sendButton = new Button();
            richTextBoxLog = new RichTextBox();
            tableLayoutLeftUpper = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            buttonClear = new Button();
            buttonDisconnectAll = new Button();
            labelLog = new Label();
            tableLayoutPanelStopAndInput = new TableLayoutPanel();
            buttonStop = new Button();
            panelForInput = new Panel();
            checkBoxKey = new CheckBox();
            textBoxKey = new TextBox();
            textBoxPort = new TextBox();
            textBoxUsername = new TextBox();
            textBoxAddress = new TextBox();
            labelKey = new Label();
            labelPort = new Label();
            labelUsername = new Label();
            labelAddress = new Label();
            mainBackgroundTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            leftSideTableLayoutPanel.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutLeftUpper.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanelStopAndInput.SuspendLayout();
            panelForInput.SuspendLayout();
            SuspendLayout();
            // 
            // mainBackgroundTableLayout
            // 
            mainBackgroundTableLayout.ColumnCount = 2;
            mainBackgroundTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60.7329826F));
            mainBackgroundTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39.2670135F));
            mainBackgroundTableLayout.Controls.Add(dataGridView, 1, 0);
            mainBackgroundTableLayout.Controls.Add(leftSideTableLayoutPanel, 0, 0);
            mainBackgroundTableLayout.Dock = DockStyle.Fill;
            mainBackgroundTableLayout.Location = new Point(0, 0);
            mainBackgroundTableLayout.Name = "mainBackgroundTableLayout";
            mainBackgroundTableLayout.RowCount = 1;
            mainBackgroundTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainBackgroundTableLayout.Size = new Size(839, 503);
            mainBackgroundTableLayout.TabIndex = 0;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.Silver;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colID, colName, colDosconnect });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.GridColor = SystemColors.ScrollBar;
            dataGridView.Location = new Point(512, 3);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(324, 497);
            dataGridView.TabIndex = 2;
            // 
            // colID
            // 
            colID.DataPropertyName = "ID";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colID.DefaultCellStyle = dataGridViewCellStyle2;
            colID.HeaderText = "ID";
            colID.MinimumWidth = 6;
            colID.Name = "colID";
            colID.ReadOnly = true;
            // 
            // colName
            // 
            colName.DataPropertyName = "Name";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            colName.DefaultCellStyle = dataGridViewCellStyle3;
            colName.HeaderText = "Name";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colDosconnect
            // 
            colDosconnect.HeaderText = "Disconnect";
            colDosconnect.MinimumWidth = 6;
            colDosconnect.Name = "colDosconnect";
            colDosconnect.ReadOnly = true;
            colDosconnect.Resizable = DataGridViewTriState.True;
            colDosconnect.Text = "Kick";
            colDosconnect.UseColumnTextForButtonValue = true;
            // 
            // leftSideTableLayoutPanel
            // 
            leftSideTableLayoutPanel.ColumnCount = 1;
            leftSideTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            leftSideTableLayoutPanel.Controls.Add(tableLayoutPanel1, 0, 2);
            leftSideTableLayoutPanel.Controls.Add(richTextBoxLog, 0, 1);
            leftSideTableLayoutPanel.Controls.Add(tableLayoutLeftUpper, 0, 0);
            leftSideTableLayoutPanel.Dock = DockStyle.Fill;
            leftSideTableLayoutPanel.Location = new Point(3, 3);
            leftSideTableLayoutPanel.Name = "leftSideTableLayoutPanel";
            leftSideTableLayoutPanel.RowCount = 3;
            leftSideTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 40.15444F));
            leftSideTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 59.8455544F));
            leftSideTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            leftSideTableLayoutPanel.Size = new Size(503, 497);
            leftSideTableLayoutPanel.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 101F));
            tableLayoutPanel1.Controls.Add(sendTextBox, 0, 0);
            tableLayoutPanel1.Controls.Add(sendButton, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 459);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(497, 35);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // sendTextBox
            // 
            sendTextBox.Dock = DockStyle.Fill;
            sendTextBox.Location = new Point(3, 3);
            sendTextBox.Name = "sendTextBox";
            sendTextBox.Size = new Size(390, 27);
            sendTextBox.TabIndex = 0;
            sendTextBox.KeyDown += sendTextBox_KeyDown;
            // 
            // sendButton
            // 
            sendButton.Location = new Point(399, 3);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(94, 29);
            sendButton.TabIndex = 1;
            sendButton.Text = "Send";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // richTextBoxLog
            // 
            richTextBoxLog.BorderStyle = BorderStyle.FixedSingle;
            richTextBoxLog.Dock = DockStyle.Fill;
            richTextBoxLog.Location = new Point(3, 186);
            richTextBoxLog.Name = "richTextBoxLog";
            richTextBoxLog.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            richTextBoxLog.Size = new Size(497, 267);
            richTextBoxLog.TabIndex = 1;
            richTextBoxLog.Text = "";
            // 
            // tableLayoutLeftUpper
            // 
            tableLayoutLeftUpper.ColumnCount = 1;
            tableLayoutLeftUpper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutLeftUpper.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutLeftUpper.Controls.Add(tableLayoutPanelStopAndInput, 0, 0);
            tableLayoutLeftUpper.Dock = DockStyle.Fill;
            tableLayoutLeftUpper.Location = new Point(3, 3);
            tableLayoutLeftUpper.Name = "tableLayoutLeftUpper";
            tableLayoutLeftUpper.RowCount = 2;
            tableLayoutLeftUpper.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutLeftUpper.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tableLayoutLeftUpper.Size = new Size(497, 177);
            tableLayoutLeftUpper.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 83F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 119F));
            tableLayoutPanel2.Controls.Add(buttonClear, 0, 0);
            tableLayoutPanel2.Controls.Add(buttonDisconnectAll, 2, 0);
            tableLayoutPanel2.Controls.Add(labelLog, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 143);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel2.Size = new Size(491, 31);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(3, 3);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(77, 25);
            buttonClear.TabIndex = 0;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // buttonDisconnectAll
            // 
            buttonDisconnectAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonDisconnectAll.Location = new Point(376, 3);
            buttonDisconnectAll.Name = "buttonDisconnectAll";
            buttonDisconnectAll.Size = new Size(112, 25);
            buttonDisconnectAll.TabIndex = 1;
            buttonDisconnectAll.Text = "Disconnect all";
            buttonDisconnectAll.UseVisualStyleBackColor = true;
            buttonDisconnectAll.Click += buttonDisconnectAll_Click;
            // 
            // labelLog
            // 
            labelLog.AutoSize = true;
            labelLog.Dock = DockStyle.Fill;
            labelLog.Location = new Point(86, 0);
            labelLog.Name = "labelLog";
            labelLog.Size = new Size(283, 31);
            labelLog.TabIndex = 2;
            labelLog.Text = "Log";
            labelLog.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelStopAndInput
            // 
            tableLayoutPanelStopAndInput.ColumnCount = 2;
            tableLayoutPanelStopAndInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85F));
            tableLayoutPanelStopAndInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelStopAndInput.Controls.Add(buttonStop, 0, 0);
            tableLayoutPanelStopAndInput.Controls.Add(panelForInput, 1, 0);
            tableLayoutPanelStopAndInput.Dock = DockStyle.Fill;
            tableLayoutPanelStopAndInput.Location = new Point(3, 3);
            tableLayoutPanelStopAndInput.Name = "tableLayoutPanelStopAndInput";
            tableLayoutPanelStopAndInput.RowCount = 1;
            tableLayoutPanelStopAndInput.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelStopAndInput.Size = new Size(491, 134);
            tableLayoutPanelStopAndInput.TabIndex = 3;
            // 
            // buttonStop
            // 
            buttonStop.Location = new Point(3, 3);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(78, 29);
            buttonStop.TabIndex = 0;
            buttonStop.Text = "Start";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
            // 
            // panelForInput
            // 
            panelForInput.Controls.Add(checkBoxKey);
            panelForInput.Controls.Add(textBoxKey);
            panelForInput.Controls.Add(textBoxPort);
            panelForInput.Controls.Add(textBoxUsername);
            panelForInput.Controls.Add(textBoxAddress);
            panelForInput.Controls.Add(labelKey);
            panelForInput.Controls.Add(labelPort);
            panelForInput.Controls.Add(labelUsername);
            panelForInput.Controls.Add(labelAddress);
            panelForInput.Dock = DockStyle.Fill;
            panelForInput.Location = new Point(88, 3);
            panelForInput.Name = "panelForInput";
            panelForInput.Size = new Size(400, 128);
            panelForInput.TabIndex = 1;
            // 
            // checkBoxKey
            // 
            checkBoxKey.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBoxKey.AutoSize = true;
            checkBoxKey.Location = new Point(306, 73);
            checkBoxKey.Name = "checkBoxKey";
            checkBoxKey.Size = new Size(91, 24);
            checkBoxKey.TabIndex = 1;
            checkBoxKey.Text = "ShowKey";
            checkBoxKey.UseVisualStyleBackColor = true;
            checkBoxKey.CheckedChanged += checkBoxKey_CheckedChanged;
            // 
            // textBoxKey
            // 
            textBoxKey.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxKey.BorderStyle = BorderStyle.FixedSingle;
            textBoxKey.Location = new Point(315, 40);
            textBoxKey.Name = "textBoxKey";
            textBoxKey.Size = new Size(81, 27);
            textBoxKey.TabIndex = 7;
            textBoxKey.TextAlign = HorizontalAlignment.Center;
            textBoxKey.UseSystemPasswordChar = true;
            // 
            // textBoxPort
            // 
            textBoxPort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxPort.BorderStyle = BorderStyle.FixedSingle;
            textBoxPort.Location = new Point(315, 5);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(81, 27);
            textBoxPort.TabIndex = 6;
            textBoxPort.Text = "9000";
            textBoxPort.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxUsername.BorderStyle = BorderStyle.FixedSingle;
            textBoxUsername.Location = new Point(188, 43);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(80, 27);
            textBoxUsername.TabIndex = 5;
            textBoxUsername.Text = "Server";
            textBoxUsername.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxAddress.BorderStyle = BorderStyle.FixedSingle;
            textBoxAddress.Location = new Point(188, 7);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(80, 27);
            textBoxAddress.TabIndex = 4;
            textBoxAddress.Text = "localhost";
            textBoxAddress.TextAlign = HorizontalAlignment.Center;
            // 
            // labelKey
            // 
            labelKey.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelKey.AutoSize = true;
            labelKey.Location = new Point(276, 43);
            labelKey.Name = "labelKey";
            labelKey.Size = new Size(36, 20);
            labelKey.TabIndex = 3;
            labelKey.Text = "Key:";
            // 
            // labelPort
            // 
            labelPort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelPort.AutoSize = true;
            labelPort.Location = new Point(275, 9);
            labelPort.Name = "labelPort";
            labelPort.Size = new Size(38, 20);
            labelPort.TabIndex = 2;
            labelPort.Text = "Port:";
            // 
            // labelUsername
            // 
            labelUsername.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(105, 43);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(78, 20);
            labelUsername.TabIndex = 1;
            labelUsername.Text = "Username:";
            // 
            // labelAddress
            // 
            labelAddress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelAddress.AutoSize = true;
            labelAddress.Location = new Point(126, 8);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(56, 20);
            labelAddress.TabIndex = 0;
            labelAddress.Text = "Adress:";
            // 
            // MainServerWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(839, 503);
            Controls.Add(mainBackgroundTableLayout);
            ForeColor = SystemColors.ActiveCaptionText;
            MinimumSize = new Size(715, 467);
            Name = "MainServerWindow";
            Text = "Server";
            mainBackgroundTableLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            leftSideTableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutLeftUpper.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanelStopAndInput.ResumeLayout(false);
            panelForInput.ResumeLayout(false);
            panelForInput.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainBackgroundTableLayout;
        private TableLayoutPanel leftSideTableLayoutPanel;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox sendTextBox;
        private Button sendButton;
        private DataGridView dataGridView;
        private RichTextBox richTextBoxLog;
        private TableLayoutPanel tableLayoutLeftUpper;
        private TableLayoutPanel tableLayoutPanel2;
        private Button buttonClear;
        private Button buttonDisconnectAll;
        private Label labelLog;
        private TableLayoutPanel tableLayoutPanelStopAndInput;
        private Button buttonStop;
        private Panel panelForInput;
        private Label labelKey;
        private Label labelPort;
        private Label labelUsername;
        private Label labelAddress;
        private TextBox textBoxAddress;
        private TextBox textBoxPort;
        private TextBox textBoxUsername;
        private TextBox textBoxKey;
        private CheckBox checkBoxKey;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewButtonColumn colDosconnect;
    }
}
