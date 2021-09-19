using NetCoreNaus.Common.Exceptions;
using NetCoreNaus.Common.Extensions;
using NetCoreNaus.Common.Models.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetCoreNaus.Common
{
    public class AuthenticationClient : IAuthenticationClient, IDisposable
    {
        private readonly HttpClient httpClient;
        private readonly bool disposeHttpClient;
        private const string TokenRequestEndpointUrl = "https://naus-auth-test.azurewebsites.net/oauth/token";

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public string TokenType { get; set; }

        public long TokenExpiry { get; set; }

        public string Error { get; set; }

        public string BillingExtractSubscriptionKey { get; set; }

        public string CSIntegrationSubscriptionKey { get; set; }

        public string ApiGatewayUrl { get; set; }

        public string TransactionExportApiEndPoint { get; set; }

        public AuthenticationClient() : this(new HttpClient())
        {
        }

        public AuthenticationClient(HttpClient httpClient, bool callerWillDisposeHttpClient = false)
        {
            if (httpClient == null) throw new ArgumentNullException("httpClient");
            this.httpClient = httpClient;
            disposeHttpClient = !callerWillDisposeHttpClient;
        }

        public Task ClientCredentialsAsync(string clientId, string clientSecret)
        {
            return ClientCredentialsAsync(clientId, clientSecret, TokenRequestEndpointUrl);
        }

        public async Task ClientCredentialsAsync(string clientId, string clientSecret, string tokenRequestEndpointUrl)
        {
            if (string.IsNullOrEmpty(clientId)) throw new ArgumentNullException("clientId");
            if (string.IsNullOrEmpty(clientSecret)) throw new ArgumentNullException("clientSecret");
            if (string.IsNullOrEmpty(tokenRequestEndpointUrl)) throw new ArgumentNullException("tokenRequestEndpointUrl");
            if (!Uri.IsWellFormedUriString(tokenRequestEndpointUrl, UriKind.Absolute)) throw new FormatException("tokenRequestEndpointUrl");

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret)
            });

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(tokenRequestEndpointUrl),
                Content = content
            };

            var responseMessage = await httpClient.SendAsync(request).ConfigureAwait(false);
            var response = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (responseMessage.IsSuccessStatusCode)
            {
                var authToken = JsonConvert.DeserializeObject<AuthToken>(response);

                AccessToken = authToken.AccessToken;
                RefreshToken = authToken.RefreshToken;
                TokenType = authToken.TokenType;
                TokenExpiry = authToken.TokenExpiry;
                Error = authToken.Error;

                if(AccessToken.IsNullOrEmpty())
                {
                    var error = "There is an error while authenticating the API by grant_type=client_credentials";
                    throw new NausAuthException(error, responseMessage.StatusCode);
                }
            }
            else
            {
                var errorResponse = JsonConvert.DeserializeObject<AuthErrorResponse>(response);
                throw new NausAuthException(errorResponse.Error, responseMessage.StatusCode);
            }
        }

        public void Dispose()
        {
            if (disposeHttpClient)
            {
                httpClient.Dispose();
            }
        }
    }
}
