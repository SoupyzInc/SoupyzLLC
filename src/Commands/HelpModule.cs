using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Discord;
using Discord.Commands;

/// <summary>
/// Contains all necessary documentations on SoupyLLC's commands.
/// </summary>
[Group("help")]
public class HelpModule : ModuleBase<SocketCommandContext>
{
    readonly string soupyzLLCImg = "https://cdn.discordapp.com/attachments/734935840282771598/741382917653004431/S_Monochrome.png";
    readonly Discord.Color white = new Discord.Color(0xFEFEFE);

    /// <summary>
    /// General help command that displays all other help commands.
    /// </summary>
    [Command()]
    public async Task Help()
    {
        var builder = new EmbedBuilder
        {
            Author = new EmbedAuthorBuilder
            {
                Name = "SoupyzLLC Documentation",
            },

            ThumbnailUrl = soupyzLLCImg,

            Description = "`.help r6`",

            Footer = new EmbedFooterBuilder
            {
                Text = "Requested by " + Context.User,
                IconUrl = Context.User.GetAvatarUrl()
            },
        };

        builder.WithColor(white)
                .Build();

        await Context.Channel.SendMessageAsync(embed: builder.Build());
    }

    /// <summary>
    /// Displays documentation on using the r6 command.
    /// </summary>
    [Command("r6")]
    public async Task HelpRSix()
    {
        var builder = new EmbedBuilder
        {
            Author = new EmbedAuthorBuilder
            {
                Name = ".r6 Documentation",
            },

            ThumbnailUrl = soupyzLLCImg,

            Description = "`.r6 PlayerUplayName Platform`\nSearches [r6tracker](https://r6.tracker.network/) for the specified player's stats.",

            Footer = new EmbedFooterBuilder
            {
                Text = "Requested by " + Context.User,
                IconUrl = Context.User.GetAvatarUrl()
            },
        };

        builder.WithColor(white)
                .Build();

        await Context.Channel.SendMessageAsync(embed: builder.Build());
    }
}
