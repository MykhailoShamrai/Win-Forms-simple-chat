using System.ComponentModel;


namespace ServerTCPWinForms
{
    /// <summary>
    /// Class that contains BindingList for server window. List contains each client that is  
    /// </summary>
    internal class Database
    {
        public static SemaphoreSlim Semaphore = new SemaphoreSlim(1);
        static public BindingList<ClientsInformation> List = new BindingList<ClientsInformation>();
    }
}
