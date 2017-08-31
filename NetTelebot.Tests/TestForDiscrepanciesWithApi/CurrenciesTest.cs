using System;
using System.Net;
using NUnit.Framework;
using RestSharp;

namespace NetTelebot.Tests.TestForDiscrepanciesWithApi
{
    [TestFixture]
    internal static class CurrenciesTest
    {
        [Test]
        public static void RunTest()
        {
            Console.WriteLine(GetCurrenciesObject());
        }

        public static string GetCurrenciesObject()
        {
            RestClient RestClient = new RestClient("https://core.telegram.org");

            RestRequest request = new RestRequest("/bots/payments/currencies.json", Method.GET);

            IRestResponse response = RestClient.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return response.Content;

            throw new Exception(response.StatusDescription);
        }
    }
}
