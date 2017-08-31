using System;
using System.Collections.Generic;
using System.Net;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;

namespace NetTelebot.Tests.TestForDiscrepanciesWithApi
{
    [TestFixture]
    internal static class CurrenciesTest
    {
        [Test]
        public static void RunTest()
        {
            foreach (var keys in GetCurrenciesObject().Keys)
            {
                Console.WriteLine(keys);
            }
        }

        public static Dictionary<string, string> GetCurrenciesObject()
        {
            RestClient RestClient = new RestClient("https://core.telegram.org");

            RestRequest request = new RestRequest("/bots/payments/currencies.json", Method.GET);

            IRestResponse response = RestClient.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return DeserealizeString(response);

            throw new Exception(response.StatusDescription);
        }

        private static Dictionary<string, string> DeserealizeString(IRestResponse response)
        {
            JsonDeserializer deserial = new JsonDeserializer();
            return deserial.Deserialize<Dictionary<string, string>>(response);
        }
    }
}
