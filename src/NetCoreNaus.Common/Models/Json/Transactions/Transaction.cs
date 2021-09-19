using Newtonsoft.Json;

namespace NetCoreNaus.Common.Models.Json.Transactions
{
    public class Transaction
    {
        [JsonProperty(PropertyName = "id")]
        public string TransactionId { get; set; }

        [JsonProperty(PropertyName = "last_modified_date")]
        public string LastModifiedDate { get; set; }

        [JsonProperty(PropertyName = "last_modified_by")]
        public string LastModifiedBy { get; set; }

        [JsonProperty(PropertyName = "tenant_id")]
        public string TenantId { get; set; }

        [JsonProperty(PropertyName = "site_id")]
        public string SiteId { get; set; }

        [JsonProperty(PropertyName = "transaction_item_id")]
        public int? TransactionItemId { get; set; }

        [JsonProperty(PropertyName = "date_in")]
        public string DateIn { get; set; }

        [JsonProperty(PropertyName = "date_out")]
        public string DateOut { get; set; }

        [JsonProperty(PropertyName = "transaction_log_id")]
        public int? TransactionLogId { get; set; }

        [JsonProperty(PropertyName = "ticket_number")]
        public string TicketNumber { get; set; }

        [JsonProperty(PropertyName = "license_plate")]
        public string LicensePlate { get; set; }

        [JsonProperty(PropertyName = "client_account_number")]
        public string ClientAccountNumber { get; set; }

        [JsonProperty(PropertyName = "client_name")]
        public string ClientName { get; set; }

        [JsonProperty(PropertyName = "client_order_number")]
        public string ClientOrderNumber { get; set; }

        [JsonProperty(PropertyName = "product_code")]
        public string ProductCode { get; set; }

        [JsonProperty(PropertyName = "product_name")]
        public string ProductName { get; set; }

        [JsonProperty(PropertyName = "product_category_code")]
        public string ProductCategoryCode { get; set; }

        [JsonProperty(PropertyName = "source_location_name")]
        public string SourceLocationName { get; set; }

        [JsonProperty(PropertyName = "destination_location_name")]
        public string DestinationLocationName { get; set; }

        [JsonProperty(PropertyName = "tare_weight")]
        public decimal? TareWeight { get; set; }

        [JsonProperty(PropertyName = "stock_unit")]
        public string StockUnit { get; set; }

        [JsonProperty(PropertyName = "gross_weight")]
        public decimal? GrossWeight { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public decimal? Quantity { get; set; }

        [JsonProperty(PropertyName = "price_ex_tax")]
        public decimal? PriceExcludingTax { get; set; }

        [JsonProperty(PropertyName = "price_ex_tax_per_unit")]
        public decimal? PriceExcludingTaxPerUnit { get; set; }

        [JsonProperty(PropertyName = "tax")]
        public decimal? Tax { get; set; }

        [JsonProperty(PropertyName = "epa_levy")]
        public decimal? EpaLevy { get; set; }

        [JsonProperty(PropertyName = "charged_qty")]
        public decimal? ChargedQuantity { get; set; }

        [JsonProperty(PropertyName = "total_ex_tax")]
        public decimal? TotalExcludingTax { get; set; }

        [JsonProperty(PropertyName = "nett_weight_tonnes")]
        public decimal? NettWeightTonnes { get; set; }

        [JsonProperty(PropertyName = "gross_weight_kg")]
        public decimal? GrossWeightInKg { get; set; }

        [JsonProperty(PropertyName = "tare_weight_kg")]
        public decimal? TareWeightInKg { get; set; }

        [JsonProperty(PropertyName = "is_inbound")]
        public bool? IsInbound { get; set; }

        [JsonProperty(PropertyName = "is_inbound_transfer")]
        public bool? IsInboundTransfer { get; set; }

        [JsonProperty(PropertyName = "is_outbound")]
        public bool? IsOutbound { get; set; }

        [JsonProperty(PropertyName = "is_outbound_transfer")]
        public bool? IsOutboundTransfer { get; set; }

        [JsonProperty(PropertyName = "is_internal_movement")]
        public bool? IsInternalMovement { get; set; }

        [JsonProperty(PropertyName = "last_etl_sync")]
        public string LastEtlSync { get; set; }

        [JsonProperty(PropertyName = "cs_timestamp")]
        public string CsTimestamp { get; set; }
    }
}
