using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;
using Xunit;

namespace tests
{
    public enum QR : byte
    {
        Query = 0,
        Response = 1
    }

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

    // https://www.frameip.com/dns/#1-8211-introduction-au-protocole-dns
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

    public class DNSQuery

    {
    }

    public class GetUdpDataRequest
    {
        public byte[] Buffer { get; set; }
    }

    public class GetUdpDataHandler
    {
        public void Handle(GetUdpDataRequest request)
        {
            var bytes = request.Buffer;

            var flags = new BitArray(new[] { bytes[2], bytes[3] });
            var opCode = Convert.ToByte(flags[1]) * 8 +
                         Convert.ToByte(flags[2]) * 4 +
                         Convert.ToByte(flags[3]) * 2 +
                         Convert.ToByte(flags[4]);

            var replyCode = Convert.ToByte(flags[12]) * 8 +
                            Convert.ToByte(flags[13]) * 4 +
                            Convert.ToByte(flags[14]) * 2 +
                            Convert.ToByte(flags[15]);

            var dns = new DNS()
            {
                TransactionID = BitConverter.ToInt16(bytes, 0),
                QR = flags[0] == false ? QR.Query : QR.Response,
                OpCode = (OpCode) opCode,
                AuthoritativeAnswer = flags[5],
                Truncated = flags[6],
                RecursionDesired = flags[7],
                RecursionAllowed = flags[8],
                Z = flags[9],
                AnswerAuthenticated = flags[10],
                NonAuthenticatedData = flags[11],
                ReplyCode = (ReplyCode) replyCode
            };
        }
    }

    public class UdpListener
    {
        public async Task StartListenerAsync(int listenPort, int millisecondsDelay = 0)
        {
            var listener = new UdpClient(listenPort);
            var handler = new GetUdpDataHandler();

            try
            {
                while (true)
                {
                    var received = await listener.ReceiveAsync();

                    handler.Handle(new GetUdpDataRequest()
                    {
                        Buffer = received.Buffer
                    });
                    
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
        public async Task Test1()
        {
            var listener = new UdpListener();
            await listener.StartListenerAsync(53, 1000);
        }
    }
}
