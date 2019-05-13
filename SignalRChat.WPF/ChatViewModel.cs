using System;
using System.Collections.ObjectModel;
using System.Windows;
using PropertyChanged;

namespace SignalRChat.WPF
{
    [ImplementPropertyChanged]
    public class ChatViewModel
    {
        IChatHub _chatHub;

        public ChatViewModel(IChatHub chatHub)
        {
            _chatHub = chatHub;
            CurrentState = "Disconnected";

            Messages = new ObservableCollection<string>();

            chatHub.StateChanged += (stateChange) => CurrentState = stateChange.NewState.ToString();
            chatHub.JoinedRoom += (room) =>
            {
                Application.Current.Dispatcher.BeginInvoke((Action)(() => 
                {
                    CurrentRoom = room;
                    Messages.Clear();
                    Messages.Add("Joined : " + room);
                }));
            };

            chatHub.MessageReceived += (message) => Application.Current.Dispatcher.BeginInvoke((Action)(() => Messages.Add(message)));
        }

        public string CurrentRoom { get; private set; }
        public string CurrentState { get; private set; }

        public ObservableCollection<string> Messages { get; private set; }

        public void Send(string message)
        {
            _chatHub.Send(message);
        }
    }
}
