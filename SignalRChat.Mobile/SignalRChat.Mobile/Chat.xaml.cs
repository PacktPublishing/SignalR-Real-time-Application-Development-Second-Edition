
using Xamarin.Forms;

namespace SignalRChat.Mobile
{
    public partial class Chat : ContentPage
    {
        public Chat() : this("Unknown")
        {
        }

        public Chat(string room)
        {
            InitializeComponent();

            var chatHub = App.Container.GetInstance<IChatHub>();
            BindingContext = new ChatViewModel(room, chatHub);
        }
    }
}
