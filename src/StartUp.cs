using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

/// <summary>
/// Contains all necessary methonds to connect the bot to discord and handle commands.
/// </summary>
public class StartUp
{
    private static DiscordSocketClient _client;
    private static CommandService _commands;
    private static readonly IServiceProvider _services;

    /// <summary>
    /// Logs messages and error handling into the console.
    /// </summary>
    /// <param name="message">the message to be logged.</param>
    private static Task Log(LogMessage message)
    {
        switch (message.Severity)
        {
            case LogSeverity.Critical:
            case LogSeverity.Error:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case LogSeverity.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case LogSeverity.Info:
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case LogSeverity.Verbose:
            case LogSeverity.Debug:
                Console.ForegroundColor = ConsoleColor.DarkGray;
                break;
        }

        Console.WriteLine($"{DateTime.Now,-19} [{message.Severity,8}] {message.Source}: {message.Message} {message.Exception}");
        Console.ResetColor();

        return Task.CompletedTask;
    }

    /// <summary>
    /// The main method that instantiates the other methods.
    /// </summary>
    private static async Task Main()
    {
        _client = new DiscordSocketClient(new DiscordSocketConfig
        {
            LogLevel = LogSeverity.Info,
        });

        _commands = new CommandService(new CommandServiceConfig
        {
            LogLevel = LogSeverity.Info,
            CaseSensitiveCommands = false,
        });

        //Subscribe the logging handler to both the client and the CommandService
        _client.Log += Log;
        _commands.Log += Log;

        await InitCommands(); //Centralize the logic for commands into a separate method

        string token = System.IO.File.ReadAllText(@"\token.txt"); //Grabs token from text file.

        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        await Task.Delay(Timeout.Infinite);
    }

    /// <summary>
    /// Finds all commands and checks to see if any of them are invoked.
    /// </summary>
    private static async Task InitCommands()
    {     
        await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services); //Searches the program and adds all Module classes that can be found      
        _client.MessageReceived += HandleCommandAsync; //Subscribe a handler to see if a message invokes a command
    }

    /// <summary>
    /// Checks if a recieved message is a command. If so, the command will be executed.
    /// </summary>
    /// <param name="arg">the message to be checked</param>
    private static async Task HandleCommandAsync(SocketMessage arg)
    {
        if (!(arg is SocketUserMessage msg)) //Ignore system messages
        {
            return;
        }

        if (msg.Author.Id == _client.CurrentUser.Id || msg.Author.IsBot) //Ignore other bots and itself
        {
            return; 
        }

        int pos = 0; //Tracks where the prefix ends and the command begins

        if (msg.HasCharPrefix('.', ref pos)
        {            
            var context = new SocketCommandContext(_client, msg); //Create a Command Context            
            var result = await _commands.ExecuteAsync(context, pos, _services); //Execute the command
        }
    }
}
