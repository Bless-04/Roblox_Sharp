using Roblox_Sharp.Enums;
using Roblox_Sharp.Enums.Thumbnail;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models.JsonConverters
{
    public class Thumbnail_State_Converter : JsonConverter<State>
    {
        /// <inheritdoc/>
        public override State Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number) return (State)reader.GetByte();

            return EnumExtensions.ToEnum<State>(reader.GetString() ?? throw new JsonException("Error when converting " + nameof(State)));
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, State value, JsonSerializerOptions options) => writer.WriteNumberValue((byte)value);
    }
}
