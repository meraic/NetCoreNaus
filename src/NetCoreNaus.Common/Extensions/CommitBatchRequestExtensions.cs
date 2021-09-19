using NetCoreNaus.Common.Models.Json.Transactions;

namespace NetCoreNaus.Common.Extensions
{
    public static class CommitBatchRequestExtensions
    {
        public static string ToUrlSuffix(this CommitBatchRequest request)
        {
            return $"{request.TenantId}/transactions/commit/{request.BatchId}";
        }
    }
}
