using System;

namespace App.Configuration
{
    public class ConfigsLoader
    {
        private readonly IEnvVarReader _reader;
        public ConfigsLoader()
        {
            _reader = new EnvVarReader();
        }

        public Configs Load()
        {
            var configs = new Configs();
            var port = _reader.Get(EnvVars.Port);
            if (!string.IsNullOrEmpty(port))
            {
                configs.Port = Convert.ToInt32(port);
            }

            return configs;
        }
    }
}
