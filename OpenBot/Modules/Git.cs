using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RyuBot.Modules
{
    public class Git : ModuleBase<SocketCommandContext>
    {
        string time = DateTime.Now.ToString(); 
        [Command("Git")]
        public async Task git()
        {
            var messages = await this.Context.Channel.GetMessagesAsync(1).Flatten();
            await this.Context.Channel.DeleteMessagesAsync(messages);
            await Context.Channel.SendMessageAsync("This command is not ready yet.");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(time + ":ERROR: Command Request: !git; " + "ID <" + Context.User.Id.ToString() + "> " +
                "\r\nUsername: <" + Context.User.Username.ToString() + ">" + " Channel ID: <" + Context.Channel.Id + ">");
        }
    }
}
