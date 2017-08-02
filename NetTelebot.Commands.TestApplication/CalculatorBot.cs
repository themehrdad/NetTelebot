namespace NetTelebot.Commands.TestApplication
{
    public class CalculatorBot : Bot
    {
        public CalculatorBot(string token): base("calculator", token)
        {
            //start command
            CommandInfo command = new CommandInfo("/start") {StaticAcceptMessage = "Ok you started the calculator"};

            Configuration.Commands.Add(command);
            Configuration.StaticUnknownCommandMessage = "Unknown command. Please try another command. Send /start to get a list of available comands.";

            //newbrand command
            CommandInfo command2 = new CommandInfo("/newbrand") {StaticAcceptMessage = "New brand is saved."};

            ParameterInfo parameter = new ParameterInfo
            {
                Name = "Name",
                Type = ParameterTypes.Text,
                Optional = false,
                StaticPrompt = "Ok, enter new brand name."
            };

            command2.Parameters.Add(parameter);
            Configuration.Commands.Add(command2);

            //getinfo command
            CommandInfo command3 = new CommandInfo("/getinfo") { StaticAcceptMessage = "New command."};

            ParameterInfo parameter2 = new ParameterInfo
            {
                Name = "Name",
                Type = ParameterTypes.Text,
                Optional = false,
                StaticPrompt = "Is new comand."
            };

            command3.Parameters.Add(parameter2);
            Configuration.Commands.Add(command3);

            //getkeyboard command
            CommandInfo commmand4 = new CommandInfo("/getkeyboard");
            ParameterInfo parameter4 = new ParameterInfo()
            {
                Name = "Keyboard",
                Type = ParameterTypes.Keyboard,
                Optional = false,
                StaticPrompt = "Is keyboard"
            };
        }
    }
}
