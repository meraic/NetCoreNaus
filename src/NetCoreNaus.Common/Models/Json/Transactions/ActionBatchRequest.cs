using Newtonsoft.Json;

namespace NetCoreNaus.Common.Models.Json.Transactions
{
    public class ActionBatchRequest
    {
        [JsonProperty(PropertyName = "tenant_id")]
        public string TenantId;

        [JsonProperty(PropertyName = "batch_id")]
        public string BatchId;
    }
}
