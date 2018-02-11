using Discord.Commands;
using Discord;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RyuBot.Modules
{
    public class DeleteMessages : ModuleBase<SocketCommandContext>
    {
        string cd = System.IO.Directory.GetCurrentDirectory();
        string time = DateTime.Now.ToString();
        [Command("Delete")]

        public async Task Delete_messages([Remainder]uint count)
        {

            var messages = await this.Context.Channel.GetMessagesAsync((int)count + 1).Flatten();
            await this.Context.Channel.DeleteMessagesAsync(messages);
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(time + ":: Command Request: !delete; " + "ID <" + Context.User.Id.ToString() + "> " +
                "\r\nUsername: <" + Context.User.Username.ToString() + ">" + " Channel ID: <" + Context.Channel.Id + ">" + " Value: " + count);
        }
    }
}
