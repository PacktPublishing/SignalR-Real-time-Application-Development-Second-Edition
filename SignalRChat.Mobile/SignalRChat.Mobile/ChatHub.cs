using System;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Transports;

namespace SignalRChat.Mobile
{
    public class ChatHub : IChatHub
    {
        const string Site = "http://10.211.55.4:3705";

        public event Action<StateChange> StateChanged = (state) => { };
        public event Action<string> JoinedRoom = (room) => { };
        public event Action<string> RoomAdded = (room) => { };
        public event Action<string> MessageReceived = (message) => { };

        HubConnection _hubConnection;
        ISecurity _security;
        IHubProxy _chatProxy;

        public ChatHub(IMessenger messenger, ISecurity security)
        {
            _security = security;
            messenger.SubscribeTo<LoggedIn>(LoggedIn);
        }

        void LoggedIn(LoggedIn loggedIn)
        {
            _hubConnection = new HubConnection(Site);
            
            _hubConnection.CookieContainer = _security.CookieContainer;
            _hubConnection.StateChanged += (s) => StateChanged(s);

            _chatProxy = _hubConnection.CreateHubProxy("chat");
            _chatProxy.On("addMessage", (string message) => MessageReceived(message));
            _chatProxy.On("addChatRoom", (string room) => RoomAdded(room));

            CurrentChatRoom = "Lobby";
            JoinedRoom(CurrentChatRoom);

            _hubConnection.Start().Wait();
        }

        public void Join(string room)
        {
            _chatProxy.Invoke("Join", room).Wait();
            JoinedRoom(room);
        }

        public void CreateRoom(string room)
        {
            _chatProxy.Invoke("CreateChatRoom", room).Wait();
            JoinedRoom(room);
        }

        public void Send(string message)
        {
            _chatProxy.Invoke("Send", message);
        }

        public string CurrentChatRoom
        {
            get { return (string)_chatProxy["currentChatRoom"]; }
            private set { _chatProxy["currentChatRoom"] = value; }
        }
    }
}