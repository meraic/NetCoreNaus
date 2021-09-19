namespace NetCoreNaus.Common.Models.Json
{
    public class InternalServerErrorResponse : ErrorDetails 
    {
        public InternalServerErrorResponse(string message)
        {
            Message = message;
        }
    }
}
