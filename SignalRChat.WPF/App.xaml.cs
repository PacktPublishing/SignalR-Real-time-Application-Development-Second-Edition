using System.Windows;
using Bifrost.Configuration;

namespace SignalRChat.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Configure.DiscoverAndConfigure();
        }
    }
}
