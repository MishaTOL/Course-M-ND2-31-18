using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aligator.Hubs
{
    public class GameHub : Hub
    {
        static ICollection<string> ConnectionIdForAddUser { get; set; }
        public static IDictionary<string, string> GroupAndWord { get; set; }
        static string GroupGuid { get; set; }
        private object obj = new object();

        public GameHub()
        {
            lock (obj)
            {
                if (GroupAndWord == null)
                {
                    GroupAndWord = new Dictionary<string, string>();
                }

                if (ConnectionIdForAddUser == null)
                {
                    ConnectionIdForAddUser = new List<string>();
                    GroupGuid = Guid.NewGuid().ToString();
                }
            }
        }

        public async Task AddNewGamer()
        {
            ConnectionIdForAddUser.Add(Context.ConnectionId);
            await this.Groups.AddToGroupAsync(Context.ConnectionId, GroupGuid);

            if (ConnectionIdForAddUser.Count >= 2)
            {
                await BeginGame();
            }
        }

        private async Task BeginGame()
        {
            await Clients.GroupExcept(GroupGuid, new List<string> { ConnectionIdForAddUser.First() }).SendAsync("StartGame", GroupGuid);
            await Clients.Client(ConnectionIdForAddUser.First()).SendAsync("StartGame", GroupGuid, true);
            ConnectionIdForAddUser = null;
        }

        public void ApplyWord(string groupId, string word)
        {
            GroupAndWord.Add(groupId, word);
        }

        public static bool CheckWord(string word, string groupsId)
        {
            if (!GroupAndWord.ContainsKey(groupsId))
            {
                return false;
            }
            return GroupAndWord[groupsId] == word;
        }
    }
}
