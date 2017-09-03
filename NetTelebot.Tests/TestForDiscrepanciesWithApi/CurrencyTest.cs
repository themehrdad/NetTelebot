using System;
using System.Collections.Generic;
using System.Linq;
using NetTelebot.BotEnum;
using NUnit.Framework;
using RestSharp;

namespace NetTelebot.Tests.TestForDiscrepanciesWithApi
{
    [TestFixture]
    internal  class CurrencyTest
    {
        private static readonly RequestToUri mRequestToUri =
            new RequestToUri(new RestClient("https://core.telegram.org"));

        private readonly List<string> mKeyList = mRequestToUri.GetObject("/bots/payments/currencies.json").Keys.ToList();

        [Test, Timeout(30000)]
        public void ActualCurrenciesJsonEqulsEnumTest()
        {
            Assert.AreEqual(GetEnumList(), mKeyList);
        }

        [Test, Timeout(30000)]
        public  void ComparsionWhenItemsSmallerTest()
        {
            var listEnum = GetEnumList();

            listEnum.Remove("RUB");

            Assert.AreNotEqual(listEnum, mKeyList);

            listEnum = GetEnumList();
            mKeyList.Remove("RUB");

            Assert.AreNotEqual(listEnum, mKeyList);
        }

        [Test, Timeout(30000)]
        public void ComparsionWhenItemsMoreTest()
        {
            var listEnum = GetEnumList();
            
            listEnum.Add("QWP");

            Assert.AreNotEqual(listEnum, mKeyList);

            listEnum = GetEnumList();
            mKeyList.Add("QWP");

            Assert.AreNotEqual(listEnum, mKeyList);
        }

        private static List<string> GetEnumList()
        {
            return Enum.GetValues(typeof (Currency))
                .Cast<Currency>()
                .Select(v => v.ToString())
                .ToList();
        }        
    }
}
