using Newtonsoft.Json;

namespace NetCoreNaus.Common.Models.Json
{
    public class ErrorDetails
    {
        [JsonProperty(PropertyName = "message")]
        public string Message;

        [JsonProperty(PropertyName = "developer_message")]
        public string DeveloperMessage;

        [JsonProperty(PropertyName = "request_id")]
        public string RequestId;
    }
}
