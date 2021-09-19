using Newtonsoft.Json;

namespace NetCoreNaus.Common.Models.Json
{
    public class AuthErrorResponse
    {
        [JsonProperty(PropertyName = "error")]
        public string Error;
    }
}
