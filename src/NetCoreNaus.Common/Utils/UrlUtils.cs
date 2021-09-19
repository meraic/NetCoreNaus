using NetCoreNaus.Common.Models.Json;
using System;

namespace NetCoreNaus.Common.Utils
{
    public static class UrlUtils
    {
        public static Uri FormatUrl(string resourceName, string apiGatewayUrl)
        {
            if (string.IsNullOrEmpty(resourceName)) throw new ArgumentNullException("resourceName");
            if (string.IsNullOrEmpty(apiGatewayUrl)) throw new ArgumentNullException("apiGatewayUrl");

            return new Uri(new Uri(apiGatewayUrl), $"/{resourceName}");
        }

        public static Uri FormatUrl(string resourceName, string apiEndPoint, string apiGatewayUrl)
        {
            if (string.IsNullOrEmpty(resourceName)) throw new ArgumentNullException("resourceName");
            if (string.IsNullOrEmpty(apiEndPoint)) throw new ArgumentNullException("apiEndPoint");
            if (string.IsNullOrEmpty(apiGatewayUrl)) throw new ArgumentNullException("apiGatewayUrl");

            return new Uri(new Uri(apiGatewayUrl), $"/{apiEndPoint}/{resourceName}");
        }

        public static Uri FormatRestApiUrl(string customApi, string apiGatewayUrl)
        {
            if (string.IsNullOrEmpty(customApi)) throw new ArgumentNullException("customApi");
            if (string.IsNullOrEmpty(apiGatewayUrl)) throw new ArgumentNullException("apiGatewayUrl");

            return new Uri($"{apiGatewayUrl}/{customApi}");
        }

        public static string FormatRefreshTokenUrl(
            string tokenRefreshUrl,
            string clientId,
            string refreshToken,
            string clientSecret = "")
        {
            if (tokenRefreshUrl == null) throw new ArgumentNullException("tokenRefreshUrl");
            if (clientId == null) throw new ArgumentNullException("clientId");
            if (refreshToken == null) throw new ArgumentNullException("refreshToken");

            var clientSecretQuerystring = "";
            if (!string.IsNullOrEmpty(clientSecret))
            {
                clientSecretQuerystring = string.Format("&client_secret={0}", clientSecret);
            }

            var url =
            string.Format(
                "{0}?grant_type=refresh_token&client_id={1}{2}&refresh_token={3}",
                tokenRefreshUrl,
                clientId,
                clientSecretQuerystring,
                refreshToken);

            return url;
        }
    }
}
