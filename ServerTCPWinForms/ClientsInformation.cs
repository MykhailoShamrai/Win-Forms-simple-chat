using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatWinForms;

namespace ServerTCPWinForms
{
    /// <summary>
    /// Class that contains client and id with name of user.
    /// </summary>
    public class ClientsInformation
    {
        private Client client;
        public int ID { get; set; }
        public string Name { get; set; }
        
        public ClientsInformation(int id, string name, Client client)
        {
            ID = id;
            Name = name;
            this.client = client;
        }
        
        public Client GetClient()
        {
            return client;
        }
    }
}
