using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot.Commands.TestApplication
{
    public class CalculatorBot : Bot
    {
        public CalculatorBot(string token)
            : base("calculator", token)
        {
            var command = new CommandInfo("/start");
            command.StaticAcceptMessage = "Ok you started the calculator";
            Configuration.Commands.Add(command);
            Configuration.StaticUnknownCommandMessage = "Unknown command. Please try another command. Send /start to get a list of available comands.";
            var command2 = new CommandInfo("/newbrand");
            command2.StaticAcceptMessage = "New brand is saved.";
            var parameter = new ParameterInfo() { Name = "Name", Type = ParameterTypes.Text, Optional = false, StaticPrompt = "Ok, enter new brand name." };
            command2.Parameters.Add(parameter);
            Configuration.Commands.Add(command2);
        }
    }
}
