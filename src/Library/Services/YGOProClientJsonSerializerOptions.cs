using System.Text.Json;
using System.Text.Json.Serialization;
using YGOProDeckWrapper.Library.Converters;

namespace YGOProDeckWrapper.Library.Services
{
    public class YGOProClientJsonSerializerOptions
    {
        public JsonSerializerOptions JsonSerializerOptions { get; set; }
        public static JsonSerializerOptions DefaultSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            Converters =
            {
                new JsonStringEnumMemberConverter(),
                new StringDecimalJsonConverter()
            }
        };
    }
}