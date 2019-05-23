using System.Threading.Tasks;
using App.Configuration;
using App.Net;

namespace App
{
    public class Start
    {
        private readonly UdpListener _udpListener;
        private readonly ConfigsLoader _configsLoader;
        
        public Start(Logger logger)
        {
            _configsLoader = new ConfigsLoader();
            _udpListener = new UdpListener();
        }
        public async Task GoAsync()
        {
            var configs = _configsLoader.Load();
            await _udpListener.StartListenerAsync(configs.Port);
        }
    }
}