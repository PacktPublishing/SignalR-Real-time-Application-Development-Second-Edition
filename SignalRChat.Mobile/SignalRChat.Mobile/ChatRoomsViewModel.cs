using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SignalRChat.Mobile
{
    public class ChatRoomsViewModel
    {
        string _currentRoom;
        INavigation _navigation;
        IChatHub _chatHub;

        public ChatRoomsViewModel(INavigation navigation, IChatHub chatHub)
        {
            _navigation = navigation;
            _chatHub = chatHub;
            Rooms = new ObservableCollection<string>();

            chatHub.RoomAdded += (room) => Device.BeginInvokeOnMainThread(() => Rooms.Add(room));

            AddRoomCommand = DelegateCommand.Create(AddRoom);
        }

        public string CurrentRoom 
        {
            get { return _currentRoom; }
            set
            {
                _currentRoom = value;
                _chatHub.Join(value);
                _navigation.PushAsync(new Chat(value));
            }
        }

        public ObservableCollection<String> Rooms { get; private set; }

        public ICommand AddRoomCommand { get; private set; }

        public string Room { get; set; }

        public void AddRoom()
        {
            _chatHub.CreateRoom(Room);
        }
    }
}