using Newtonsoft.Json;

namespace NetCoreNaus.Common.Models.Json.Transactions
{
    public class BatchStatusResponse
    {
        [JsonProperty(PropertyName = "status")]
        public string Status;

        [JsonProperty(PropertyName = "status_code")]
        public string StatusCode;

        [JsonProperty(PropertyName = "message")]
        public string Message;

        [JsonProperty(PropertyName = "messages")]
        public string[] Messages;

        [JsonProperty(PropertyName = "validation_errors")]
        public ValidationError ValidationErrors;
    }
}
