using Newtonsoft.Json;

namespace NetCoreNaus.Common.Models.Json
{
    public class AuthToken
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken;

        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken;

        [JsonProperty(PropertyName = "token_type")]
        public string TokenType;

        [JsonProperty(PropertyName = "expires_in")]
        public long TokenExpiry;

        [JsonProperty(PropertyName = "error")]
        public string Error;
    }
}
