using NUnit.Framework;
using System;
using RestSharp;
using VkApiTest.Api;

namespace VkApiTest
{
    public class SignupTest
    {
        VkApi api = new VkApi { ClientId = "***", ClientSecret = "***" };

        [Test (Description = "There should be sid value if all data was provided")]
        public void PositiveTest()
        {
            var body = new SignupRequest
            {
                first_name = "Иван",
                last_name = "Иванов",
                birthday = "31.10.1991",
                phone = "+79110885340",
                password = "123123Aa",
                test_mode = "1",
                sex = "2"
            };

            SignupResponse res = api.Signup(body);

            Assert.IsNotEmpty(res.response.sid, "there is sid");
        }

        [Test (Description = "There should be error 100 in case of phone number lack")]
        public void NegativeTest()
        {
            var body = new SignupRequest
            {
                first_name = "Иван",
                last_name = "Иванов",
                birthday = "31.10.1991",
                phone = "",
                password = "123123Aa",
                test_mode = "1",
                sex = "2"
            };

            SignupResponse res = api.Signup(body);

            Assert.AreEqual(100, res.error.error_code, "error code is 100");
            Assert.AreEqual("One of the parameters specified was missing or invalid: phone is undefined", res.error.error_msg);
        }
    }
}
