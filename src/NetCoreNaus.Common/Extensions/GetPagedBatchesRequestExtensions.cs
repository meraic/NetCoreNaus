using NetCoreNaus.Common.Models.Json.Transactions;

namespace NetCoreNaus.Common.Extensions
{
    public static class GetPagedBatchesRequestExtensions
    {
        public static string ToUrlSuffix(this GetPagedBatchesRequest request)
        {
            var filterQueryString = $"filter.batch_status={request.BatchStatus}";

            if (request.PageNumber > 0)
            {
                filterQueryString = $"{filterQueryString}&page_number={request.PageNumber}";
            }

            if (request.PageSize > 0)
            {
                filterQueryString = $"{filterQueryString}&page_size={request.PageSize}";
            }

            if (!string.IsNullOrEmpty(request.SiteId))
            {
                filterQueryString = $"{filterQueryString}&site_id={request.SiteId}";
            }

            if (!string.IsNullOrEmpty(request.FromtDate))
            {
                filterQueryString = $"{filterQueryString}&filter.date_from={request.FromtDate}";
            }

            if (!string.IsNullOrEmpty(request.ToDate))
            {
                filterQueryString = $"{filterQueryString}&filter.date_to={request.ToDate}";
            }

            if (!string.IsNullOrEmpty(request.FilterDateType))
            {
                filterQueryString = $"{filterQueryString}&filter.filter_date_type={request.FilterDateType}";
            }

            var urlSuffix = $"{request.TenantId}/transactions/batches?{filterQueryString}";

            return urlSuffix;
        }
    }
}
