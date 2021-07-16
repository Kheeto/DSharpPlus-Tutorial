using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;

namespace DSharpPlusTutorial.Comandi.Utilità
{
    public class RipetiComando : BaseCommandModule
    {
        [Command("ripeti")]
        [Description("Ripete quello che è stato scritto dall'utente dopo aver eseguito il comando")]
        public async Task Comando(CommandContext context)
        {
            await context.Message.DeleteAsync();
            DiscordMessage messaggioIniziale = await context.Channel.SendMessageAsync("Ora scrivi, entro 60 secondi, qualcosa che ripeterò.");

            var messaggioRicevuto = await context.Client.GetInteractivity().WaitForMessageAsync(msg => msg.Channel == context.Channel).ConfigureAwait(false);

            if (!messaggioRicevuto.TimedOut)
            {
                await context.Channel.SendMessageAsync(messaggioRicevuto.Result.Content);
                await messaggioRicevuto.Result.DeleteAsync();
            } else
            {
                await context.Channel.SendMessageAsync("Non hai scritto niente in 60 secondi. Comando Cancellato.");
            }

            await messaggioIniziale.DeleteAsync();
        }
    }
}
