using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using NetTelebot.BotEnum;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;

namespace NetTelebot.Tests.TestForDiscrepanciesWithApi
{
    [TestFixture]
    internal static class CurrencyTest
    {
        private static readonly RestClient mRestClient = new RestClient("https://core.telegram.org");

        [Test, Timeout(30000)]
        public static void ActualCurrenciesJsonEqulsEnumTest()
        {
            var listEnum = GetEnumList();
            var keys = GetCurrenciesObject().Keys.ToList();
            
            Assert.AreEqual(listEnum, keys);
        }

        [Test, Timeout(30000)]
        public static void ComparsionWhenItemsSmallerTest()
        {
            var listEnum = GetEnumList();
            var keys = GetCurrenciesObject().Keys.ToList();
            listEnum.Remove("RUB");

            Assert.AreNotEqual(listEnum, keys);

            listEnum = GetEnumList();
            keys.Remove("RUB");

            Assert.AreNotEqual(listEnum, keys);
        }

        [Test, Timeout(30000)]
        public static void ComparsionWhenItemsMoreTest()
        {
            var listEnum = GetEnumList();
            var keys = GetCurrenciesObject().Keys.ToList();
            listEnum.Add("QWP");

            Assert.AreNotEqual(listEnum, keys);

            listEnum = GetEnumList();
            keys.Add("QWP");

            Assert.AreNotEqual(listEnum, keys);
        }

        private static List<string> GetEnumList()
        {
            return Enum.GetValues(typeof (Currency))
                .Cast<Currency>()
                .Select(v => v.ToString())
                .ToList();
        }

        public static Dictionary<string, string> GetCurrenciesObject()
        {
            RestRequest request = NewRequest("/bots/payments/currencies.json");
            RestResponse response = (RestResponse) NewResponse(request);
            
            return DeserealizeJson(response);
        }

        private static RestRequest NewRequest(string uri)
        {
            return new RestRequest(uri, Method.GET);
        }

        private static IRestResponse NewResponse(IRestRequest request)
        {
            IRestResponse response = mRestClient.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return response;

            throw new Exception(response.StatusDescription);
        }

        private static Dictionary<string, string> DeserealizeJson(IRestResponse response)
        {
            JsonDeserializer deserial = new JsonDeserializer();
            return deserial.Deserialize<Dictionary<string, string>>(response);
        }
    }
}
