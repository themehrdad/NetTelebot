using System;
using System.Collections.Generic;
using System.Linq;
using NetTelebot.BotEnum;
using NUnit.Framework;
using RestSharp;

namespace NetTelebot.Tests.TestForDiscrepanciesWithApi
{
    [TestFixture]
    internal static class CountriesTest
    {
        
        [Test, Timeout(30000)]
        public static void ActualCountriesJsonEqualsWithEnumTest()
        {
            Assert.AreEqual(GetCountriesList(), GetCountriesEnumList());
        }

        private static List<string> GetCountriesList()
        {
            RequestToUri requestToUri = new RequestToUri(new RestClient("https://raw.githubusercontent.com"));

            dynamic jobject = requestToUri.GetDeserealizeObject(UriConst.mCountriesUri);
            var list = new List<string>();

            foreach (dynamic keys in jobject)
            {
                list.Add(keys.cca2.ToString());
            }

            return list;
        }

        private static List<string> GetCountriesEnumList()
        {
            return Enum.GetValues(typeof(Countries))
                .Cast<Countries>()
                .Select(v => v.ToString())
                .ToList();
        }
    }
}
