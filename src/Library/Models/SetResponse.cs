using System;
using System.Text.Json.Serialization;

namespace YGOProDeckWrapper.Library.Models
{
    public class SetResponse
    {
        [JsonPropertyName("set_name")]
        public string SetName { get; set; }
        [JsonPropertyName("set_code")]
        public string SetCode { get; set; }
        [JsonPropertyName("num_of_cards")]
        public int CardsInSet { get; set; }
        [JsonPropertyName("tcg_date")]
        public DateTime TCGDate { get; set; }
    }
}