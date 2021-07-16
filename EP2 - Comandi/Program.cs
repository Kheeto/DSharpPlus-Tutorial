using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;
using DSharpPlusTutorial.Comandi.Esempio;
using DSharpPlusTutorial.Comandi.Utilità;

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
        public CommandsNextExtension Commands { get; private set; }

        public async Task EseguiBot()
        {
            DiscordConfiguration configBot = new DiscordConfiguration
            {
                Token = "INSERITE QUI IL TOKEN",
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Debug,
            };

            Client = new DiscordClient(configBot);

            Client.Ready += OnReady;

            CommandsNextConfiguration configComandi = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { "!" },
                EnableDms = false,
                EnableDefaultHelp = true,
                EnableMentionPrefix = true,
            };

            Commands = Client.UseCommandsNext(configComandi);

            RegistraComandi();

            await Client.ConnectAsync();

            await Task.Delay(-1);
        }

        void RegistraComandi()
        {
            Commands.RegisterCommands<ComandoEsempio>();
            Commands.RegisterCommands<SayComando>();
        }

        private Task OnReady(object sender, ReadyEventArgs ev)
        {
            DiscordActivity attivita = new DiscordActivity
            {
                ActivityType = ActivityType.Watching,
                Name = "Tutorial di Kheeto",
            };
            Client.UpdateStatusAsync(attivita, UserStatus.DoNotDisturb);
            Console.WriteLine("Bot Avviato");
            return Task.CompletedTask;
        }
    }
}
