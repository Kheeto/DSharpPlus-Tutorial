using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace DSharpPlusTutorial.Comandi.Utilità
{
    public class SayComando : BaseCommandModule
    {
        [Command("say")]
        [Description("Ripete quello che è stato scritto dall'utente")]
        public async Task Comando(CommandContext context, [Description("Testo da Ripetere.")] params string[] args)
        {
            if(args.Length == 0)
            {
                await context.RespondAsync("Scrivi anche un testo da ripetere.");
                return;
            }
            string messaggio = null;
            foreach(string arg in args)
            {
                messaggio = messaggio + arg + " ";
            }
            await context.Channel.SendMessageAsync(messaggio);
            await context.Message.DeleteAsync();
        }
    }
}
