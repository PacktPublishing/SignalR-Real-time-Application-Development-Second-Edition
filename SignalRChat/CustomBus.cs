using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Messaging;

namespace SignalRChat
{
    public class CustomBus : ScaleoutMessageBus
    {
        static ulong _messageId;

        public CustomBus(IDependencyResolver dependencyResolver, CustomBusConfiguration configuration) 
            : base(dependencyResolver, configuration)
        {
            Open(0);
        }
        
        protected override Task Send(int streamIndex, IList<Message> messages)
        {
            var scaleoutMessage = new ScaleoutMessage(messages);
            OnReceived(streamIndex, _messageId++, scaleoutMessage);
            return Task.FromResult(0);
        }
    }
}
