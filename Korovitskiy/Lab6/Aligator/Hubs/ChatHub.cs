using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aligator.Hubs
{
    public class ChatHub : Hub
    {
        public async Task Send(string message, string groupsId)
        {
            if (string.IsNullOrEmpty(groupsId))
                return;

            var isRight = GameHub.CheckWord(message, groupsId);
            await this.Clients.All.SendAsync("Send", message, isRight);
        }
    }
}
