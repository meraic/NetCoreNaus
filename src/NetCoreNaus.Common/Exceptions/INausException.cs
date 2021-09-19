using System;
using System.Collections;

namespace NetCoreNaus.Common.Exceptions
{
    public interface INausException
    {
        Exception GetBaseException();
        string ToString();
        IDictionary Data { get; }
        Exception InnerException { get; }
        string Message { get; }
        string StackTrace { get; }
    }
}
