
using SimpleInjector;
using Xamarin.Forms;

namespace SignalRChat.Mobile
{
    public partial class ChatRooms : ContentPage
    {
        public ChatRooms()
        {
            InitializeComponent();

            BindingContext = App.Container.GetInstance<ChatRoomsViewModel>();
        }
    }
}
