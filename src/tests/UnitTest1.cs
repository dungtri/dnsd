using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
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


    public class UdpListener
    {
        private async static Task StartListenerAsync(int listenPort, int millisecondsDelay = 0)
        {
            UdpClient listener = new UdpClient(listenPort);
            
            try
            {
                while (true)
                {
                    var received = await listener.ReceiveAsync();
                    var dns = new DNS()
                    {
                        TransactionID = BitConverter.ToInt16(received.Buffer, 0),
                    };



                    await Task.Delay(millisecondsDelay);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                listener.Close();
            }
        }
    }

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            UdpListener listener = 

        }
    }
}
