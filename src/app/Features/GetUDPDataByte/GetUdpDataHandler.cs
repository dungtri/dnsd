using System;
using System.Collections;
using App.Messages;

namespace App.Features.GetUDPDataByte
{
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
}