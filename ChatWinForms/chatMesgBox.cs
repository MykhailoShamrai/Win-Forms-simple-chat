﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ChatWinForms
{
    public partial class chatMesgBox : UserControl
    {
        private int radius = 20;
        [DefaultValue(20)]
        public int Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                this.RecreateRegion();
            }
        }

        private string date;
        public string Date
        {
            get { return date; }
            set
            {
                date = value;
                this.dateLabel.Text = date;
            }
        }
        private string user;
        public string User
        {
            get { return user; }
            set
            {
                user = value;
                this.userLabel.Text = user;

            }
        }
        private string message;
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                messageTextBox.Text = message;
                changeSizeAccordingToText();
            }
        }

        public chatMesgBox()
        {
            InitializeComponent();
            changeSizeAccordingToText();
        }
        //https://stackoverflow.com/questions/32987649/how-to-create-a-user-control-with-rounded-corners
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private GraphicsPath GetRoundRectagle(Rectangle bounds, int radius)
        {
            float r = radius;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(bounds.Left, bounds.Top, r, r, 180, 90);
            path.AddArc(bounds.Right - r, bounds.Top, r, r, 270, 90);
            path.AddArc(bounds.Right - r, bounds.Bottom - r, r, r, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - r, r, r, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void RecreateRegion()
        {
            var bounds = ClientRectangle;
            this.Region = Region.FromHrgn(CreateRoundRectRgn(bounds.Left, bounds.Top,
                bounds.Right, bounds.Bottom, Radius, radius));
            this.Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.RecreateRegion();
        }

        //https://stackoverflow.com/questions/8361555/why-doesnt-textrenderer-measuretext-work-properly
        void changeSizeAccordingToText()
        {
            int lineCount = messageTextBox.GetLineFromCharIndex(messageTextBox.TextLength) + 1;
            Height = Height - messageTextBox.Height + lineCount * messageTextBox.Font.Height;
            messageTextBox.Height = lineCount * messageTextBox.Font.Height;
        }



        private void chatMesgLayoutPanel_SizeChanged(object sender, EventArgs e)
        {
            changeSizeAccordingToText();
        }
    }
}
