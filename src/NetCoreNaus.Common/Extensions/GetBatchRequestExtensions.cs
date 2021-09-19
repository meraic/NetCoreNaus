using NetCoreNaus.Common.Models.Json.Transactions;

namespace NetCoreNaus.Common.Extensions
{
    public static class GetBatchRequestExtensions
    {
        public static string ToUrlSuffix(this GetBatchRequest request)
        {
            var getBatchApifilter = string.Format("page_number={0}&page_size={1}&batch_id={2}", 
                request.PageNumber, request.PageSize, request.BatchId);

            var urlSuffix = $"{request.TenantId}/transactions/batch?{getBatchApifilter}";

            return urlSuffix;
        }
    }
}
