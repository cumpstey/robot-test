namespace RobotTest.UI.ConsoleUI.Configuration
{
    using CommandLine;
    using CommandLine.Text;
    
    public class Options
    {
        [ParserState]
        public IParserState LastParserState { get; set; }

        [Option('x', Required = true, HelpText = "X dimension of the grid.")]
        public int GridX { get; set; }

        [Option('y', Required = true, HelpText = "Y dimension of the grid.")]
        public int GridY { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
