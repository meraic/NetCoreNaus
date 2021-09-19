using NetCoreNaus.Common.Models.Json.Transactions;

namespace NetCoreNaus.Common.Extensions
{
    public static class DiscardBatchRequestExtensions
    {
        public static string ToUrlSuffix(this DiscardBatchRequest request)
        {
            return $"{request.TenantId}/transactions/discard/{request.BatchId}";
        }
    }
}
