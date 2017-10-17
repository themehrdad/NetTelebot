using System;
using CredentialManagement;

namespace NetTelebot.CommonUtils
{
    /// <summary>
    /// Some tests require the use of real credentials Telegram messenger (bot token and chart id). 
    /// For security purposes, this data is not defined in the variable test. Instead, the challenge WindowsCredential.GetCredential(botAlias) method, 
    /// where botAlias is saved telegram credential in Windows Credential Store. For add this you need:
    /// 1. Go to Windows Control Panel -> Credential Manager
    /// 2. Click on Windows credentials -> Add Common Windows credentials(use common is important)
    /// 3. Fill in the following way:
    /// Internet Adres: is variable botAlis for method WindowsCredentialUtils.GetCredential.In project use botAlias = TestTelegramBotName.
    /// User Name: real telegram chat id
    /// Password: real telegram token
    /// </summary>
    internal static class WindowsCredential
    {
        /// <summary>
        /// Returns the telegram credentials
        /// </summary>
        /// <param name="botAlias">Account stored in Windows Credential Manager</param>
        /// <returns></returns>
        internal static TelegramCredentials GetTelegramCredential(string botAlias)
        {
            Credential credential = new Credential { Target = botAlias };

            return credential.Load()
                ? new TelegramCredentials {Token = credential.Password, ChatId = Convert.ToInt64(credential.Username)}
                : new TelegramCredentials {Token = null, ChatId = null};
        }
    }

    internal struct TelegramCredentials
    {
        /// <summary>
        /// You can learn your token from BotFather (@BotFather) 
        /// </summary>
        internal string Token { get; set; }

        /// <summary>
        /// In order to get the group chat id, do as follows:
        /// 1. Add the Telegram BOT to the group.
        /// 2. Get the list of updates for your BOT:
        /// https://api.telegram.org/botYourBOTToken/getUpdates
        /// 3. Look for the "chat" object:
        /// {"update_id":8393,"message":{"message_id":3,"from":{"id":7474,"first_name":"AAA"},"chat":{"id":,"title":""},
        /// "date":25497,"new_chat_participant":{"id":71,"first_name":"NAME","username":"YOUR_BOT_NAME"}}}
        /// This is a sample of the response when you add your BOT into a group. 
        /// 4. Use the "id" of the "chat" object to send your messages.
        /// </summary>
        internal long? ChatId { get; set; }
    }
}