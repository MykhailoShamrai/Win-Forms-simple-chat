namespace ChatWinForms.Messages
{
    /// <summary>
    /// Class for message, that is send when client need to establish suthorisation with server.
    /// </summary>
    public class Authorization
    {
        public string Sender { get; set; }
        public string Key { get; set; }

        public Authorization(string sender, string key)
        {
            Sender = sender;
            Key = key;
        }
    }
}
