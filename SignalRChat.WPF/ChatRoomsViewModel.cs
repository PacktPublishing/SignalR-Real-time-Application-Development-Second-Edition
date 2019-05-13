using System;
using System.Collections.ObjectModel;
using System.Windows;
using PropertyChanged;

namespace SignalRChat.WPF
{
    [ImplementPropertyChanged]
    public class ChatRoomsViewModel
    {
        IChatHub _chatHub;
        string _currentRoom;

        public ChatRoomsViewModel(IChatHub chatHub)
        {
            _chatHub = chatHub;
            _currentRoom = "Lobby";

            Rooms = new ObservableCollection<string>();

            chatHub.RoomAdded += (room) => Application.Current.Dispatcher.BeginInvoke((Action)(() => Rooms.Add(room)));
        }

        public ObservableCollection<string> Rooms { get; private set; }

        public string CurrentRoom
        {
            get { return _currentRoom; }
            set
            {
                _currentRoom = value;
                _chatHub.Join(value);
            }
        }

        public void AddRoom(string room)
        {
            _chatHub.CreateRoom(room);
        }
    }
}
