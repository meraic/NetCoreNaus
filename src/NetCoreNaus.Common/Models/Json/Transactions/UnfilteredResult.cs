using Newtonsoft.Json;

namespace NetCoreNaus.Common.Models.Json.Transactions
{
    public class UnfilteredResult
    {
        [JsonProperty(PropertyName = "num_records")]
        public int? NumberOfRecords;

        [JsonProperty(PropertyName = "total_amount_inc_tax")]
        public decimal? TotalAmountIncludingTax;
    }
}
