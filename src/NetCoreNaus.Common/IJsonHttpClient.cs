using NetCoreNaus.Common.Models.Json;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace NetCoreNaus.Common
{
    public interface IJsonHttpClient : IDisposable
    {
        // GET
        Task<T> HttpGetAsync<T>(string urlSuffix);
        Task<T> HttpGetAsync<T>(Uri uri);
        Task<T> HttpGetRestApiAsync<T>(string apiName);

        // POST
        Task<T> HttpPostAsync<T>(object inputObject, string urlSuffix);
        Task<T> HttpPostAsync<T>(object inputObject, Uri uri);
        Task<T> HttpPostRestApiAsync<T>(string apiName, object inputObject);

        //PUT
        Task<T> HttpPutAsync<T>(string urlSuffix);
        Task<T> HttpPutAsync<T>(object inputObject, Uri uri);
    }
}
