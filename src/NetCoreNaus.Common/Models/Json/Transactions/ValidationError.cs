using Newtonsoft.Json;

namespace NetCoreNaus.Common.Models.Json.Transactions
{
    public class ValidationError
    {
        [JsonProperty(PropertyName = "errors")]
        public Error[] Errors;

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "developer_message")]
        public string DeveloperMessage;

        [JsonProperty(PropertyName = "request_id")]
        public string RequestId { get; set; }
    }
}
