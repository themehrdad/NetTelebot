using NDatabase.Api;
using System;
using System.Linq;

namespace NetTelebot.Commands
{
    public class BotData : IDisposable
    {
        private IOdb odb;
        public BotData(Bot bot)
        {
            Bot = bot;
        }
        public Bot Bot { get; }
        internal void SetCommand(int userId, int chatId, string command)
        {
            CommandState commandState = GetCommandState(userId, chatId) ?? new CommandState();
            if (string.IsNullOrEmpty(commandState.CommandText) ||
                !commandState.CommandText.Equals(command, StringComparison.InvariantCultureIgnoreCase))
            {
                commandState.CommandText = command;
                commandState.ChatId = chatId;
                commandState.UserId = userId;
                commandState.Parameters.Clear();
            }
            Store(commandState);
        }

        internal void SetParameter(int userId, int chatId, object parameter)
        {
            CommandState commandState = GetCommandState(userId, chatId);
            commandState?.Parameters.Add(parameter);
        }

        internal void DeleteCommandState(int userId, int chatId)
        {
            CommandState commandState = GetCommandState(userId, chatId);
            if (commandState == null) return;
            IOdb db = GetOdb();
            db.Delete(commandState);
        }

        private void Store(CommandState commandState)
        {
            GetOdb().Store(commandState);
        }

        internal CommandState GetCommandState(int userId, int chatId)
        {
            return GetOdb().Query<CommandState>().Execute<CommandState>()
                .FirstOrDefault(cs => cs.ChatId == chatId && cs.UserId == userId);
        }

        private IOdb GetOdb()
        {
            return odb ?? (odb = NDatabase.OdbFactory.Open(Bot.Name));
        }

        public void Dispose()
        {
            GetOdb().Dispose();
        }
    }
}
