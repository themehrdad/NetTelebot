namespace NetTelebot.CommonUtils
{
    public class TelegramBot
    {
        private const string mBotName = "NetTelebotBot";
        private const string mGroupBotName = "NetTelebotTest";
        private const string mSuperGroupBotName = "NetTelebotSuperGroupTest";

        private readonly string mBotToken;

        private readonly string mTokenGroupChat;
        private readonly long? mGroupChatId;

        private readonly string mTokenSuperGroupChat;
        private readonly long? mSuperGroupChatId;

        public TelegramBot()
        {
            mBotToken = WindowsCredential.GetTelegramCredential(mBotName).Token;

            mTokenGroupChat = WindowsCredential.GetTelegramCredential(mGroupBotName).Token;
            mGroupChatId = WindowsCredential.GetTelegramCredential(mGroupBotName).ChatId;
            
            mTokenSuperGroupChat = WindowsCredential.GetTelegramCredential(mSuperGroupBotName).Token;
            mSuperGroupChatId = WindowsCredential.GetTelegramCredential(mSuperGroupBotName).ChatId;
        }


        /// <summary>
        /// Gets the bot for example project. Use only token.
        /// </summary>
        /// <param name="checkInterval">The check interval. Default value 1000 ms</param>
        /// <returns>
        /// NetTelebotBot client instance
        /// </returns>
        public TelegramBotClient GetBot(int checkInterval = 1000)
        {
            return GetBot(mBotToken, checkInterval);
        }

        public TelegramBotClient GetGroupChatBot()
        {
            return GetBot(mTokenGroupChat);
        }

        public TelegramBotClient GetSuperGroupChatBot()
        {
            return GetBot(mTokenSuperGroupChat);
        }

        public long? GetGroupChatId()
        {
            return mGroupChatId;
        }

        public long? GetSuperGroupChatId()
        {
            return mSuperGroupChatId;
        }

        private static TelegramBotClient GetBot(string token)
        {
            return new TelegramBotClient {Token = token};
        }

        private static TelegramBotClient GetBot(string token, int checkInterval)
        {
            return new TelegramBotClient { Token = token, CheckInterval  = checkInterval };
        }
    }
}
