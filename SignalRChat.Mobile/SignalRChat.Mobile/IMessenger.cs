using System;

namespace SignalRChat.Mobile
{
    public interface IMessenger
    {
        void Publish<T>(T content);
        void SubscribeTo<T>(Action<T> receivedCallback);
    }
}
