using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using HtmlAgilityPack;

/// <summary>
/// Contains all necessary methods to find and report a player's Rainbow Six Siege statistics.
/// </summary>
public class SiegeModule : ModuleBase<SocketCommandContext>
{
    [Command("r6")]
    public async Task Rank(string name, string platform)
    {
        platform = platform.ToLower();

        //Loading Embed Builder
        var builderLoading = new EmbedBuilder
        {
            Author = new EmbedAuthorBuilder
            {
                Name = "Loading user data. . .",
            },

            Footer = new EmbedFooterBuilder
            {
                Text = "Requested by " + Context.User,
                IconUrl = Context.User.GetAvatarUrl()
            },
        };

        builderLoading.WithColor(0xFEFEFE)
                .Build();

        var Message = await Context.Channel.SendMessageAsync(embed: builderLoading.Build());

        //Load HTML
        var html = @"https://r6.tracker.network/profile/" + platform + "/" + name; //Sets Profile Overiew

        //Loads Profile Overview
        HtmlWeb web = new HtmlWeb();
        var doc = web.Load(html);

        //Invalid Username Error Handler
        try
        {
            HtmlNode requestedNameTest = doc.DocumentNode.SelectSingleNode("(//h1[@class='trn-profile-header__name'])"); //Loads Name and Profile Views
            var requestedNameSpanTest = requestedNameTest.Element("span"); //Loads Name
        }
        catch
        {
            //Error Embed Builder
            var builderTest = new EmbedBuilder
            {
                Author = new EmbedAuthorBuilder
                {
                    Name = "Could not find user " + name + ".",
                },

                Footer = new EmbedFooterBuilder
                {
                    Text = "Requested by " + Context.User,
                    IconUrl = Context.User.GetAvatarUrl()
                },
            };

            builderTest.WithColor(0xFEFEFE)
                    .Build();

            await Message.ModifyAsync(msg => msg.Embed = builderTest.Build());
        }
        finally
        {
            var htmlSeason = html + "/seasons"; //Sets Season Page

            //Loads Season Page
            HtmlWeb webSeason = new HtmlWeb();
            var docSeason = webSeason.Load(htmlSeason);

            HtmlNode requestedKD = docSeason.DocumentNode.SelectSingleNode("(//div[@class='trn-defstat__value'])"); //Loads KD from Seasons Page

            HtmlNode requestedName = doc.DocumentNode.SelectSingleNode("(//h1[@class='trn-profile-header__name'])"); //Loads Name and Profile Views
            var requestedNameSpan = requestedName.Element("span"); //Loads Name

            HtmlNode requestedLevel = doc.DocumentNode.SelectSingleNode("(//div[@class='trn-defstat__value'])"); //Loads Level
            HtmlNode requestedRank = doc.DocumentNode.SelectSingleNode("(//div[@class='trn-defstat__value'])[3]"); //Loads Rank
            HtmlNode requestedHeadshot = doc.DocumentNode.SelectSingleNode("(//div[@data-stat='PVPAccuracy'])"); //Loads Headshot %
            HtmlNode requestedAvatar = doc.DocumentNode.SelectSingleNode("(//div[@class='trn-profile-header__content trn-card__content'])//img"); //Loads Requested Avatar     

            SiegeData siegedata = new SiegeData(); //Loads dictionaries from seperate SiegeData.cs

            string rankIcon = (string)siegedata.rankImages[requestedRank.InnerHtml.Trim('\n')]; //Loads rank icon

            Discord.Color embedColor = new Discord.Color(siegedata.rankColors[requestedRank.InnerHtml.Trim('\n')]); //Loads embed color

            //MMR Loader
            string mmr;
            if (requestedRank.InnerText.Trim('\n') == "Not ranked yet.") //Loads unranked mmr
            {
                HtmlNode unrankedMMR = doc.DocumentNode.SelectSingleNode("(//div[@style='font-size: 2rem;'])"); //Loads MMR
                mmr = unrankedMMR.InnerText.Trim('\n'); //Sets MMR
            }
            else //Loads ranked mmr
            {
                HtmlNode requestedMMR = doc.DocumentNode.SelectSingleNode("(//div[@class='r6-season-rank__progress-fill'])"); //Loads Season Stats Table
                var requestedMMRSpan = requestedMMR.Element("span"); //Loads MMR
                mmr = requestedMMRSpan.InnerText.Trim('\n'); //Sets MMR
            }

            //Embed Builder
            var builder = new EmbedBuilder
            {
                Author = new EmbedAuthorBuilder
                {
                    Name = requestedNameSpan.InnerText.Trim('\n') + "'s Stats",
                    IconUrl = requestedAvatar.GetAttributeValue("src", "")
                },

                Description = "**Level**\n> " + requestedLevel.InnerText.Trim('\n')
                            + "\n**Seasonal KD**\n> " + requestedKD.InnerText.Trim('\n')
                            + "\n**MMR**\n> " + mmr
                            + "\n**Headshot %**\n> " + requestedHeadshot.InnerText.Trim('\n')
                            + "\n[View Full Stats](" + html + ")",

                ThumbnailUrl = rankIcon,

                Footer = new EmbedFooterBuilder
                {
                    Text = "Requested by " + Context.User,
                    IconUrl = Context.User.GetAvatarUrl()
                },
            };

            builder.WithColor(embedColor)
                    .Build();

            await Message.ModifyAsync(msg => msg.Embed = builder.Build());
        }
    }
}
