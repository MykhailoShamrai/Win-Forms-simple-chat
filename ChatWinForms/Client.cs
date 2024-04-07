using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatWinForms
{
    public class Client
    {
        Thread checkConnectionThread;
        private StreamReader? StreamReader;
        private StreamWriter? StreamWriter;

        private TcpClient? tcpClient;
        private string? _userName;
        public string? UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        private string? _password;
        public string? Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string? address = null;
        private string? port = null;

        public Client()
        {
            _userName = null;
            _password = null;
            checkConnectionThread = new Thread(ReadOnThread);
        }
        
        public void setClientsParameters(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }
        /// <summary>
        /// Event on connecting with server
        /// </summary>
        public event Action? Connected;
        public void OnConnected()
        {
            Connected!.Invoke();
        }

        /// <summary>
        /// Event on disconnection with server
        /// </summary>
        public event Action? Disconnected;

        public void OnDisconnected()
        {
            Disconnected!.Invoke();
        }


        /// <summary>
        /// One solid function for connection and authorizing routine
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        public void ConnectToServer (string address, string port)
        { 
            bool isLoopback = (address == "127.0.0.1" || address == "localhost");
            address = isLoopback ? "127.0.0.1" : address;

            // Trying to connect
            try
            {
                tcpClient = new TcpClient(address, int.Parse(port));
            }
            catch (Exception ex)
            {
                address = null;
                port = null;
                MessageBox.Show(ex.Message);
                return;
            }
            this.address = address;
            this.port = port;

            StreamWriter = new StreamWriter(tcpClient.GetStream());
            StreamWriter.AutoFlush = true;
            StreamReader = new StreamReader(tcpClient.GetStream());
            AskAuthorization();
            if (CheckAuthorization())
            {
                OnConnected();
                checkConnectionThread.Start();
                
                return;
            }
            else
            {
                MessageBox.Show("Unable to authorize");
                EndOfWork();
                return;
            }
        }

        private void SendRequest(string message)
        {
           if (StreamWriter != null)
           {
               StreamWriter.WriteLine(message);
           }
           else
           {
                return;
           }
        }


        private string? HaveAnAnswer()
        {
            if (StreamReader != null)
            {

                string res = StreamReader.ReadLine()!;
                return res;
            }
            else
            {
                return null;
            }
        }

        private void AskAuthorization()
        {
            ChatWinForms.Messages.Authorization authorization = new ChatWinForms.Messages.Authorization(UserName, Password);
            string mes = JsonSerializer.Serialize(authorization);
            SendRequest(mes);
        }

        private bool CheckAuthorization()
        {
            string? autStr = HaveAnAnswer();
            if (autStr != null)
            {
                ChatWinForms.Messages.Message msg = JsonSerializer.Deserialize<ChatWinForms.Messages.Message>(autStr)!;
                return (msg.Text == ChatWinForms.Messages.Message.Authorized);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method for clearing streams, tcp clients and all variables;
        /// </summary>
        private void EndOfWork()
        {
            if (StreamWriter != null)
            {
                StreamWriter.Close();
            }
            if (StreamReader != null)
            {
                StreamReader.Close();
            }
            if (tcpClient != null)
            {
                tcpClient.Close();
            }
            //OnConnectionFormDisPose();
        }

        //private void CheckConnection()
        //{
        //    while (true)
        //    {
        //        if (!tcpClient!.Connected)
        //        {
        //            OnDisconnected();
        //            return;
        //        }
        //    }
        //}

        private void ReadOnThread()
        {
            bool disconnected = false;

            while (!disconnected)
            {
                string str = StreamReader!.ReadLine()!;
                if (str == null)
                    disconnected = true;   
            }
            OnDisconnected();
            EndOfWork();
        }
    }
}
