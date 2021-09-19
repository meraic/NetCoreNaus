using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreNaus.Common.Internals
{
    public abstract class BaseHttpClient : IDisposable
    {
        private readonly string contentType;
        private readonly bool disposeHttpClient;

        protected readonly string ApiGatewayUrl;
        protected readonly string ApiEndpoint;
        protected readonly HttpClient HttpClient;

        internal BaseHttpClient(string apiGatewayUrl, string apiEndPoint, string contentType, HttpClient httpClient, bool callerWillDisposeHttpClient = false)
        {
            if (string.IsNullOrEmpty(apiGatewayUrl)) throw new ArgumentNullException("apiGatewayUrl");
            if (string.IsNullOrEmpty(apiEndPoint)) throw new ArgumentNullException("apiEndPoint");
            if (string.IsNullOrEmpty(contentType)) throw new ArgumentNullException("contentType");
            if (httpClient == null) throw new ArgumentNullException("httpClient");

            ApiGatewayUrl = apiGatewayUrl;
            ApiEndpoint = apiEndPoint;
            this.contentType = contentType;
            this.disposeHttpClient = !callerWillDisposeHttpClient;
            HttpClient = httpClient;

            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
        }

        protected async Task<string> HttpGetAsync(Uri uri)
        {
            var responseMessage = await HttpClient.GetAsync(uri).ConfigureAwait(false);
            if (responseMessage.StatusCode == HttpStatusCode.NoContent)
            {
                return "{}";
            }

            var response = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                return response;
            }

            throw new BaseHttpClientException(response, responseMessage.StatusCode);
        }

        protected async Task<string> HttpPostAsync(string payload, Uri uri)
        {
            var content = new StringContent(payload, Encoding.UTF8, contentType);

            var responseMessage = await HttpClient.PostAsync(uri, content).ConfigureAwait(false);

            if (responseMessage.StatusCode == HttpStatusCode.NoContent)
            {
                return string.Empty;
            }
            
            var response = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                return response;
            }

            throw new BaseHttpClientException(response, responseMessage.StatusCode);
        }

        protected async Task<string> HttpPutAsync(string payload, Uri uri)
        {
            var content = new StringContent(payload, Encoding.UTF8, contentType);

            var request = new HttpRequestMessage
            {
                RequestUri = uri,
                Method = new HttpMethod("PUT"),
                Content = content
            };

            var responseMessage = await HttpClient.SendAsync(request).ConfigureAwait(false);

            if (responseMessage.StatusCode == HttpStatusCode.NoContent)
            {
                return string.Empty;
            }

            var response = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                return response;
            }

            throw new BaseHttpClientException(response, responseMessage.StatusCode);
        }

        public void Dispose()
        {
            if (disposeHttpClient)
            {
                HttpClient.Dispose();
            }
        }
    }
}
