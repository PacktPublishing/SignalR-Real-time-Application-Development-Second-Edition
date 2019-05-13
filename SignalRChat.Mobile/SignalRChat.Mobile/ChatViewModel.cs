using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
namespace SignalRChat.Mobile
{
    public class ChatViewModel
    {
        IChatHub _chatHub;

        public ChatViewModel(string room, IChatHub chatHub)
        {
            Room = room;
            _chatHub = chatHub;
            Messages = new ObservableCollection<string>();

            SendCommand = DelegateCommand.Create(Send);

            chatHub.MessageReceived += (message) => Device.BeginInvokeOnMainThread(() => Messages.Add(message));
        }

        public string Room { get; private set; }
        public string Message { get; set; }
        public ICommand SendCommand { get; private set; }

        public ObservableCollection<string> Messages { get; private set; }

        public void Send()
        {
            _chatHub.Send(Message);
        }
    }
}
