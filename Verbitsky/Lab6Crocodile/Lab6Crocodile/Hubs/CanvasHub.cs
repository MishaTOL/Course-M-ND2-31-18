using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab6Crocodile.Hubs
{
    public class CanvasHub : Hub
    {
        public async Task MouseDown(int x, int y)
        {
            await this.Clients.All.SendAsync("MouseDown", x, y);
        }
        public async Task MouseMove(int x, int y)
        {
            await this.Clients.All.SendAsync("MouseMove", x, y);
        }
        public async Task MouseUp(int x, int y)
        {
            await this.Clients.All.SendAsync("MouseUp", x, y);
        }
    }
}
