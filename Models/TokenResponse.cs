using System.Collections.Generic;
using Newtonsoft.Json;

namespace reCAPTCHAv3.netCore.Models
{
    public class TokenResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("score")]
        public decimal Score { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}