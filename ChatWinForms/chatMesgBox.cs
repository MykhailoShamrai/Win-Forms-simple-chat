using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace ChatWinForms
{
    /// <summary>
    /// Window that contains text of a message, date and username. 
    /// </summary>
    public partial class chatMesgBox : UserControl
    {
        /// <summary>
        /// Radius of rounded corners.
        /// </summary>
        private int radius = 20;
        [DefaultValue(20)]
        public int Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                RecreateRegion();
            }
        }

        private string? date = null;
        public string? Date
        {
            get { return date; }
            set
            {
                date = value;
                dateLabel.Text = date;
            }
        }
        private string? user = null;
        public string? User
        {
            get { return user; }
            set
            {
                user = value;
                userLabel.Text = user;

            }
        }
        private string? message = null;
        public string? Message
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
            Region = Region.FromHrgn(CreateRoundRectRgn(bounds.Left, bounds.Top,
                bounds.Right, bounds.Bottom, Radius, radius));
            Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
           base.OnSizeChanged(e);
           RecreateRegion();
        }

        //https://stackoverflow.com/questions/8361555/why-doesnt-textrenderer-measuretext-work-properly
        /// <summary>
        /// Private method, that will be called on changing the size of a window.  
        /// </summary>
        private void changeSizeAccordingToText()
        {
            // Finding the number of lines.
            int lineCount = messageTextBox.GetLineFromCharIndex(messageTextBox.TextLength) + 1;
            // Changing height of a control textBox and whole window.
            Height = Height - messageTextBox.Height + lineCount * messageTextBox.Font.Height;
            messageTextBox.Height = lineCount * messageTextBox.Font.Height;
        }

        /// <summary>
        /// Method that is a response on event for changed size of textBox of yhis window.
        /// </summary>
        /// <param name="sender">Sender of an event</param>
        /// <param name="e">Arguments of an event</param>
        private void chatMesgLayoutPanel_SizeChanged(object sender, EventArgs e)
        {
            changeSizeAccordingToText();
        }
    }
}
