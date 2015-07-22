using NDatabase.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot.Commands
{
    public class BotData : IDisposable
    {
        private IOdb odb;
        public BotData(Bot bot)
        {
            Bot = bot;
        }
        public Bot Bot { get; private set; }
        internal void SetCommand(int userId, int chatId, string command)
        {
            var commandState = GetCommandState(userId, chatId);
            if (commandState == null)
            {
                commandState = new CommandState();
            }
            if (string.IsNullOrEmpty(commandState.commandText) ||
                !commandState.commandText.Equals(command, StringComparison.InvariantCultureIgnoreCase))
            {
                commandState.commandText = command;
                commandState.chatId = chatId;
                commandState.userId = userId;
                commandState.Parameters.Clear();
            }
            Store(commandState);
        }

        internal void SetParameter(int userId, int chatId, object parameter)
        {
            var commandState = GetCommandState(userId, chatId);
            if (commandState != null)
            {
                commandState.Parameters.Add(parameter);
            }
        }

        internal void DeleteCommandState(int userId, int chatId)
        {
            var commandState = GetCommandState(userId, chatId);
            if (commandState != null)
            {
                var db = GetOdb();
                db.Delete(commandState);
            }
        }

        private void Store(CommandState commandState)
        {
            GetOdb().Store(commandState);
        }

        internal CommandState GetCommandState(int userId, int chatId)
        {
            return GetOdb().Query<CommandState>().Execute<CommandState>().Where(cs =>
                cs.chatId == chatId && cs.userId == userId)
                .FirstOrDefault();
        }

        private IOdb GetOdb()
        {
            if (odb == null)
                odb = NDatabase.OdbFactory.Open(Bot.Name);
            return odb;
        }

        public void Dispose()
        {
            GetOdb().Dispose();
        }
    }
}
