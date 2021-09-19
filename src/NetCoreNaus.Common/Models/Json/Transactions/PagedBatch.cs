using Newtonsoft.Json;

namespace NetCoreNaus.Common.Models.Json.Transactions
{
    public class PagedBatch
    {
        [JsonProperty(PropertyName = "data")]
        public Batch[] Batches;

        [JsonProperty(PropertyName = "page_number")]
        public int? PageNumber;

        [JsonProperty(PropertyName = "page_size")]
        public int? PageSize;

        [JsonProperty(PropertyName = "total")]
        public int? TotalCount;

        [JsonProperty(PropertyName = "total_pages")]
        public int? TotalPageCount;
    }
}
