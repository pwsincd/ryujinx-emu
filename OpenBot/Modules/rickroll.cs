using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RyuBot.Modules
{
    public class rick : ModuleBase<SocketCommandContext>
    {
        string time = DateTime.Now.ToString();
        [Command("RickRoll")]
        public async Task rck(SocketGuildUser user)
        {
            await Context.Channel.SendMessageAsync(user.Mention + "\r\n**Get Rick Roll'd mate!** \r\nhttps://www.youtube.com/watch?v=oHg5SJYRHA0");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(time + ":: Command Request: !rickroll; " + "ID <" + Context.User.Id.ToString() + "> " +
                "\r\nUsername: <" + Context.User.Username.ToString() + "> Channel ID: <" + Context.Channel.Id + "> Mentioned user: " + "<" + user.Mention + ">");
        }
    }
}
