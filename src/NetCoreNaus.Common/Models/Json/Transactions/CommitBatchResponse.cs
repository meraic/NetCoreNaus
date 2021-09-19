using Newtonsoft.Json;

namespace NetCoreNaus.Common.Models.Json.Transactions
{
    public class CommitBatchResponse : BatchStatusResponse 
    {
        [JsonProperty(PropertyName = "value")]
        public int? Value;
    }
}
