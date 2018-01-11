using System;
using System.Collections.Generic;
using System.IO;
using RobotTest. BusinessLogic;
using CommandLine;
using RobotTest.UI.CommandParsing;
using RobotTest.UI.ConsoleUI.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace RobotTest.UI.ConsoleUI
{
    public class Program
    {
        #region Fields

        private const string ExitCommand = "exit";

        private const string Prompt = "> ";

        #endregion

        #region Main

        /// <summary>
        /// Parses arguments, creates grid and robot, accepts commands and passes these to the robot
        /// </summary>
        /// <param name="args">Arguments</param>
        private static void Main(string[] args)
        {
            var options = default(Options);
            var optionsParserResult = Parser.Default.ParseArguments<Options>(args)
                .WithParsed(i => options = i);
            if (options == null)
            {
                return;
            }

            var services = new ServiceCollection()
                .AddLogging(config => config.AddConsole())
                .AddSingleton(new Grid(options.GridX, options.GridY))
                .AddSingleton<Robot>()
                .AddSingleton<TextCommandParser>()
                .BuildServiceProvider();

            ////var logger = services.GetRequiredService<ILogger<Program>>();


            ////var logger = new Microsoft.Extensions.Logging.Console.ConsoleLogger("robottest", (i, j) => true, true);
            ////var grid = new Grid(options.GridX, options.GridY);
            ////var robot = new Robot(logger, grid);
            ////var commandParser = new TextCommandParser(logger);

            var robot = services.GetRequiredService<Robot>();
            var commandParser = services.GetRequiredService<TextCommandParser>();

            Console.WriteLine("Robot created on {0}x{1} grid", options.GridX, options.GridY);
            Console.WriteLine("Available commands:");
            Console.WriteLine(ExitCommand);
            foreach (var command in commandParser.GetRegisteredCommands())
            {
                Console.WriteLine(command);
            }

            Console.Write(Prompt);
            string input;
            while ((input = Console.ReadLine()) != null && input.ToLower() != ExitCommand)
            {
                var command = commandParser.ParseCommand(input);
                if (command != null)
                {
                    robot.ExecuteCommand(command);
                }

                Console.Write(Prompt);
            }
        }

        #endregion
    }
}
