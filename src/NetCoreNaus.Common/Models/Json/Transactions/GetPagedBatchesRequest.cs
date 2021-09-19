using Newtonsoft.Json;

namespace NetCoreNaus.Common.Models.Json.Transactions
{
    public class GetPagedBatchesRequest
    {
        [JsonProperty(PropertyName = "tenant_id")]
        public string TenantId;

        [JsonProperty(PropertyName = "filter.batch_status")]
        public BatchStatus BatchStatus;

        [JsonProperty(PropertyName = "page_number")]
        public int PageNumber;

        [JsonProperty(PropertyName = "page_size")]
        public int PageSize;

        [JsonProperty(PropertyName = "site_id")]
        public string SiteId;

        [JsonProperty(PropertyName = "filter.date_from")]
        public string FromtDate;

        [JsonProperty(PropertyName = "filter.date_to")]
        public string ToDate;

        [JsonProperty(PropertyName = "filter.filter_date_type")]
        public string FilterDateType;
    }
}
