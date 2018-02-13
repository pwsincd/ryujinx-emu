using Discord.Commands;
using Discord;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Discord.WebSocket;

namespace RyuBot.Modules
{
    public class About : ModuleBase<SocketCommandContext>
    {
        string cd = System.IO.Directory.GetCurrentDirectory();
        string time = DateTime.Now.ToString();

        [Command("About")]

        public async Task SendAbout()
        {

            var messages = await this.Context.Channel.GetMessagesAsync(1).Flatten();
            await this.Context.Channel.DeleteMessagesAsync(messages);
            await Context.Channel.SendMessageAsync("=====================================" +
                "\r\nDr.Hackniks RyujiNX Bot for Discord" +
                "\r\nVersion:: 0.1.3" +
                "\r\nBot name: OpenBot" +
                "\r\nBot revision: 18_2_11_1232pm" +
                "\r\nBot Type: win10-x64 | Web-socket-based" +
                "\r\n=====================================");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(time + ":: Command Request: !about; " + "ID <" + Context.User.Id.ToString() + "> " +
                "\r\nUsername: <" + Context.User.Username.ToString() + ">" + " Channel ID: <" + Context.Channel.Id + ">");
        }
    }
}
