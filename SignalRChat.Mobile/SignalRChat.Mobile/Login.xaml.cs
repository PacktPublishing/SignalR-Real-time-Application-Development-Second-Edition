
using Xamarin.Forms;

namespace SignalRChat.Mobile
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();

            var security = App.Container.GetInstance<ISecurity>();
            var messenger = App.Container.GetInstance<IMessenger>();
            var viewModel = new LoginViewModel(Navigation, security, messenger);
            BindingContext = viewModel;
        }
    }
}
