using System;
using System.Net;
using RestSharp;

namespace NetTelebot.Tests.TestForDiscrepanciesWithApi
{
    internal class RequestToUri
    {
        private readonly RestClient mRestClient;

        internal RequestToUri(RestClient restClient)
        {
            mRestClient = restClient;
        }

        internal dynamic GetDeserealizeObject(string uri)
        {
            RestRequest request = NewRequest(uri);
            RestResponse response = (RestResponse)NewResponse(request);

            return Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);
        }

        private static RestRequest NewRequest(string uri)
        {
            return new RestRequest(uri, Method.GET);
        }

        private IRestResponse NewResponse(IRestRequest request)
        {
            IRestResponse response = mRestClient.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return response;

            throw new Exception(response.StatusDescription);
        }
    }

    internal static class UriConst
    {
        internal const string mCurencyUri = "/bots/payments/currencies.json";
        internal const string mCountriesUri = "/mledoze/countries/master/countries.json";
    }
}
