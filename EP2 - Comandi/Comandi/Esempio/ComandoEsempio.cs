using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace DSharpPlusTutorial.Comandi.Esempio
{
    public class ComandoEsempio : BaseCommandModule
    {
        [Command("esempio")]
        [Description("Comando Esempio")]
        public async Task Comando(CommandContext context)
        {
            await context.RespondAsync("Risposta Esempio");
            await context.Channel.SendMessageAsync("Messaggio Esempio");
        }
    }
}
