using System;
using System.Collections.Generic;
using Xunit;

namespace tests
{
    public class DNSQuery
    {

    }

    // https://www.frameip.com/dns/#1-8211-introduction-au-protocole-dns
    public class DNS
    {
        public short TransactionID { get; set; }

        /* Flags detail:
           - QR (1 bit)
           - OpCode (4 bits)
           - Aa (Authoritative Answer) (1 bit)
           - TC (1 bit)
           - RD (1 bit)
           - RA (1 bit)
           - Z (3 bits)
           - RCode (4 bits)
        */
        public short Flags { get; set; }
        public short Questions { get; set; }
        public short RRsAnswer { get; set; }
        public short RRsAuthority { get; set; }
        public short RRsAdditional { get; set; }

        public IEnumerable<DNSQuery> Queries { get; set; }
    }

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }
    }
}
