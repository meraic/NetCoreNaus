using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NetCoreNaus.Common.Internals;
using NetCoreNaus.Common.Models.Json;
using NetCoreNaus.Common.Serializer;
using NetCoreNaus.Common.Exceptions;
using NetCoreNaus.Common.Utils;
using System.Net;

namespace NetCoreNaus.Common
{
    public class JsonHttpClient : BaseHttpClient, IJsonHttpClient
    {
        private const string DateFormat = "s";

        public JsonHttpClient(
            string apiGatewayUrl, 
            string apiEndPoint, 
            string accessToken, 
            string ocpApimSubscriptionKey, 
            HttpClient httpClient, 
            bool callerWillDisposeHttpClient = false) : base(apiGatewayUrl, apiEndPoint, "application/json", httpClient, callerWillDisposeHttpClient)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", ocpApimSubscriptionKey);
        }

        // GET

        public async Task<T> HttpGetAsync<T>(string urlSuffix)
        {
            var url = UrlUtils.FormatUrl(urlSuffix, ApiEndpoint, ApiGatewayUrl);
            return await HttpGetAsync<T>(url);
        }

        public async Task<T> HttpGetAsync<T>(Uri uri)
        {
            try
            {
                var response = await HttpGetAsync(uri);

                var jToken = JToken.Parse(response);
                if (jToken?.Type == JTokenType.Array)
                {
                    var jArray = JArray.Parse(response);
                    return JsonConvert.DeserializeObject<T>(jArray.ToString());
                }
                
                try
                {
                    var jObject = JObject.Parse(response);
                    return JsonConvert.DeserializeObject<T>(jObject.ToString());
                }
                catch
                {
                    return JsonConvert.DeserializeObject<T>(response);
                }
            }
            catch (BaseHttpClientException e)
            {
                throw ParseNausException(e.Message, e.GetStatus());
            }
        }

        public async Task<T> HttpGetRestApiAsync<T>(string apiName)
        {
            var url = UrlUtils.FormatRestApiUrl(apiName, ApiGatewayUrl);
            return await HttpGetAsync<T>(url);
        }

        // POST

        public async Task<T> HttpPostAsync<T>(object inputObject, string urlSuffix)
        {
            var url = UrlUtils.FormatUrl(urlSuffix, ApiEndpoint, ApiGatewayUrl);
            return await HttpPostAsync<T>(inputObject, url);
        }

        public async Task<T> HttpPostAsync<T>(string urlSuffix)
        {
            var url = UrlUtils.FormatUrl(urlSuffix, ApiEndpoint, ApiGatewayUrl);
            return await HttpPostAsync<T>(null, url);
        }

        public async Task<T> HttpPostAsync<T>(object inputObject, Uri uri)
        {
            var json = JsonConvert.SerializeObject(inputObject,
                   Formatting.None,
                   new JsonSerializerSettings
                   {
                       NullValueHandling = NullValueHandling.Ignore,
                       ContractResolver = new CreateableContractResolver(),
                       DateFormatString = DateFormat
                   });
            try
            {
                var response = await HttpPostAsync(json, uri);
                return JsonConvert.DeserializeObject<T>(response);
            }
            catch (BaseHttpClientException e)
            {
                throw ParseNausException(e.Message, e.GetStatus());
            }
        }

        public async Task<T> HttpPostRestApiAsync<T>(string apiName, object inputObject)
        {
            var url = UrlUtils.FormatRestApiUrl(apiName, ApiGatewayUrl);
            return await HttpPostAsync<T>(inputObject, url);
        }
        
        // PUT

        public async Task<T> HttpPutAsync<T>(string urlSuffix)
        {
            var url = UrlUtils.FormatUrl(urlSuffix, ApiEndpoint, ApiGatewayUrl);
            return await HttpPutAsync<T>(null, url);
        }

        public async Task<T> HttpPutAsync<T>(object inputObject, Uri uri)
        {
            var json = JsonConvert.SerializeObject(inputObject,
                Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new UpdateableContractResolver(),
                    DateFormatString = DateFormat
                });
            try
            {
                var response = await base.HttpPutAsync(json, uri);
                return JsonConvert.DeserializeObject<T>(response);
            }
            catch (BaseHttpClientException e)
            {
                throw ParseNausException(e.Message, e.GetStatus());
            }
        }

        private static NausException ParseNausException(string responseMessage, HttpStatusCode httpStatusCode)
        {
            if (httpStatusCode == HttpStatusCode.NotFound)
            {
                var notFoundErrorResponse = new NotFoundErrorResponse("The requested URL can not be found");
                return new NausException(notFoundErrorResponse.Message, httpStatusCode);
            }

            if (httpStatusCode == HttpStatusCode.InternalServerError)
            {
                var internalServerErrorResponse = JsonConvert.DeserializeObject<InternalServerErrorResponse>(responseMessage);
                return new NausException(internalServerErrorResponse.Message, httpStatusCode);
            }

            //Hack for Discard Barch Bad Request response type as it is not correctly defined inline with other Bad Request response type
            if (httpStatusCode == HttpStatusCode.BadRequest && responseMessage.Contains("validation_errors"))
            {
                var badRequestResponse = JsonConvert.DeserializeObject<BadRequestErrorResponse>(responseMessage);
                return new NausException(badRequestResponse.Message, httpStatusCode);
            }

            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseMessage);

            if (errorResponse.Errors == null)
            {
                return new NausException(errorResponse.Message, httpStatusCode);
            }

            return new NausException(errorResponse.Errors, errorResponse.Message, httpStatusCode);
        }
    }
}
