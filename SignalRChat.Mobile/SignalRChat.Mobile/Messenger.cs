using System;
using System.Collections.Generic;

namespace SignalRChat.Mobile
{
    public class Messenger : IMessenger
    {
        Dictionary<Type, List<Delegate>> _subscribers = new Dictionary<Type, List<Delegate>>();

        public void Publish<T>(T content)
        {
            var type = typeof(T);
            if (_subscribers.ContainsKey(type))
            {
                var forRemoval = new List<Delegate>();

                foreach (var subscriber in _subscribers[type])
                {
                    subscriber.DynamicInvoke(content);
                }
            }
        }

        public void SubscribeTo<T>(Action<T> receivedCallback)
        {
            var type = typeof(T);
            List<Delegate> subscribersList = null;
            if (_subscribers.ContainsKey(type))
                subscribersList = _subscribers[type];
            else
            {
                subscribersList = new List<Delegate>();
                _subscribers[type] = subscribersList;
            }
            subscribersList.Add(receivedCallback);
        }
    }
}
