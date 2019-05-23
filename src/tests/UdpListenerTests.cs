using System.Collections.Generic;
using System.Threading.Tasks;
using App.Net;
using Xunit;

namespace tests
{
    // https://www.frameip.com/dns/#1-8211-introduction-au-protocole-dns

    public class UdpListenerTests
    {
        [Fact]
        public async Task TestListener()
        {
            var listener = new UdpListener();
            await listener.StartListenerAsync(53, 1000);
        }
    }
}
