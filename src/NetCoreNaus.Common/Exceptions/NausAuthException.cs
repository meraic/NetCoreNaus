using NetCoreNaus.Common.Models.Json;
using System;
using System.Net;

namespace NetCoreNaus.Common.Exceptions
{
    public class NausAuthException : Exception
    {
        public string[] Fields { get; private set; }
        public HttpStatusCode HttpStatusCode { get; private set; }
        public ErrorCode Error { get; private set; }

        public NausAuthException(string error)
            : this(ParseError(error))
        {
        }

        public NausAuthException(string error, string[] fields)
            : this(error)
        {
            Fields = fields;
        }

        public NausAuthException(ErrorCode error, string[] fields)
            : this(error)
        {
            Fields = fields;
        }

        public NausAuthException(string error, HttpStatusCode httpStatusCode)
            : this(ParseError(error))
        {
            this.HttpStatusCode = httpStatusCode;
        }

        public NausAuthException(ErrorCode error)
            : base()
        {
            Error = error;
            Fields = new string[0];
            HttpStatusCode = new HttpStatusCode();
        }

        private static ErrorCode ParseError(string error)
        {
            ErrorCode value;
            return Enum.TryParse(error.Replace("_", ""), true, out value) ? value : ErrorCode.Unknown;
        }
    }
}
