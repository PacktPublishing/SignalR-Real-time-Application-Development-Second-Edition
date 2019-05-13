using System;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Messaging;

namespace SignalRChat
{
    public static class DependencyResolverExtensions
    {
        public static IDependencyResolver UseCustom(this IDependencyResolver resolver)
        {
            var bus = new Lazy<CustomBus>(() => new CustomBus(resolver, new CustomBusConfiguration()));
            resolver.Register(typeof(IMessageBus), () => bus.Value);

            return resolver;
        }
    }
}
