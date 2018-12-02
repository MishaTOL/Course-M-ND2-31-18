using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab6Crocodile.Hubs
{
    public class ChatHub : Hub
    {
        public async Task Send(string Name, string message)
        {
            await this.Clients.All.SendAsync("Send", Name, message);
        }
    }
}
