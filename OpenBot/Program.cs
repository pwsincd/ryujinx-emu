using System;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;
using RyuBot.Modules;
using System.IO;

namespace RyuBot
{
    public class Program
    {
        static void Main(string[] args)
        => new Program().StartAsync().GetAwaiter().GetResult(); 

        private DiscordSocketClient _client;

        private CommandHandler _handler;
        string cd = System.IO.Directory.GetCurrentDirectory();
        string time = DateTime.Now.ToString(); 


        public async Task StartAsync()
        {
            Console.WriteLine("=====================================" +
                "\r\nDr.Hackniks RyujiNX Bot for Discord" +
                "\r\nVersion: 0.1.3" +
                "\r\nBot name: OpenBot" +
                "\r\nBot revision: 18_2_11_1232pm" +
                "\r\nBot Type: win10-x64 | Web-socket-based" + 
                "\r\n=====================================");
            try
            {
                _client = new DiscordSocketClient();
                //Console.WriteLine(cd + "\\input.txt"); 
                _client = new DiscordSocketClient();
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.White;
                if (File.Exists(cd + "\\key"))
                {
                    Console.WriteLine(time + ":: Reading Key file...");
                    var key = File.ReadAllText(cd + "\\key");
                    Console.WriteLine(time + ":: Connecting...");
                    try
                    {
                        await _client.LoginAsync(TokenType.Bot, key);
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine(time + ":: Key file is valid");
                    }
                    catch
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine(time + ":ERROR: Key file is invalid! Or an internet connection is unavailable." +
                            "\r\n" + time + ":ERROR: There was an internal bot error.");
                        await Task.Delay(-1);
                        return;
                    }
                    
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(time + ":ERROR: There was an internal bot error." +
                        "\r\nPlease ensure that the `key` file is present. Or that the key is valid." +
                        "\r\nPlease restart the bot once the key is present.");
                    Console.BackgroundColor = ConsoleColor.Black;
                    await Task.Delay(-1);
                }
                await _client.StartAsync();
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(time + ":: Bot has connected");
                Log_Output();
                _handler = new CommandHandler(_client);
            }
            catch
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(time + ":ERROR: Unable to connect; or there was an internal bot error." + 
                    "\r\nPlease ensure you have a working internet connection!");
                Console.BackgroundColor = ConsoleColor.Black;
                Log_Output();
            }
            await Task.Delay(-1);
        }

        public void Log_Output()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(time + ":: Logging_Start ");
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(time + ":ERROR: Log event stopped. \r\nUNHANDLED_LOG_EVENT");
                Console.BackgroundColor = ConsoleColor.Black;
                break; 
            }
        }
    }
}
