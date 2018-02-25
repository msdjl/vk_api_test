using RestSharp.Deserializers;
using SimpleJson;

namespace VkApiTest.Api
{
    public class SignupResponse
    {
        [DeserializeAs(Name="response")]
        public ResponseField Response { get; set; }

        [DeserializeAs(Name = "error")]
        public ErrorField Error { get; set; }

        public class ResponseField
        {
            [DeserializeAs(Name = "sid")]
            public string Sid { get; set; }
        }

        public class ErrorField
        {
            [DeserializeAs(Name = "error_code")]
            public int ErrorCode { get; set; }

            [DeserializeAs(Name = "error_msg")]
            public string ErrorMsg { get; set; }
        }
    }
}
