namespace App.Messages
{
    public class DNS
    {
        public short TransactionID { get; set; }

        public QR QR { get; set; }

        public OpCode OpCode { get; set; }
        public bool AuthoritativeAnswer { get; set; }
        public bool Truncated { get; set; }
        public bool RecursionDesired { get; set; }
        public bool RecursionAllowed { get; set; }
        /// <summary>
        /// Reserved
        /// </summary>
        public bool Z { get; set; }
        public bool AnswerAuthenticated { get; set; }
        public bool NonAuthenticatedData { get; set; }
        public ReplyCode ReplyCode { get; set; }
    }
}