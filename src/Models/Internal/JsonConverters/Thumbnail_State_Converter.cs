using Roblox_Sharp.Enums;
using System;
using System.Text.Json.Serialization;
using System.Text.Json;
using Roblox_Sharp.Enums.Thumbnail;

namespace Roblox_Sharp.Models.Internal.JsonConverters
{

    internal sealed class Thumbnail_State_Converter : JsonConverter<State>
    {
        public override State Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number) return (State)reader.GetByte();

            return EnumExtensions.ToEnum<State>(reader.GetString() ?? throw new JsonException("Error when converting " + nameof(State)));
        }

        public override void Write(Utf8JsonWriter writer, State value, JsonSerializerOptions options) => writer.WriteNumberValue((byte)value);
    }
}
