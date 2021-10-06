using System.Text.Json.Serialization;

namespace YGOProDeckWrapper.Library.Models
{
    public class CardImageResponse
    {
        public int Id { get; set; }
        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }
        [JsonPropertyName("image_url_small")]
        public string ImageUrlSmall { get; set; }
    }
}