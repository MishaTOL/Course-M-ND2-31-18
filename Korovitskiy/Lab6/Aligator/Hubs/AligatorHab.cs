using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Aligator.Hubs
{
    public class AligatorHab : Hub
    { 
        public async Task Send(int x, int y)
        {
            await this.Clients.All.SendAsync("Drow", x, y);
        }
    }
}
