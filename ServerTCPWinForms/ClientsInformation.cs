using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTCPWinForms
{
    public class ClientsInformation
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        
        public ClientsInformation(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
