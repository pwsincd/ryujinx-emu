using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RyuBot.Modules
{
    public class CommandHandler
    {
        private DiscordSocketClient _client;
        private CommandService _service;
        string time = DateTime.Now.ToString(); 
        public CommandHandler(DiscordSocketClient client)
        {
            _client = client;
            _service = new CommandService();
            _service.AddModulesAsync(Assembly.GetEntryAssembly());
            _client.MessageReceived += handlecommandasync; 
        }
        private async Task handlecommandasync(SocketMessage s)
        {
            var msg = s as SocketUserMessage;
            if (msg == null) return;
            int argPos = 0;
            var context = new SocketCommandContext(_client, msg); 

            if (msg.HasCharPrefix('!', ref argPos))
            {
                var result = await _service.ExecuteAsync(context, argPos);
                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    await context.Channel.SendMessageAsync(result.ErrorReason);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(time + ":ERROR: The command requested was invalid; or the incorrect syntax."); 
                }
            }
        }
    }
}
