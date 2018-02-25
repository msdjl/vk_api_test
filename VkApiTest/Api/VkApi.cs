using System;
using RestSharp;
using VkApiTest.Util;

namespace VkApiTest.Api
{
    public class VkApi
    {
        public RestClient Client { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        public VkApi()
        {
            Client = new RestClient
            {
                BaseUrl = new Uri(Configuration.Get("url"))
            };
        }

        public IRestResponse<T> Execute<T>(VkMethods method, Object requestBody) where T : new()
        {
            IRestRequest req = new RestRequest { Resource = EnumUtils.GetEnumDescription(method) }
                .AddParameter("client_id", this.ClientId)
                .AddParameter("client_secret", this.ClientSecret)
                .AddObject(requestBody);
            
            IRestResponse<T> res = this.Client.Execute<T>(req);
            Console.WriteLine(res.Content);
            return res;
        }

        public IRestResponse<SignupResponse> Signup(SignupRequest requestBody) => Execute<SignupResponse>(VkMethods.Signup, requestBody);
    }
}