
using System;
using System.Collections.Generic;
using NUnit.Framework;
using RestSharp;

namespace NetTelebot.Tests.TestForDiscrepanciesWithApi
{
    [TestFixture]
    internal class CountriesTest
    {
        private static readonly RequestToUri mRequestToUri =
            new RequestToUri(new RestClient("https://raw.githubusercontent.com"));

        //private readonly Dictionary<string, string> mKeyList =
        //    mRequestToUri.GetObject("/mledoze/countries/blob/master/countries.json");

        [Test, Ignore("In process")]
        public void TestRequest()
        {
            Dictionary<string, string> mKeyList =
                mRequestToUri.GetObject("/mledoze/countries/master/countries.json");

            foreach (var keys in mKeyList.Keys)
            {
                Console.WriteLine(keys);
            }
        }

    }
}
