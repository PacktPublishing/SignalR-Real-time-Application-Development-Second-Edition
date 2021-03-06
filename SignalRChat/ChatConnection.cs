﻿using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace SignalRChat
{
    public class ChatConnection : PersistentConnection
    {
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            return Connection.Broadcast(data);
        }
    }
}
