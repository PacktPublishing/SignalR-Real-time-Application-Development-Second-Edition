using System;
using Microsoft.AspNet.SignalR.Client;

namespace SignalRChat.WPF
{
    public interface IChatHub
    {
        event Action<StateChange> StateChanged;
        event Action<string> JoinedRoom;
        event Action<string> RoomAdded;
        event Action<string> MessageReceived;

        string CurrentChatRoom { get; }
        void Join(string room);
        void CreateRoom(string room);
        void Send(string message);
    }
}
