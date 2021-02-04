using Diba.Desktop.Common;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diba.Desktop.Internal.DibaCore
{
    public class RestProvider
    {
        private static IRestClient Client = null;
        public static IRestClient GetInstance()
        {
            if (Client == null)
            {
                Client = new RestSharp.RestClient(DibaServiceConfiguration.Instance.EndPoint);

                // Override with Newtonsoft JSON Handler
                Client.AddHandler("application/json", () => NewtonsoftJsonSerializer.Default);
                Client.AddHandler("text/json", () => NewtonsoftJsonSerializer.Default);
                Client.AddHandler("text/x-json", () => NewtonsoftJsonSerializer.Default);
                Client.AddHandler("text/javascript", () => NewtonsoftJsonSerializer.Default);
                Client.AddHandler("*+json", () => NewtonsoftJsonSerializer.Default);
                return Client;
            }
            else
                return Client;
        }

        public static IRestClient Renew()
        {
            Client = new RestSharp.RestClient(DibaServiceConfiguration.Instance.EndPoint);

            // Override with Newtonsoft JSON Handler
            Client.AddHandler("application/json", () => NewtonsoftJsonSerializer.Default);
            Client.AddHandler("text/json", () => NewtonsoftJsonSerializer.Default);
            Client.AddHandler("text/x-json", () => NewtonsoftJsonSerializer.Default);
            Client.AddHandler("text/javascript", () => NewtonsoftJsonSerializer.Default);
            Client.AddHandler("*+json", () => NewtonsoftJsonSerializer.Default);
            return Client;
        }
    }
}
