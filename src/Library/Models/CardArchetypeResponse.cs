using System.Text.Json.Serialization;

namespace YGOProDeckWrapper.Library.Models
{
    public class CardArchetypeResponse
    {
        [JsonPropertyName("archetype_name")]
        public string ArchetypeName { get; set; }
    }
}