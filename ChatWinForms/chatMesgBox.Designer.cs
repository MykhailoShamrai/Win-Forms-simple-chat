namespace ChatWinForms
{
    partial class chatMesgBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            chatMesgLayoutPanel = new TableLayoutPanel();
            userLabel = new Label();
            panel1 = new Panel();
            messageTextBox = new TextBox();
            dateLabel = new Label();
            chatMesgLayoutPanel.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // chatMesgLayoutPanel
            // 
            chatMesgLayoutPanel.AutoSize = true;
            chatMesgLayoutPanel.ColumnCount = 1;
            chatMesgLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            chatMesgLayoutPanel.Controls.Add(userLabel, 0, 0);
            chatMesgLayoutPanel.Controls.Add(panel1, 0, 1);
            chatMesgLayoutPanel.Controls.Add(dateLabel, 0, 2);
            chatMesgLayoutPanel.Dock = DockStyle.Fill;
            chatMesgLayoutPanel.Location = new Point(0, 0);
            chatMesgLayoutPanel.Name = "chatMesgLayoutPanel";
            chatMesgLayoutPanel.RowCount = 3;
            chatMesgLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            chatMesgLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            chatMesgLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            chatMesgLayoutPanel.Size = new Size(254, 75);
            chatMesgLayoutPanel.TabIndex = 0;
            chatMesgLayoutPanel.SizeChanged += chatMesgLayoutPanel_SizeChanged;
            // 
            // userLabel
            // 
            userLabel.AutoSize = true;
            userLabel.Dock = DockStyle.Bottom;
            userLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            userLabel.ForeColor = Color.White;
            userLabel.Location = new Point(3, 7);
            userLabel.Name = "userLabel";
            userLabel.Size = new Size(248, 15);
            userLabel.TabIndex = 0;
            userLabel.Text = "User";
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = Color.FromArgb(192, 64, 0);
            panel1.Controls.Add(messageTextBox);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(248, 22);
            panel1.TabIndex = 1;
            // 
            // messageTextBox
            // 
            messageTextBox.BackColor = Color.FromArgb(255, 128, 0);
            messageTextBox.BorderStyle = BorderStyle.None;
            messageTextBox.Dock = DockStyle.Fill;
            messageTextBox.ForeColor = Color.White;
            messageTextBox.Location = new Point(0, 0);
            messageTextBox.Multiline = true;
            messageTextBox.Name = "messageTextBox";
            messageTextBox.ReadOnly = true;
            messageTextBox.Size = new Size(248, 22);
            messageTextBox.TabIndex = 0;
            messageTextBox.Text = "ExampleText";
            // 
            // dateLabel
            // 
            dateLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dateLabel.ForeColor = SystemColors.Window;
            dateLabel.Location = new Point(199, 50);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(52, 25);
            dateLabel.TabIndex = 2;
            dateLabel.Text = "Date";
            // 
            // chatMesgBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 0);
            Controls.Add(chatMesgLayoutPanel);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(0, 75);
            Name = "chatMesgBox";
            Size = new Size(254, 75);
            chatMesgLayoutPanel.ResumeLayout(false);
            chatMesgLayoutPanel.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TableLayoutPanel chatMesgLayoutPanel;
        private Label userLabel;
        private Label dateLabel;
        private Panel panel1;
        private TextBox messageTextBox;
    }
}
