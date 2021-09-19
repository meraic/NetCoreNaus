using Newtonsoft.Json;

namespace NetCoreNaus.Common.Models.Json.Transactions
{
    public class CreateBatchRequest
    {
        [JsonProperty(PropertyName = "tenant_id")]
        public string TenantId;

        [JsonProperty(PropertyName = "site_id")]
        public string SiteId;

        [JsonProperty(PropertyName = "filter.transaction_status")]
        public TransactionStatus TransactionStatus;

        [JsonProperty(PropertyName = "filter.period_start_date")]
        public string PeriodStartDate;

        [JsonProperty(PropertyName = "filter.period_end_date")]
        public string PeriodEndDate;
    }
}
