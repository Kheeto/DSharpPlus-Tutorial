using System;
using System.Collections.Generic;
using System.Text;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Entities;
using DSharpPlus.CommandsNext.Converters;

namespace DSharpPlusTutorial
{
    public class CustomHelp : BaseHelpFormatter
    {
        DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
        StringBuilder stringBuilder = new StringBuilder();

        public CustomHelp(CommandContext ctx) : base(ctx)
        {
            embed.Color = new DiscordColor("#CD0000");
            embed.Title = "Help";
            embed.Description = "Lista dei comandi del Bot.";
        }

        public override CommandHelpMessage Build()
        {
            return new CommandHelpMessage(embed: embed);
            return new CommandHelpMessage(content: stringBuilder.ToString());
        }

        public override BaseHelpFormatter WithCommand(Command command)
        {
            embed.Title = "Comando " + command.Name + " - Help";
            embed.Description = command.Description;
            stringBuilder.AppendLine("Comando: " + command.Name + command.Description);

            string argomenti = "```";

            foreach(CommandOverload overl in command.Overloads)
            {
                foreach(CommandArgument arg in overl.Arguments)
                {
                    argomenti = argomenti + arg.Name;
                }
            }

            argomenti = argomenti + "```";

            embed.AddField("Argomenti: ", argomenti);
            stringBuilder.AppendLine("Argomenti: " + argomenti);

            foreach (CommandOverload overl in command.Overloads)
            {
                foreach (CommandArgument arg in overl.Arguments)
                {
                    embed.AddField(arg.Name + ":", arg.Description);
                    stringBuilder.AppendLine(arg.Name + arg.Description);
                }
            }

            return this;
        }

        public override BaseHelpFormatter WithSubcommands(IEnumerable<Command> subcommands)
        {
            embed.Description = "Lista dei comandi:\n```";

            foreach (Command command in subcommands)
            {
                embed.Description = embed.Description + command.Name + ", ";
            }

            embed.Description = embed.Description + "```";

            return this;
        }
    }
}
