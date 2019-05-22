using System;
using Xunit;

namespace tests
{
    public class DNSMessageQuery
    {
        public short TransactionID { get; set; }
        public short Flags { get; set; }
        public short Questions { get; set; }
        public short RRsAnswer { get; set; }
        public short RRsAuthority { get; set; }
        public short RRsAdditional { get; set; }

        // public Queries Queries { get; set; }
    }

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }
    }
}
