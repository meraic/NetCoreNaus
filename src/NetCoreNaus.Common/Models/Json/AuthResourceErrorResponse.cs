using Newtonsoft.Json;

namespace NetCoreNaus.Common.Models.Json
{
    public class AuthResourceErrorResponse
    {
        [JsonProperty(PropertyName = "error")]
        public string Error;
    }
}
