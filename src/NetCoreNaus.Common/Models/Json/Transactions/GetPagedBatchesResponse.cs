using Newtonsoft.Json;

namespace NetCoreNaus.Common.Models.Json.Transactions
{
    public class GetPagedBatchesResponse : BatchStatusResponse
    {
        [JsonProperty(PropertyName = "value")]
        public PagedBatch PagedBatch;
    }
}
