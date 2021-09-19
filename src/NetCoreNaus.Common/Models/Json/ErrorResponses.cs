using Newtonsoft.Json;

namespace NetCoreNaus.Common.Models.Json
{
    public class ErrorResponse : ErrorDetails
    {
        [JsonProperty(PropertyName = "errors")]
        public Error[] Errors;
    }

    public class NotFoundErrorResponse : ErrorDetails
    {
        public NotFoundErrorResponse(string message)
        {
            Message = message;
        }
    }    
}
