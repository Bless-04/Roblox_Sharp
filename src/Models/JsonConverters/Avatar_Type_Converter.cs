using Roblox_Sharp.Enums;
using Roblox_Sharp.Models.v1;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models.JsonConverters
{

    public class Avatar_Type_Converter : JsonConverter<Avatar.Type>
    {
        /// <inheritdoc/>
        public override Avatar.Type Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number) return (Avatar.Type)reader.GetByte();

            return EnumExtensions.ToEnum<Avatar.Type>(reader.GetString() ?? throw new JsonException("Error when converting " + nameof(Avatar.Type)));
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, Avatar.Type value, JsonSerializerOptions options) => writer.WriteNumberValue((byte)value);
    }
}
