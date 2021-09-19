using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace NetCoreNaus.Common.Models.Json
{
    public class AuthResourceOwnerToken
    {
        [JsonProperty(PropertyName = "accessToken")]
        public string AccessToken;

        [JsonProperty(PropertyName = "data")]
        public string Data;

        [JsonProperty(PropertyName = "errors")]
        public List<string> Errors;

        [JsonProperty(PropertyName = "fail")]
        public bool AuthFailed;

        [JsonProperty(PropertyName = "expiresOn")]
        public DateTime ExpiryDateTimeUtc;

        [JsonProperty(PropertyName = "type")]
        public string AuthenticationType;
    }
}
