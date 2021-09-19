using Newtonsoft.Json;

namespace NetCoreNaus.Common.Models.Json.Transactions
{
    public class GetBatchRequest
    {
        [JsonProperty(PropertyName = "tenant_id")]
        public string TenantId;

        [JsonProperty(PropertyName = "page_number")]
        public int PageNumber;

        [JsonProperty(PropertyName = "page_size")]
        public int PageSize;

        [JsonProperty(PropertyName = "batch_id")]
        public string BatchId;
    }
}
