using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using App.Configuration;
using App.Features.GetUDPDataByte;

namespace App.Net
{
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
}