using System.Windows.Input;
using Xamarin.Forms;

namespace SignalRChat.Mobile
{
    public class LoginViewModel 
    {
        INavigation _navigation;
        ISecurity _security;
        IMessenger _messenger;

        public LoginViewModel(INavigation navigation, ISecurity security, IMessenger messenger)
        {
            _navigation = navigation;
            _security = security;
            _messenger = messenger;
            LoginCommand = DelegateCommand.Create(Login);
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand { get; private set; }

        public void Login()
        {
            if (_security.Authenticate(UserName, Password))
            {
                var navigationPage = new NavigationPage();
                App.Navigation = navigationPage.Navigation;
                navigationPage.PushAsync(new ChatRooms());
                
                _navigation.PushModalAsync(navigationPage);

                _messenger.Publish(new LoggedIn());
            }
        }
    }
}
