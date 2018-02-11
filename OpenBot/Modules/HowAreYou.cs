using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RyuBot.Modules
{
    public class HowAreYou : ModuleBase<SocketCommandContext>
    {
        string cd = AppDomain.CurrentDomain.BaseDirectory; 

        [Command("HowAreYou")]
        public async Task How_Are_You(SocketGuildUser user)
        {
            var messages = await this.Context.Channel.GetMessagesAsync(1).Flatten();
            await this.Context.Channel.DeleteMessagesAsync(messages);
            await Context.Channel.SendMessageAsync("How are you " + user.ToString() + "?");
        }
    }
}
