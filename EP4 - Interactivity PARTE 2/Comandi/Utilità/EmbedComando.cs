using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using static DSharpPlus.Entities.DiscordEmbedBuilder;

namespace DSharpPlusTutorial.Comandi.Utilità
{
    public class EmbedComando : BaseCommandModule
    {
        [Command("embed")]
        [Description("Comando per creare un embed personalizzato.")]
        public async Task Comando(CommandContext context)
        {
            string autore = null;
            string linkImmagine = null;

            DiscordEmbedBuilder embed = new DiscordEmbedBuilder()
            {

            };

            #region Titolo

            await context.Message.DeleteAsync();
            DiscordMessage messaggioTitolo = await context.Channel.SendMessageAsync("Ora scrivi, entro 60 secondi, il Titolo dell'Embed.");

            var titoloRicevuto = await context.Client.GetInteractivity().WaitForMessageAsync(msg => msg.Channel == context.Channel).ConfigureAwait(false);

            if (!titoloRicevuto.TimedOut)
            {
                embed.Title = titoloRicevuto.Result.Content;
                await titoloRicevuto.Result.DeleteAsync();
                await messaggioTitolo.DeleteAsync();
            }
            else
            {
                await context.Channel.SendMessageAsync("Non hai scritto niente in 60 secondi. Comando Cancellato.");
            }

            #endregion

            #region Descrizione

            DiscordMessage messaggioDescrizione = await context.Channel.SendMessageAsync("Ora scrivi, entro 60 secondi, la descrizione dell'Embed.");

            var descrizioneRicevuta = await context.Client.GetInteractivity().WaitForMessageAsync(msg => msg.Channel == context.Channel).ConfigureAwait(false);

            if (!descrizioneRicevuta.TimedOut)
            {
                embed.Description = descrizioneRicevuta.Result.Content;
                await descrizioneRicevuta.Result.DeleteAsync();
                await messaggioDescrizione.DeleteAsync();
            }
            else
            {
                await context.Channel.SendMessageAsync("Non hai scritto niente in 60 secondi. Comando Cancellato.");
            }

            #endregion

            #region Autore

            DiscordMessage messaggioAutore = await context.Channel.SendMessageAsync("Ora scrivi, entro 60 secondi, il nome dell'Autore.");

            var autoreRicevuto = await context.Client.GetInteractivity().WaitForMessageAsync(msg => msg.Channel == context.Channel).ConfigureAwait(false);

            if (!autoreRicevuto.TimedOut)
            {
                autore = autoreRicevuto.Result.Content;

                embed.Author = new EmbedAuthor() {
                    Name = autore
                };
                await autoreRicevuto.Result.DeleteAsync();
                await messaggioAutore.DeleteAsync();
            }
            else
            {
                await context.Channel.SendMessageAsync("Non hai scritto niente in 60 secondi. Comando Cancellato.");
            }

            #endregion

            #region ImmagineAutore

            DiscordMessage messaggioImgAutore = await context.Channel.SendMessageAsync("Ora manda, entro 60 secondi, il link dell'immagine dell'Autore.");

            var imgAutoreRicevuto = await context.Client.GetInteractivity().WaitForMessageAsync(msg => msg.Channel == context.Channel).ConfigureAwait(false);

            if (!imgAutoreRicevuto.TimedOut)
            {
                linkImmagine = imgAutoreRicevuto.Result.Content;

                embed.Author = new EmbedAuthor()
                {
                    Name = autore,
                    IconUrl = linkImmagine,
                };
                await imgAutoreRicevuto.Result.DeleteAsync();
                await messaggioImgAutore.DeleteAsync();
            }
            else
            {
                await context.Channel.SendMessageAsync("Non hai scritto niente in 60 secondi. Comando Cancellato.");
            }

            #endregion


            #region ImmagineAutore

            DiscordMessage messaggioImmagine = await context.Channel.SendMessageAsync("Ora manda, entro 60 secondi, il link dell'Immagine dell'Embed.");

            var immagineRicevuta = await context.Client.GetInteractivity().WaitForMessageAsync(msg => msg.Channel == context.Channel).ConfigureAwait(false);

            if (!immagineRicevuta.TimedOut)
            {
                embed.Thumbnail = new EmbedThumbnail
                {
                    Url = immagineRicevuta.Result.Content,
                };
                await immagineRicevuta.Result.DeleteAsync();
                await messaggioImmagine.DeleteAsync();
            }
            else
            {
                await context.Channel.SendMessageAsync("Non hai scritto niente in 60 secondi. Comando Cancellato.");
            }

            #endregion

            #region ImmagineAutore

            DiscordMessage messaggioColore = await context.Channel.SendMessageAsync("Ora manda, entro 60 secondi, un codice esadecimale per il colore dell'Embed, esempio: #FF0000 = ROSSO.");

            var coloreRicevuto = await context.Client.GetInteractivity().WaitForMessageAsync(msg => msg.Channel == context.Channel).ConfigureAwait(false);

            if (!coloreRicevuto.TimedOut)
            {
                embed.Color = new DiscordColor(coloreRicevuto.Result.Content);
                await coloreRicevuto.Result.DeleteAsync();
                await messaggioColore.DeleteAsync();
            }
            else
            {
                await context.Channel.SendMessageAsync("Non hai scritto niente in 60 secondi. Comando Cancellato.");
            }

            #endregion

            await context.Channel.SendMessageAsync(embed);
        }
    }
}
