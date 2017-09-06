using NetTelebot.Type.Games;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject.GameObject
{
    internal static class GameInfoObject
    {
        /// <summary>
        /// This object represents a game. Use BotFather to create and edit games, their short names will act as unique identifiers.
        /// See <see href="https://core.telegram.org/bots/api#game">API</see>
        /// </summary>
        /// <param name="title">Title of the game</param>
        /// <param name="description">Description of the game</param>
        /// <param name="photo">Photo that will be displayed in the game message in chats.</param>
        /// <param name="text">Optional. Brief description of the game or high scores included in the game message. 
        /// Can be automatically edited to include current high scores for the game when the bot calls setGameScore,
        /// or manually edited using editMessageText. 
        /// 0-4096 characters.</param>
        /// <param name="textEntities">Optional. Special entities that appear in text, such as usernames, URLs, bot commands, etc.</param>
        /// <param name="animation">Optional. Animation that will be displayed in the game message in chats. Upload via BotFather</param>
        /// <returns><see cref="GameInfo"/></returns>
        internal static JObject GetObject(string title, string description, JArray photo,
            string text, JArray textEntities, JObject animation)
        {
            dynamic gameInfo = new JObject();

            gameInfo.title = title;
            gameInfo.description = description;
            gameInfo.photo = photo;
            gameInfo.text = text;
            gameInfo.text_entities = textEntities;
            gameInfo.animation = animation;

            return gameInfo;
        }
    }
}
