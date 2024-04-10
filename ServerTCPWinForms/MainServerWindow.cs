using System.ComponentModel;

namespace ServerTCPWinForms
{
    public partial class MainServerWindow : Form
    {
        public BindingList<ClientsInformation> list;
        public MainServerWindow()
        {
            InitializeComponent();
            list = new BindingList<ClientsInformation>();
            //list.Add(new ClientsInformation(1, "user"));
            //dataGridView.DataSource = list;
        }
    }
}
