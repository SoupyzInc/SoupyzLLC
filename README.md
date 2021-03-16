# SoupyzLLC
A Discord bot written in C# with [Discord.Net](https://github.com/discord-net/Discord.Net) that gets your Rainbow Six Siege stats from [r6tracker](https://r6.tracker.network/) by utilizing the [HTML Agility Pack](https://html-agility-pack.net/). You can look up a Rainbow Six Siege player's stats using `.r6 UserName Platform` in any Discord server with the SoupyzLLC bot. SoupyzLLC will return the player's avatar, mmr, rank, level, seasonal kill/death ratio, and headshot percentage. _Note: if and when r6tracker changes their website ui, the bot will no longer function properly._

![](https://github.com/SoupyzInc/SoupyzLLC/blob/main/Wiki/search%20example.gif)

## Error Handling
Will handle invalid usernames.

![](https://github.com/SoupyzInc/SoupyzLLC/blob/main/Wiki/error%20handling.gif)

### Installation 
If you wish to use this bot, you can download and run the code your self. Know that if you want to use this on a large scale, web scraping is not the best idea. You may want to look into using an API to get game data.
1. Download the code from the [`src` folder](https://github.com/SoupyzInc/SoupyzLLC/tree/main/src) of this repository.
2. Create a Discord bot and get your token.
3. Create a  `token.txt` file with your token. _Do not ever share your token with anyone._
4. Change line 70 of `StartUp.cs` to pull from your `token.txt` file.
5. Install dependencies. I used [Discord.Net](https://github.com/discord-net/Discord.Net) and [HTML Agility Pack](https://html-agility-pack.net/).
6. Run the `StartUp.cs` file, your bot should be online and ready to run in any server with your bot.
