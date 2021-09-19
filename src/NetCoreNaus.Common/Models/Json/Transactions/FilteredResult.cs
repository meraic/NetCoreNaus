using Newtonsoft.Json;

namespace NetCoreNaus.Common.Models.Json.Transactions
{
    public class FilteredResult
    {
        [JsonProperty(PropertyName = "status")]
        public string Status;

        [JsonProperty(PropertyName = "status_date")]
        public string StatusDate;

        [JsonProperty(PropertyName = "num_records")]
        public int? NumberOfRecords;

        [JsonProperty(PropertyName = "total_amount_inc_tax")]
        public decimal? TotalAmountIncludingTax;
    }
}
