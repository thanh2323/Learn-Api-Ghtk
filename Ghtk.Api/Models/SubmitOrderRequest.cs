﻿namespace Ghtk.Api.Models
{
    using System;
    using System.Collections.Generic;

    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Globalization;

    public partial class SubmitOrderRequest
    {
        [JsonPropertyName("products")]
        public Product[] Products { get; set; }

        [JsonPropertyName("order")]
        public SubmitOrderRequestOrder Order { get; set; }
    }

    public class SubmitOrderRequestOrder
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("pick_name")]
        public string PickName { get; set; }

        [JsonPropertyName("pick_address")]
        public string PickAddress { get; set; }

        [JsonPropertyName("pick_province")]
        public string PickProvince { get; set; }

        [JsonPropertyName("pick_district")]
        public string PickDistrict { get; set; }

        [JsonPropertyName("pick_ward")]
        public string PickWard { get; set; }

        [JsonPropertyName("pick_tel")]
        public string PickTel { get; set; }

        [JsonPropertyName("tel")]
        public string Tel { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("province")]
        public string Province { get; set; }

        [JsonPropertyName("district")]
        public string District { get; set; }

        [JsonPropertyName("ward")]
        public string Ward { get; set; }

        [JsonPropertyName("hamlet")]
        public string Hamlet { get; set; }

        [JsonPropertyName("is_freeship")]
    
        public int IsFreeship { get; set; }

        [JsonPropertyName("pick_date")]
        public DateTimeOffset PickDate { get; set; }

        [JsonPropertyName("pick_money")]
        public long PickMoney { get; set; }

        [JsonPropertyName("note")]
        public string Note { get; set; }

        [JsonPropertyName("value")]
        public long Value { get; set; }

        [JsonPropertyName("transport")]
        public string Transport { get; set; }

        [JsonPropertyName("pick_option")]
        public string PickOption { get; set; }

        [JsonPropertyName("gam_solutions")]
        public GamSolution[] GamSolutions { get; set; }
    }

    public partial class GamSolution
    {
        [JsonPropertyName("solution_id")]
        public long SolutionId { get; set; }
    }

    public partial class Product
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("weight")]
        public double Weight { get; set; }

        [JsonPropertyName("quantity")]
        public long Quantity { get; set; }

        [JsonPropertyName("product_code")]
        public long ProductCode { get; set; }
    }
}
