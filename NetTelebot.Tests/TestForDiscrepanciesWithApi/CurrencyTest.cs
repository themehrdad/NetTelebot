using System;
using System.Collections.Generic;
using System.Linq;
using NetTelebot.BotEnum;
using NUnit.Framework;
using RestSharp;

namespace NetTelebot.Tests.TestForDiscrepanciesWithApi
{
    [TestFixture]
    internal static class CurrencyTest
    {
        private static readonly List<string> mKeyList = GetCurrencyList();

        [Test, Timeout(30000)]
        public static void ActualCurrenciesJsonEqualsEnumTest()
        {
            Assert.AreEqual(GetEnumList(), mKeyList);
        }

        [Test, Timeout(30000)]
        public static void ComparsionWhenItemsSmallerTest()
        {
            var listEnum = GetEnumList();

            listEnum.Remove("RUB");

            Assert.AreNotEqual(listEnum, mKeyList);

            listEnum = GetEnumList();
            mKeyList.Remove("RUB");

            Assert.AreNotEqual(listEnum, mKeyList);
        }

        [Test, Timeout(30000)]
        public static void ComparsionWhenItemsMoreTest()
        {
            var listEnum = GetEnumList();
            
            listEnum.Add("QWP");

            Assert.AreNotEqual(listEnum, mKeyList);

            listEnum = GetEnumList();
            mKeyList.Add("QWP");

            Assert.AreNotEqual(listEnum, mKeyList);
        }

        private static List<string> GetCurrencyList()
        {
            RequestToUri requestToUri = new RequestToUri(new RestClient("https://core.telegram.org"));

            dynamic jobject = requestToUri.GetDeserealizeObject(UriConst.mCurencyUri);
            var list = new List<string>();

            foreach (dynamic keys in jobject)
            {
                list.Add(keys.Name.ToString());
            }

            return list;
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
