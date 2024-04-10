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
            colID = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colDosconnect = new DataGridViewButtonColumn();
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
            mainBackgroundTableLayout.Margin = new Padding(3, 2, 3, 2);
            mainBackgroundTableLayout.Name = "mainBackgroundTableLayout";
            mainBackgroundTableLayout.RowCount = 1;
            mainBackgroundTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainBackgroundTableLayout.Size = new Size(734, 377);
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
            dataGridViewCellStyle1.BackColor = Color.LightGray;
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
            dataGridView.Location = new Point(448, 2);
            dataGridView.Margin = new Padding(3, 2, 3, 2);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(283, 373);
            dataGridView.TabIndex = 2;
            // 
            // leftSideTableLayoutPanel
            // 
            leftSideTableLayoutPanel.ColumnCount = 1;
            leftSideTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            leftSideTableLayoutPanel.Controls.Add(tableLayoutPanel1, 0, 2);
            leftSideTableLayoutPanel.Controls.Add(richTextBoxLog, 0, 1);
            leftSideTableLayoutPanel.Controls.Add(tableLayoutLeftUpper, 0, 0);
            leftSideTableLayoutPanel.Dock = DockStyle.Fill;
            leftSideTableLayoutPanel.Location = new Point(3, 2);
            leftSideTableLayoutPanel.Margin = new Padding(3, 2, 3, 2);
            leftSideTableLayoutPanel.Name = "leftSideTableLayoutPanel";
            leftSideTableLayoutPanel.RowCount = 3;
            leftSideTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 40.15444F));
            leftSideTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 59.8455544F));
            leftSideTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            leftSideTableLayoutPanel.Size = new Size(439, 373);
            leftSideTableLayoutPanel.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel1.Controls.Add(sendTextBox, 0, 0);
            tableLayoutPanel1.Controls.Add(sendButton, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 344);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(433, 27);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // sendTextBox
            // 
            sendTextBox.Dock = DockStyle.Fill;
            sendTextBox.Location = new Point(3, 2);
            sendTextBox.Margin = new Padding(3, 2, 3, 2);
            sendTextBox.Name = "sendTextBox";
            sendTextBox.Size = new Size(339, 23);
            sendTextBox.TabIndex = 0;
            // 
            // sendButton
            // 
            sendButton.Location = new Point(348, 2);
            sendButton.Margin = new Padding(3, 2, 3, 2);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(82, 22);
            sendButton.TabIndex = 1;
            sendButton.Text = "Send";
            sendButton.UseVisualStyleBackColor = true;
            // 
            // richTextBoxLog
            // 
            richTextBoxLog.BorderStyle = BorderStyle.FixedSingle;
            richTextBoxLog.Dock = DockStyle.Fill;
            richTextBoxLog.Location = new Point(3, 139);
            richTextBoxLog.Margin = new Padding(3, 2, 3, 2);
            richTextBoxLog.Name = "richTextBoxLog";
            richTextBoxLog.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            richTextBoxLog.Size = new Size(433, 201);
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
            tableLayoutLeftUpper.Location = new Point(3, 2);
            tableLayoutLeftUpper.Margin = new Padding(3, 2, 3, 2);
            tableLayoutLeftUpper.Name = "tableLayoutLeftUpper";
            tableLayoutLeftUpper.RowCount = 2;
            tableLayoutLeftUpper.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutLeftUpper.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tableLayoutLeftUpper.Size = new Size(433, 133);
            tableLayoutLeftUpper.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 73F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 104F));
            tableLayoutPanel2.Controls.Add(buttonClear, 0, 0);
            tableLayoutPanel2.Controls.Add(buttonDisconnectAll, 2, 0);
            tableLayoutPanel2.Controls.Add(labelLog, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 107);
            tableLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tableLayoutPanel2.Size = new Size(427, 24);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(3, 2);
            buttonClear.Margin = new Padding(3, 2, 3, 2);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(67, 20);
            buttonClear.TabIndex = 0;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            // 
            // buttonDisconnectAll
            // 
            buttonDisconnectAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonDisconnectAll.Location = new Point(326, 2);
            buttonDisconnectAll.Margin = new Padding(3, 2, 3, 2);
            buttonDisconnectAll.Name = "buttonDisconnectAll";
            buttonDisconnectAll.Size = new Size(98, 20);
            buttonDisconnectAll.TabIndex = 1;
            buttonDisconnectAll.Text = "Disconnect all";
            buttonDisconnectAll.UseVisualStyleBackColor = true;
            // 
            // labelLog
            // 
            labelLog.AutoSize = true;
            labelLog.Dock = DockStyle.Fill;
            labelLog.Location = new Point(76, 0);
            labelLog.Name = "labelLog";
            labelLog.Size = new Size(244, 24);
            labelLog.TabIndex = 2;
            labelLog.Text = "Log";
            labelLog.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelStopAndInput
            // 
            tableLayoutPanelStopAndInput.ColumnCount = 2;
            tableLayoutPanelStopAndInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 74F));
            tableLayoutPanelStopAndInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelStopAndInput.Controls.Add(buttonStop, 0, 0);
            tableLayoutPanelStopAndInput.Controls.Add(panelForInput, 1, 0);
            tableLayoutPanelStopAndInput.Dock = DockStyle.Fill;
            tableLayoutPanelStopAndInput.Location = new Point(3, 2);
            tableLayoutPanelStopAndInput.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanelStopAndInput.Name = "tableLayoutPanelStopAndInput";
            tableLayoutPanelStopAndInput.RowCount = 1;
            tableLayoutPanelStopAndInput.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelStopAndInput.Size = new Size(427, 101);
            tableLayoutPanelStopAndInput.TabIndex = 3;
            // 
            // buttonStop
            // 
            buttonStop.Location = new Point(3, 2);
            buttonStop.Margin = new Padding(3, 2, 3, 2);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(68, 22);
            buttonStop.TabIndex = 0;
            buttonStop.Text = "Stop";
            buttonStop.UseVisualStyleBackColor = true;
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
            panelForInput.Location = new Point(77, 2);
            panelForInput.Margin = new Padding(3, 2, 3, 2);
            panelForInput.Name = "panelForInput";
            panelForInput.Size = new Size(347, 97);
            panelForInput.TabIndex = 1;
            // 
            // checkBoxKey
            // 
            checkBoxKey.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBoxKey.AutoSize = true;
            checkBoxKey.Location = new Point(271, 55);
            checkBoxKey.Margin = new Padding(3, 2, 3, 2);
            checkBoxKey.Name = "checkBoxKey";
            checkBoxKey.Size = new Size(74, 19);
            checkBoxKey.TabIndex = 1;
            checkBoxKey.Text = "ShowKey";
            checkBoxKey.UseVisualStyleBackColor = true;
            // 
            // textBoxKey
            // 
            textBoxKey.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxKey.BorderStyle = BorderStyle.FixedSingle;
            textBoxKey.Location = new Point(273, 30);
            textBoxKey.Margin = new Padding(3, 2, 3, 2);
            textBoxKey.Name = "textBoxKey";
            textBoxKey.Size = new Size(71, 23);
            textBoxKey.TabIndex = 7;
            textBoxKey.TextAlign = HorizontalAlignment.Center;
            textBoxKey.UseSystemPasswordChar = true;
            // 
            // textBoxPort
            // 
            textBoxPort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxPort.BorderStyle = BorderStyle.FixedSingle;
            textBoxPort.Location = new Point(273, 4);
            textBoxPort.Margin = new Padding(3, 2, 3, 2);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(71, 23);
            textBoxPort.TabIndex = 6;
            textBoxPort.Text = "9000";
            textBoxPort.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxUsername.BorderStyle = BorderStyle.FixedSingle;
            textBoxUsername.Location = new Point(162, 32);
            textBoxUsername.Margin = new Padding(3, 2, 3, 2);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(70, 23);
            textBoxUsername.TabIndex = 5;
            textBoxUsername.Text = "Server";
            textBoxUsername.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxAddress.BorderStyle = BorderStyle.FixedSingle;
            textBoxAddress.Location = new Point(162, 5);
            textBoxAddress.Margin = new Padding(3, 2, 3, 2);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(70, 23);
            textBoxAddress.TabIndex = 4;
            textBoxAddress.Text = "localhost";
            textBoxAddress.TextAlign = HorizontalAlignment.Center;
            // 
            // labelKey
            // 
            labelKey.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelKey.AutoSize = true;
            labelKey.Location = new Point(239, 32);
            labelKey.Name = "labelKey";
            labelKey.Size = new Size(29, 15);
            labelKey.TabIndex = 3;
            labelKey.Text = "Key:";
            // 
            // labelPort
            // 
            labelPort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelPort.AutoSize = true;
            labelPort.Location = new Point(238, 7);
            labelPort.Name = "labelPort";
            labelPort.Size = new Size(32, 15);
            labelPort.TabIndex = 2;
            labelPort.Text = "Port:";
            // 
            // labelUsername
            // 
            labelUsername.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(89, 32);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(63, 15);
            labelUsername.TabIndex = 1;
            labelUsername.Text = "Username:";
            // 
            // labelAddress
            // 
            labelAddress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelAddress.AutoSize = true;
            labelAddress.Location = new Point(108, 6);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(45, 15);
            labelAddress.TabIndex = 0;
            labelAddress.Text = "Adress:";
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
            // MainServerWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 377);
            Controls.Add(mainBackgroundTableLayout);
            ForeColor = SystemColors.ActiveCaptionText;
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(628, 362);
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
