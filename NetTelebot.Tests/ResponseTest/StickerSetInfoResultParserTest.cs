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
                    Stickers = 
                    
                }


            };

        }
    }
}
