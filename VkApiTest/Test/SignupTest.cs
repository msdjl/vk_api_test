using NUnit.Framework;
using System;
using RestSharp;
using VkApiTest.Api;
using System.Net;
using VkApiTest.Util;

namespace VkApiTest
{
    public class SignupTest
    {
        VkApi Api = new VkApi
        {
            ClientId = Configuration.Get("clients:client1:client_id"),
            ClientSecret = Configuration.Get("clients:client1:client_secret")
        };

        [Test (Description = "There should be sid value if all data were provided")]
        public void PositiveTest()
        {
            SignupRequest BodyWithAllData = new SignupRequest
            {
                first_name = "Иван",
                last_name = "Иванов",
                birthday = "31.10.1991",
                phone = "+79110885340",
                password = "123123Aa",
                test_mode = "1",
                sex = "2"
            };
            IRestResponse<SignupResponse> res = Api.Signup(BodyWithAllData);
            SignupResponse resData = res.Data;

            Assert.AreEqual(HttpStatusCode.OK, res.StatusCode, "Http status is 200 OK"); // probably raw response might be useful in such cases
            Assert.IsNotEmpty(resData.Response.Sid, "There is sid");
        }

        [Test (Description = "There should be error 100 in case of phone number lack")]
        public void NegativeTest()
        {
            SignupRequest BodyWithoutPhone = new SignupRequest
            {
                first_name = "Иван",
                last_name = "Иванов",
                birthday = "31.10.1991",
                phone = "",
                password = "123123Aa",
                test_mode = "1",
                sex = "2"
            };
            SignupResponse res = Api.Signup(BodyWithoutPhone).Data;

            Assert.AreEqual(100, res.Error.ErrorCode, "Error code is 100");
            Assert.AreEqual("One of the parameters specified was missing or invalid: phone is undefined", res.Error.ErrorMsg);
        }
    }
}
