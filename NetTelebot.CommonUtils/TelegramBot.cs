namespace NetTelebot.CommonUtils
{
    public class TelegramBot
    {
        private const string mGroupBotName = "NetTelebotTest";
        private const string mSuperGroupBotName = "NetTelebotSuperGroupTest";

        private readonly string mTokenGroupChat;
        private readonly long mGroupChatId;

        private readonly string mTokenSuperGroupChat;
        private readonly long mSuperGroupChatId;

        public TelegramBot()
        {
            mTokenGroupChat = WindowsCredential.GetTelegramCredential(mGroupBotName).Token;
            mGroupChatId = WindowsCredential.GetTelegramCredential(mGroupBotName).ChatId;
            
            mTokenSuperGroupChat = WindowsCredential.GetTelegramCredential(mSuperGroupBotName).Token;
            mSuperGroupChatId = WindowsCredential.GetTelegramCredential(mSuperGroupBotName).ChatId;
        }

        public TelegramBotClient GetGroupChatBot()
        {
            return GetBot(mTokenGroupChat);
        }

        public TelegramBotClient GetSuperGroupChatBot()
        {
            return GetBot(mTokenSuperGroupChat);
        }

        public long GetGroupChatId()
        {
            return mGroupChatId;
        }

        public long GetSuperGroupChatId()
        {
            return mSuperGroupChatId;
        }

        private static TelegramBotClient GetBot(string token)
        {
            return new TelegramBotClient {Token = token};
        }
    }
}
