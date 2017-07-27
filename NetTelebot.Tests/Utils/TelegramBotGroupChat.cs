namespace NetTelebot.Tests.Utils
{
    internal class TelegramBotGroupChat : IWindowsCredential
    {
        private const string mBotName = "NetTelebotTest";

        private readonly string mToken;
        private readonly long mChatId;

        public TelegramBotGroupChat()
        {
            mToken = GetTelegramCredential(mBotName).Token;
            mChatId = GetTelegramCredential(mBotName).ChatId;
        }

        /// <summary>
        /// Create bot insatnce
        /// </summary>
        /// <returns>TelegramBotClient</returns>
        public TelegramBotClient GetBot()
        {
            TelegramBotClient telegramBotClient = new TelegramBotClient
            {
                Token = mToken
            };

            return telegramBotClient;
        }

        /// <summary>
        /// Group chatId
        /// </summary>
        /// <returns>Telegram ChatId</returns>
        public long GetChatId()
        {
            return mChatId;
        }

        public TelegramCredentials GetTelegramCredential(string botAlias)
        {
            return new WindowsCredential().GetTelegramCredential(botAlias);
        }
    }
}
