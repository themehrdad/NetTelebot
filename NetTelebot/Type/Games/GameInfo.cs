using Newtonsoft.Json.Linq;

namespace NetTelebot.Type.Games
{
    /// <summary>
    /// This object represents a game. Use BotFather to create and edit games, their short names will act as unique identifiers.
    /// See <see href="https://core.telegram.org/bots/api#game">API</see>
    /// </summary>
    public class GameInfo
    {
        internal GameInfo()
        {
        }

        internal GameInfo(JObject jsonObject)
        {
            Title = jsonObject["title"].Value<string>();
            Description = jsonObject["description"].Value<string>();
            Photo = PhotoSizeInfo.ParseArray(jsonObject["photo"].Value<JArray>());

            if (jsonObject["text"] != null)
                Text = jsonObject["text"].Value<string>();
            if (jsonObject["text_entities"] != null)
                Entities = MessageEntityInfo.ParseArray(jsonObject["text_entities"].Value<JArray>());
            if (jsonObject["animation"] != null)
                Animation = new AnimationInfo(jsonObject["animation"].Value<JObject>());
        }

        /// <summary>
        /// Title of the game
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Description of the game
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Photo that will be displayed in the game message in chats.
        /// </summary>
        public PhotoSizeInfo[] Photo { get; internal set; }

        /// <summary>
        /// Optional.
        /// Brief description of the game or high scores included in the game message. 
        /// Can be automatically edited to include current high scores for the game 
        /// when the bot calls setGameScore, or manually edited using editMessageText. 
        /// 0-4096 characters.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Optional.
        /// Special entities that appear in text, such as usernames, URLs, bot commands, etc.
        /// </summary>
        public MessageEntityInfo[] Entities { get; internal set; }

        /// <summary>
        /// Optional. 
        /// Animation that will be displayed in the game message in chats. 
        /// Upload via <see href="https://t.me/botfather">BotFather</see>
        /// </summary>
        public AnimationInfo Animation { get; internal set; }
    }
}
