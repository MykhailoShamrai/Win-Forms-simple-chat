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
            chatLayoutPanel1.SuspendLayout();
            panelForMainLayared.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // sendTextBox
            // 
            sendTextBox.Dock = DockStyle.Fill;
            sendTextBox.Location = new Point(3, 2);
            sendTextBox.Margin = new Padding(3, 2, 3, 2);
            sendTextBox.Name = "sendTextBox";
            sendTextBox.Size = new Size(240, 23);
            sendTextBox.TabIndex = 0;
            sendTextBox.KeyDown += textBox1_KeyDown;
            // 
            // buttonSend
            // 
            buttonSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSend.Location = new Point(249, 2);
            buttonSend.Margin = new Padding(3, 2, 3, 2);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(82, 20);
            buttonSend.TabIndex = 1;
            buttonSend.Text = "Send";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += buttonSend_Click;
            // 
            // chatLayoutPanel1
            // 
            chatLayoutPanel1.ColumnCount = 2;
            chatLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            chatLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            chatLayoutPanel1.Controls.Add(sendTextBox, 0, 0);
            chatLayoutPanel1.Controls.Add(buttonSend, 1, 0);
            chatLayoutPanel1.Dock = DockStyle.Bottom;
            chatLayoutPanel1.Location = new Point(0, 391);
            chatLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            chatLayoutPanel1.Name = "chatLayoutPanel1";
            chatLayoutPanel1.RowCount = 1;
            chatLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            chatLayoutPanel1.Size = new Size(334, 24);
            chatLayoutPanel1.TabIndex = 2;
            // 
            // mainWindowFlowLayout
            // 
            mainWindowFlowLayout.AutoSize = true;
            mainWindowFlowLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainWindowFlowLayout.Dock = DockStyle.Top;
            mainWindowFlowLayout.Location = new Point(0, 24);
            mainWindowFlowLayout.Name = "mainWindowFlowLayout";
            mainWindowFlowLayout.Size = new Size(334, 0);
            mainWindowFlowLayout.TabIndex = 4;
            mainWindowFlowLayout.SizeChanged += mainWindowFlowLayout_SizeChanged;
            // 
            // panelForMainLayared
            // 
            panelForMainLayared.AutoScroll = true;
            panelForMainLayared.Controls.Add(mainWindowFlowLayout);
            panelForMainLayared.Controls.Add(menuStrip1);
            panelForMainLayared.Dock = DockStyle.Fill;
            panelForMainLayared.Location = new Point(0, 0);
            panelForMainLayared.Margin = new Padding(3, 2, 3, 2);
            panelForMainLayared.Name = "panelForMainLayared";
            panelForMainLayared.Size = new Size(334, 391);
            panelForMainLayared.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(334, 24);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { connectToolStripMenuItem, disconnectToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // connectToolStripMenuItem
            // 
            connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            connectToolStripMenuItem.Size = new Size(133, 22);
            connectToolStripMenuItem.Text = "Connect...";
            connectToolStripMenuItem.Click += connectToolStripMenuItem_Click;
            // 
            // disconnectToolStripMenuItem
            // 
            disconnectToolStripMenuItem.Enabled = false;
            disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            disconnectToolStripMenuItem.Size = new Size(133, 22);
            disconnectToolStripMenuItem.Text = "Disconnect";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(133, 22);
            exitToolStripMenuItem.Text = "Exit";
            // 
            // MainChatWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 415);
            Controls.Add(panelForMainLayared);
            Controls.Add(chatLayoutPanel1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(282, 368);
            Name = "MainChatWindow";
            Text = "Group Chat";
            chatLayoutPanel1.ResumeLayout(false);
            chatLayoutPanel1.PerformLayout();
            panelForMainLayared.ResumeLayout(false);
            panelForMainLayared.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
    }
}
