using System.Windows.Forms;

namespace ChatWinForms
{
    partial class MainChatWindow
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
            sendTextBox = new TextBox();
            buttonSend = new Button();
            chatLayoutPanel1 = new TableLayoutPanel();
            mainWindowFlowLayout = new FlowLayoutPanel();
            panelForMainLayared = new Panel();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            connectToolStripMenuItem = new ToolStripMenuItem();
            disconnectToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            tableLayoutPanel1 = new TableLayoutPanel();
            chatLayoutPanel1.SuspendLayout();
            panelForMainLayared.SuspendLayout();
            menuStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // sendTextBox
            // 
            sendTextBox.Dock = DockStyle.Fill;
            sendTextBox.Location = new Point(3, 3);
            sendTextBox.Name = "sendTextBox";
            sendTextBox.Size = new Size(275, 27);
            sendTextBox.TabIndex = 0;
            sendTextBox.KeyDown += textBox1_KeyDown;
            // 
            // buttonSend
            // 
            buttonSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSend.Location = new Point(285, 3);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(94, 27);
            buttonSend.TabIndex = 1;
            buttonSend.Text = "Send";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += buttonSend_Click;
            // 
            // chatLayoutPanel1
            // 
            chatLayoutPanel1.ColumnCount = 2;
            chatLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            chatLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 101F));
            chatLayoutPanel1.Controls.Add(sendTextBox, 0, 0);
            chatLayoutPanel1.Controls.Add(buttonSend, 1, 0);
            chatLayoutPanel1.Dock = DockStyle.Bottom;
            chatLayoutPanel1.Location = new Point(0, 520);
            chatLayoutPanel1.Name = "chatLayoutPanel1";
            chatLayoutPanel1.RowCount = 1;
            chatLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            chatLayoutPanel1.Size = new Size(382, 33);
            chatLayoutPanel1.TabIndex = 2;
            // 
            // mainWindowFlowLayout
            // 
            mainWindowFlowLayout.AutoSize = true;
            mainWindowFlowLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainWindowFlowLayout.Dock = DockStyle.Top;
            mainWindowFlowLayout.Location = new Point(0, 0);
            mainWindowFlowLayout.Margin = new Padding(3, 4, 3, 4);
            mainWindowFlowLayout.Name = "mainWindowFlowLayout";
            mainWindowFlowLayout.Size = new Size(376, 0);
            mainWindowFlowLayout.TabIndex = 4;
            mainWindowFlowLayout.SizeChanged += mainWindowFlowLayout_SizeChanged;
            // 
            // panelForMainLayared
            // 
            panelForMainLayared.AutoScroll = true;
            panelForMainLayared.Controls.Add(mainWindowFlowLayout);
            panelForMainLayared.Dock = DockStyle.Fill;
            panelForMainLayared.Location = new Point(3, 32);
            panelForMainLayared.Name = "panelForMainLayared";
            panelForMainLayared.Size = new Size(376, 485);
            panelForMainLayared.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.Fill;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 3, 0, 3);
            menuStrip1.Size = new Size(382, 29);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { connectToolStripMenuItem, disconnectToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 23);
            fileToolStripMenuItem.Text = "File";
            // 
            // connectToolStripMenuItem
            // 
            connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            connectToolStripMenuItem.Size = new Size(165, 26);
            connectToolStripMenuItem.Text = "Connect...";
            connectToolStripMenuItem.Click += connectToolStripMenuItem_Click;
            // 
            // disconnectToolStripMenuItem
            // 
            disconnectToolStripMenuItem.Enabled = false;
            disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            disconnectToolStripMenuItem.Size = new Size(165, 26);
            disconnectToolStripMenuItem.Text = "Disconnect";
            disconnectToolStripMenuItem.Click += disconnectToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(165, 26);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(menuStrip1, 0, 0);
            tableLayoutPanel1.Controls.Add(panelForMainLayared, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(382, 520);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // MainChatWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 553);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(chatLayoutPanel1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(320, 472);
            Name = "MainChatWindow";
            Text = "Group Chat";
            FormClosing += MainChatWindow_FormClosing;
            SizeChanged += MainChatWindow_SizeChanged;
            chatLayoutPanel1.ResumeLayout(false);
            chatLayoutPanel1.PerformLayout();
            panelForMainLayared.ResumeLayout(false);
            panelForMainLayared.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox sendTextBox;
        private Button buttonSend;
        private TableLayoutPanel chatLayoutPanel1;
        private FlowLayoutPanel mainWindowFlowLayout;
        private Panel panelForMainLayared;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem connectToolStripMenuItem;
        private ToolStripMenuItem disconnectToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
