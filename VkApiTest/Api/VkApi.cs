using System;
using RestSharp;

namespace VkApiTest.Api
{
    public class VkApi
    {
        public RestClient Client;
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        public VkApi()
        {
            Client = new RestClient();
            Client.BaseUrl = new Uri("https://api.vk.com/method/");
        }

        public IRestRequest CreateRequest(String Resource)
        {
            return new RestRequest { Resource = Resource }
                .AddParameter("client_id", this.ClientId)
                .AddParameter("client_secret", this.ClientSecret);
        }

        public SignupResponse Signup(SignupRequest RequestBody) {
            var req = this.CreateRequest("auth.signup");
            req.AddObject(RequestBody);
            var res = this.Client.Execute<SignupResponse>(req);
            Console.WriteLine(res.Content);
            return res.Data;
        }
    }
}
