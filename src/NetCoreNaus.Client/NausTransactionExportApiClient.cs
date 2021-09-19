using NetCoreNaus.Common;
using NetCoreNaus.Common.Extensions;
using NetCoreNaus.Common.Models.Json.Transactions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetCoreNaus.Client
{
    public class NausTransactionExportApiClient : INausTransactionExportApiClient
    {
        protected readonly JsonHttpClient jsonHttpClient;

        public NausTransactionExportApiClient(string apiGatewayUrl, string txnExportApiEndPoint, string accessToken, string ocpApimSubscriptionKey)
            : this(apiGatewayUrl, txnExportApiEndPoint, accessToken, ocpApimSubscriptionKey, new HttpClient()) {}

        public NausTransactionExportApiClient(string apiGatewayUrl, string txnExportApiEndPoint, string accessToken, string ocpApimSubscriptionKey, 
            HttpClient httpClientForJson, bool callerWillDisposeHttpClients = false)
        {
            if (string.IsNullOrEmpty(apiGatewayUrl)) throw new ArgumentNullException("apiGatewayUrl");
            if (string.IsNullOrEmpty(txnExportApiEndPoint)) throw new ArgumentNullException("txnExportApiEndPoint");
            if (string.IsNullOrEmpty(accessToken)) throw new ArgumentNullException("accessToken");
            if (string.IsNullOrEmpty(ocpApimSubscriptionKey)) throw new ArgumentNullException("ocpApimSubscriptionKey");
            if (httpClientForJson == null) throw new ArgumentNullException("httpClientForJson");
            
            this.jsonHttpClient = new JsonHttpClient(
                apiGatewayUrl, 
                txnExportApiEndPoint, 
                accessToken, 
                ocpApimSubscriptionKey, 
                httpClientForJson, 
                callerWillDisposeHttpClients);
        }

        public async Task<CreateBatchResponse> CreateBatchAsync(CreateBatchRequest request)
        {
            if (request == null) throw new ArgumentNullException("CreateBatchRequest");
            if (string.IsNullOrEmpty(request.TenantId)) throw new ArgumentNullException("TenantId");
            if (string.IsNullOrEmpty(request.TransactionStatus.ToString())) throw new ArgumentNullException("TransactionStatus");

            return await jsonHttpClient
                .HttpPostAsync<CreateBatchResponse>(request.ToUrlSuffix());
        }

        public async Task<GetBatchResponse> GetBatchAsync(GetBatchRequest request)
        {
            if (request == null) throw new ArgumentNullException("GetBatchRequest");
            if (string.IsNullOrEmpty(request.TenantId)) throw new ArgumentNullException("TenantId");
            if (string.IsNullOrEmpty(request.BatchId)) throw new ArgumentNullException("BatchId");

            return await jsonHttpClient
                .HttpGetAsync<GetBatchResponse>(request.ToUrlSuffix());
        }

        public async Task<GetPagedBatchesResponse> GetPagedBatchesAsync(GetPagedBatchesRequest request)
        {
            if (request == null) throw new ArgumentNullException("GetPagedBatchesRequest");
            if (string.IsNullOrEmpty(request.TenantId)) throw new ArgumentNullException("TenantId");
            if (string.IsNullOrEmpty(request.BatchStatus.ToString())) throw new ArgumentNullException("BatchStatus");

            return await jsonHttpClient
                .HttpGetAsync<GetPagedBatchesResponse>(request.ToUrlSuffix());
        }

        public async Task<DiscardBatchResponse> DiscardBatchAsync(DiscardBatchRequest request)
        {
            if (request == null) throw new ArgumentNullException("DiscardBatchRequest");
            if (string.IsNullOrEmpty(request.TenantId)) throw new ArgumentNullException("TenantId");
            if (string.IsNullOrEmpty(request.BatchId)) throw new ArgumentNullException("BatchId");

            return await jsonHttpClient
                .HttpPutAsync<DiscardBatchResponse>(request.ToUrlSuffix());
        }

        public async Task<CommitBatchResponse> CommitBatchAsync(CommitBatchRequest request)
        {
            if (request == null) throw new ArgumentNullException("CommitBatchRequest");
            if (string.IsNullOrEmpty(request.TenantId)) throw new ArgumentNullException("TenantId");
            if (string.IsNullOrEmpty(request.BatchId)) throw new ArgumentNullException("BatchId");

            return await jsonHttpClient
                .HttpPutAsync<CommitBatchResponse>(request.ToUrlSuffix());
        }

        public void Dispose()
        {
            jsonHttpClient.Dispose();
        }
    }
}
