using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;

namespace DSharpPlusTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Bot bot = new Bot();
            bot.EseguiBot().GetAwaiter().GetResult();
        }
    }

    public class Bot
    {
        public DiscordClient Client { get; private set; }

        public async Task EseguiBot()
        {
            DiscordConfiguration configBot = new DiscordConfiguration
            {
                Token = "INSERIRE IL TOKEN DEL BOT QUI",
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Debug,
            };

            Client = new DiscordClient(configBot);

            Client.Ready += OnReady;

            await Client.ConnectAsync();

            await Task.Delay(-1);
        }

        private Task OnReady(object sender, ReadyEventArgs ev)
        {
            Console.WriteLine("Bot Avviato");
            return Task.CompletedTask;
        }
    }
}
