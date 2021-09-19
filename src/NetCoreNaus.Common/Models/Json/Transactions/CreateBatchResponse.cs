using Newtonsoft.Json;

namespace NetCoreNaus.Common.Models.Json.Transactions
{
    public class CreateBatchResponse : BatchStatusResponse
    {
        [JsonProperty(PropertyName = "value")]
        public Batch Batch;
    }
}
