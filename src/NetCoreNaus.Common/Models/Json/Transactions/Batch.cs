using Newtonsoft.Json;

namespace NetCoreNaus.Common.Models.Json.Transactions
{
    public class Batch
    {
        [JsonProperty(PropertyName = "batch_id")]
        public string Id;

        [JsonProperty(PropertyName = "tenant_id")]
        public string TenantId;

        [JsonProperty(PropertyName = "site_id")]
        public string SiteId;

        [JsonProperty(PropertyName = "unfiltered_results")]
        public UnfilteredResult UnfilteredResults;

        [JsonProperty(PropertyName = "filter_type")]
        public string FilterType;

        [JsonProperty(PropertyName = "period_start_date")]
        public string PeriodStartDate;

        [JsonProperty(PropertyName = "period_end_date")]
        public string PeriodEndDate;

        [JsonProperty(PropertyName = "status")]
        public BatchStatus Status;

        [JsonProperty(PropertyName = "status_date")]
        public string StatusDate;

        [JsonProperty(PropertyName = "date_created")]
        public string CreatedDate;

        [JsonProperty(PropertyName = "date_modified")]
        public string ModifiedDate;

        [JsonProperty(PropertyName = "filtered_results")]
        public FilteredResult FilteredResults;
    }
}
