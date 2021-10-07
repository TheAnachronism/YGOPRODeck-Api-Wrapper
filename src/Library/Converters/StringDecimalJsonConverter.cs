using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace YGOProDeckWrapper.Library.Converters
{
    public class StringDecimalJsonConverter : JsonConverter<decimal>
    {
        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (decimal.TryParse(reader.GetString(), out var result))
                return result;

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("G"));
        }
    }
}