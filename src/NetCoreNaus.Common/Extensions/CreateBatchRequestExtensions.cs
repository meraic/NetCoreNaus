using NetCoreNaus.Common.Models.Json.Transactions;

namespace NetCoreNaus.Common.Extensions
{
    public static class CreateBatchRequestExtensions
    {
        public static string ToUrlSuffix(this CreateBatchRequest request)
        {
            var createBatchApifilter = $"filter.transaction_status={request.TransactionStatus}";

            if (!string.IsNullOrEmpty(request.SiteId))
            {
                createBatchApifilter = $"{createBatchApifilter}&site_id={request.SiteId}";
            }

            if (!string.IsNullOrEmpty(request.PeriodStartDate))
            {
                createBatchApifilter = $"{createBatchApifilter}&filter.period_start_date={request.PeriodStartDate}";
            }

            if (!string.IsNullOrEmpty(request.PeriodEndDate))
            {
                createBatchApifilter = $"{createBatchApifilter}&filter.period_end_date={request.PeriodEndDate}";
            }

            var urlSuffix = $"{request.TenantId}/transactions/create?{createBatchApifilter}";

            return urlSuffix;
        }
    }
}
