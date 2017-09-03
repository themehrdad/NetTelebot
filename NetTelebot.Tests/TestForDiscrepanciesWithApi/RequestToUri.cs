using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Deserializers;

namespace NetTelebot.Tests.TestForDiscrepanciesWithApi
{
    internal class RequestToUri
    {
        private readonly RestClient mRestClient;

        internal RequestToUri(RestClient restClient)
        {
            mRestClient = restClient;
        }

        internal Dictionary<string, string> GetObject(string uri)
        {
            RestRequest request = NewRequest(uri);
            RestResponse response = (RestResponse)NewResponse(request);
            
            return DeserealizeJson(response);
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

        private static Dictionary<string, string> DeserealizeJson(IRestResponse response)
        {
            JsonDeserializer deserial = new JsonDeserializer();

           // deserial.Deserialize<List<Dictionary<string, string>>>(response);

            return deserial.Deserialize<Dictionary<string, string>>(response);
        }
    }
}
