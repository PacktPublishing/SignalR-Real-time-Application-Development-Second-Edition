using Bifrost.Configuration;

namespace SignalRChat.WPF
{
    public class Configurator : ICanConfigure
    {
        public void Configure(IConfigure configure)
        {
            configure.Frontend.Desktop();
        }
    }
}
