﻿using System.Text.Json.Serialization;

namespace Ghtk.Api.Models
{
    public class ApiResults
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
