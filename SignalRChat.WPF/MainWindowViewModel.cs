using Bifrost.Messaging;
using PropertyChanged;

namespace SignalRChat.WPF
{
    [ImplementPropertyChanged]
    public class MainWindowViewModel
    {
        public MainWindowViewModel(IMessenger messenger)
        {
            messenger.SubscribeTo<LoggedIn>(m => LoggedIn = true);
        }

        public bool LoggedIn { get; private set; }
    }
}
