namespace App.Messages
{
    public enum OpCode : byte
    {
        /// <summary>
        /// Standard query
        /// </summary>
        Query = 0,
        /// <summary>
        /// Inverted query
        /// </summary>
        IQuery = 1,
        /// <summary>
        /// Server status
        /// </summary>
        Status = 2,
        Reserved3 = 3,
        Reserved4 = 4,
        Reserved5 = 5,
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