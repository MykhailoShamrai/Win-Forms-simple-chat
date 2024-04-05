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
            textBox1 = new TextBox();
            buttonSend = new Button();
            chatLayoutPanel1 = new TableLayoutPanel();
            chatLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(3, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(276, 27);
            textBox1.TabIndex = 0;
            // 
            // buttonSend
            // 
            buttonSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSend.Location = new Point(285, 3);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(94, 26);
            buttonSend.TabIndex = 1;
            buttonSend.Text = "Send";
            buttonSend.UseVisualStyleBackColor = true;
            // 
            // chatLayoutPanel1
            // 
            chatLayoutPanel1.ColumnCount = 2;
            chatLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            chatLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            chatLayoutPanel1.Controls.Add(textBox1, 0, 0);
            chatLayoutPanel1.Controls.Add(buttonSend, 1, 0);
            chatLayoutPanel1.Dock = DockStyle.Bottom;
            chatLayoutPanel1.Location = new Point(0, 521);
            chatLayoutPanel1.Name = "chatLayoutPanel1";
            chatLayoutPanel1.RowCount = 1;
            chatLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            chatLayoutPanel1.Size = new Size(382, 32);
            chatLayoutPanel1.TabIndex = 2;
            // 
            // MainChatWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 553);
            Controls.Add(chatLayoutPanel1);
            MinimumSize = new Size(320, 480);
            Name = "MainChatWindow";
            Text = "Group Chat";
            chatLayoutPanel1.ResumeLayout(false);
            chatLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox1;
        private Button buttonSend;
        private TableLayoutPanel chatLayoutPanel1;
    }
}
