namespace NetTelebot.CommonUtils
{
    public class TelegramBotSuperGroupChat
    {
        private const string mBotName = "NetTelebotSuperGroupTest";

        private readonly string mToken;
        private readonly long mChatId;

        public TelegramBotSuperGroupChat()
        {
            mToken = WindowsCredential.GetTelegramCredential(mBotName).Token;
            mChatId = WindowsCredential.GetTelegramCredential(mBotName).ChatId;
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
        /// Supergroup chat id
        /// </summary>
        /// <returns>Telegram ChatId</returns>
        public long GetChatId()
        {
            return mChatId;
        }
    }
}
