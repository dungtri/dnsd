namespace App.Messages
{
    public enum ReplyCode : byte
    {
        NoError = 0,
        RequestFormat = 1,
        ServerError = 2,
        DomainNameNotFound = 3,
        NotImplemented = 4,
        Reject = 5,
        Reserved6 = 6,
        Reserved7 = 7,
        Reserved8 = 8,
        Reserved9 = 9,
        Reserved10 = 10,
        Reserved11 = 11,
        Reserved12 = 12,
        Reserved13 = 13,
        Reserved14 = 14,
        Reserved15 = 15
    }
}