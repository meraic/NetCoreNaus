using System;
using System.Net;

namespace NetCoreNaus.Common.Internals
{
    internal sealed class BaseHttpClientException : Exception
    {
        private readonly HttpStatusCode httpStatusCode;

        internal BaseHttpClientException(string response, HttpStatusCode statusCode) : base(response)
        {
            this.httpStatusCode = statusCode;
        }

        internal HttpStatusCode GetStatus()
        {
            return httpStatusCode;
        }
    }
}
