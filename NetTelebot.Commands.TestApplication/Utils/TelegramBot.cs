using System;

namespace NetTelebot.Commands.TestApplication.Utils
{
    public class TelegramBot : IWindowsCredential
    {
        private const string mBotName = "NetTelebotTest";

        private readonly string mToken;
        private readonly int mChatId;

        public TelegramBot()
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
        /// 
        /// </summary>
        /// <returns>Telegram ChatId</returns>
        public int GetChatId()
        {
            return mChatId;
        }

        public TelegramCredentials GetTelegramCredential(string botAlias)
        {
            return new WindowsCredential().GetTelegramCredential(botAlias);
        }

        TelegramCredentials IWindowsCredential.GetTelegramCredential(string botAlias)
        {
            throw new NotImplementedException();
        }
    }
}
