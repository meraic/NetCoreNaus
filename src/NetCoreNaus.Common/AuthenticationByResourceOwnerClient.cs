using NetCoreNaus.Common.Exceptions;
using NetCoreNaus.Common.Extensions;
using NetCoreNaus.Common.Models.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetCoreNaus.Common
{
    public class AuthenticationClientByResourceOwner : IAuthenticationClientByResourceOwner, IDisposable
    {
        private readonly HttpClient httpClient;
        private readonly bool disposeHttpClient;
        private const string TokenRequestEndpointUrl = "https://developers.naus.com/oauth2/resourceownerpassword/acquiretoken";

        public string AccessToken { get; set; }

        public DateTime TokenExpiryUtc { get; set; }

        public string TokenType { get; set; }

        public List<string> Errors { get; set; }

        public bool AuthFailed { get; set; }

        public string BillingExtractSubscriptionKey { get; set; }

        public string CSIntegrationSubscriptionKey { get; set; }

        public string ApiGatewayUrl { get; set; }

        public string TransactionExportApiEndPoint { get; set; }

        public AuthenticationClientByResourceOwner() : this(new HttpClient())
        {
        }

        public AuthenticationClientByResourceOwner(HttpClient httpClient, bool callerWillDisposeHttpClient = false)
        {
            if (httpClient == null) throw new ArgumentNullException("httpClient");
            this.httpClient = httpClient;
            disposeHttpClient = !callerWillDisposeHttpClient;
        }

        public Task UsernamePasswordAsync(string apiId, string username, string password)
        {
            return UsernamePasswordAsync(apiId, username, password, TokenRequestEndpointUrl);
        }

        public async Task UsernamePasswordAsync(string apiId, string username, string password, string tokenRequestEndpointUrl)
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentNullException("username");
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException("password");
            if (string.IsNullOrEmpty(tokenRequestEndpointUrl)) throw new ArgumentNullException("tokenRequestEndpointUrl");
            if (!Uri.IsWellFormedUriString(tokenRequestEndpointUrl, UriKind.Absolute)) throw new FormatException("tokenRequestEndpointUrl");

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("apiId", apiId),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("useTestUser", "false")
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
                var authToken = JsonConvert.DeserializeObject<AuthResourceOwnerToken>(response);

                AccessToken = authToken.AccessToken;
                TokenExpiryUtc = authToken.ExpiryDateTimeUtc;
                Errors = authToken.Errors;
                AuthFailed = authToken.AuthFailed;
                TokenExpiryUtc = authToken.ExpiryDateTimeUtc;

                if (AccessToken.IsNullOrEmpty())
                {
                    string errorResponse = Errors.FirstOrDefault();
                    throw new NausAuthException(errorResponse, responseMessage.StatusCode);
                }
            }
            else
            {
                //var errorResponse = JsonConvert.DeserializeObject<AuthErrorResponse>(response);
                string errorResponse = "There is an error returned from api for resource owner password";
                throw new NausAuthException(errorResponse, responseMessage.StatusCode);
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
