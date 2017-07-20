
//todo Blank for mock tests

using System;
using System.IO;
using System.Net;
using Funq;
using NUnit.Framework;
using ServiceStack;

namespace NetTelebot.Tests
{
    [TestFixture]
    public class TelegramBotClientTest
    {/*
        [Test]
        public void TestResponse()
        {
            var client = new JsonServiceClient("http://localhost:8080");

            var webAddr = "http://localhost:8080";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = new TelegramBotClient { Token = "token"} .SendMessage(123, "123");

                streamWriter.Write(json);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.WriteLine(result);
            }


        }   */
    }
}
