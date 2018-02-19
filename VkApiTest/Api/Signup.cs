namespace VkApiTest.Api
{
    public class SignupResponse
    {
        public Response response { get; set; }
        public Error error { get; set; }
    }

    public class Response
    {
        public string sid { get; set; }
    }

    public class Error
    {
        public int error_code { get; set; }
        public string error_msg { get; set; }
    }

    public class SignupRequest
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string birthday { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public string test_mode { get; set; }
        public string sex { get; set; }
    }
}
