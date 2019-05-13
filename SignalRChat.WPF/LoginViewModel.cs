using Bifrost.Messaging;
using PropertyChanged;

namespace SignalRChat.WPF
{
    [ImplementPropertyChanged]
    public class LoginViewModel
    {
        IMessenger _messenger;
        ISecurity _security;

        public LoginViewModel(IMessenger messenger, ISecurity security)
        {
            _messenger = messenger;
            _security = security;
        }

        public string UserName { get; set; }
        public string Password { get; set; }

        public void SignIn()
        {
            if (_security.Authenticate(UserName, Password))
            {
                _messenger.Publish(new LoggedIn());
            }
        }
    }
}
