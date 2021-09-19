﻿using Newtonsoft.Json;

namespace NetCoreNaus.Common.Models.Json.Transactions
{
    public class DiscardBatchErrorResponse
    {
        [JsonProperty(PropertyName = "status")]
        public string Status;

        [JsonProperty(PropertyName = "status_code")]
        public string StatusCode;

        [JsonProperty(PropertyName = "message")]
        public string Message;
    }
}
