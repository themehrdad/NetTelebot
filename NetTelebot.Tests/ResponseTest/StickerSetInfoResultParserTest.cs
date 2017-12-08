using NetTelebot.BotEnum;
using NetTelebot.Tests.TypeTestObject;
using NetTelebot.Tests.TypeTestObject.ResultTestObject;
using NetTelebot.Tests.TypeTestObject.StickerObject;
using NUnit.Framework;

namespace NetTelebot.Tests.ResponseTest
{
    internal static class StickerSetInfoResultParserTest
    {
        [Test]
        public static void StickerSetInfoResultTest()
        {
            StickerSetInfoResultObject stickerSetInfoResult = new StickerSetInfoResultObject
            {
                Ok = true,
                Result = new StickerSetInfoObject
                {
                    Name = "TestName",
                    Title = "TestTitle",
                    ContainsMask = true,
                    Stickers = new []
                    {
                        new StickerInfoObject
                        {
                            FileId = "TestFileId",
                            Width = 123,
                            Height = 123,
                            Thumb = new PhotoSizeInfoObjects
                            {
                                FileId = "TestFileId",
                                Width = 123,
                                Height = 123,
                                FileSize = 123
                            },
                            Emoji = "TestEmoji",
                            SetName = "TestSetName",
                            MaskPosition = new MaskPositiontInfoObject
                            {
                                Point = Point.chin,
                                X_shift = 2.2,
                                Y_shift = 2.3,
                                Scale = 2.4
                            },
                            FileSize = 12
                        }
                    }
                }
            };
        }
    }
}
