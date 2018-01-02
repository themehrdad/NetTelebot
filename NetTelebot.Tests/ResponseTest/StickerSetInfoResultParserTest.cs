using NetTelebot.BotEnum;
using NetTelebot.Result;
using NetTelebot.Tests.TypeTestObject;
using NetTelebot.Tests.TypeTestObject.ResultTestObject;
using NetTelebot.Tests.TypeTestObject.StickerObject;
using Newtonsoft.Json;
using NUnit.Framework;

namespace NetTelebot.Tests.ResponseTest
{
    [TestFixture]
    internal static class StickerSetInfoResultParserTest
    {
        /// <summary>
        /// Test for <see cref="StickerSetInfoResult"/> parse field.
        /// </summary>
        [Test]
        public static void StickerSetInfoResultTest()
        {
            StickerSetInfoResultObject stickerSetInfoResultString = new StickerSetInfoResultObject
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
                                Point = "chin",
                                X_shift = 2.2,
                                Y_shift = 2.3,
                                Scale = 2.4
                            },
                            FileSize = 12
                        }
                    }
                }
            };

            StickerSetInfoResult stickerSetInfoResult =
                new StickerSetInfoResult(JsonConvert.SerializeObject(stickerSetInfoResultString, Formatting.Indented));

            Assert.AreEqual(stickerSetInfoResultString.Ok, stickerSetInfoResult.Ok);
            Assert.AreEqual(stickerSetInfoResultString.Result.Name, stickerSetInfoResult.Result.Name);
            Assert.AreEqual(stickerSetInfoResultString.Result.Title, stickerSetInfoResult.Result.Title);
            Assert.AreEqual(stickerSetInfoResultString.Result.ContainsMask, stickerSetInfoResult.Result.ContainsMask);
            Assert.AreEqual(stickerSetInfoResultString.Result.Stickers[0].FileId, stickerSetInfoResult.Result.Stickers[0].FileId);
            Assert.AreEqual(stickerSetInfoResultString.Result.Stickers[0].Width, stickerSetInfoResult.Result.Stickers[0].Width);
            Assert.AreEqual(stickerSetInfoResultString.Result.Stickers[0].Height, stickerSetInfoResult.Result.Stickers[0].Height);
            Assert.AreEqual(stickerSetInfoResultString.Result.Stickers[0].Thumb.FileId, stickerSetInfoResult.Result.Stickers[0].Thumb.FileId);
            Assert.AreEqual(stickerSetInfoResultString.Result.Stickers[0].Thumb.Width, stickerSetInfoResult.Result.Stickers[0].Thumb.Width);
            Assert.AreEqual(stickerSetInfoResultString.Result.Stickers[0].Thumb.Height, stickerSetInfoResult.Result.Stickers[0].Thumb.Height);
            Assert.AreEqual(stickerSetInfoResultString.Result.Stickers[0].Thumb.FileSize, stickerSetInfoResult.Result.Stickers[0].Thumb.FileSize);
            Assert.AreEqual(stickerSetInfoResultString.Result.Stickers[0].Emoji, stickerSetInfoResult.Result.Stickers[0].Emoji);
            Assert.AreEqual(stickerSetInfoResultString.Result.Stickers[0].SetName, stickerSetInfoResult.Result.Stickers[0].SetName);
            Assert.AreEqual(Point.chin, stickerSetInfoResult.Result.Stickers[0].MaskPosition.Point);
            Assert.AreEqual(stickerSetInfoResultString.Result.Stickers[0].MaskPosition.X_shift, stickerSetInfoResult.Result.Stickers[0].MaskPosition.XShift);
            Assert.AreEqual(stickerSetInfoResultString.Result.Stickers[0].MaskPosition.Y_shift, stickerSetInfoResult.Result.Stickers[0].MaskPosition.YShift);
            Assert.AreEqual(stickerSetInfoResultString.Result.Stickers[0].MaskPosition.Scale, stickerSetInfoResult.Result.Stickers[0].MaskPosition.Scale);
            Assert.AreEqual(stickerSetInfoResultString.Result.Stickers[0].FileSize, stickerSetInfoResult.Result.Stickers[0].FileSize);
        }
    }
}
