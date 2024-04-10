using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTCPWinForms
{
    internal class Database
    {
        public static SemaphoreSlim semaphore = new SemaphoreSlim(1);
        static public BindingList<ClientsInformation> list = new BindingList<ClientsInformation>();
    }
}
