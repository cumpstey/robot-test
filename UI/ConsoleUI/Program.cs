namespace RobotTest.UI.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using BusinessLogic;
    using CommandLine;
    using CommandParsing;
    using Configuration;
    using Logging;
    using Utilities.Logging;

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
            var options = new Options();
            if (!Parser.Default.ParseArguments(args, options))
            {
                // Parser will print out help about the failure
                return;
            }

            var logger = new ConsoleLogger();
            var grid = new Grid(options.GridX, options.GridY);
            var robot = new Robot(logger, grid);
            var commandParser = new TextCommandParser(logger);

            Console.WriteLine("Robot created on {0}x{1} grid", grid.X, grid.Y);
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
