using Roblox_Sharp.Enums;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models.Internal.JsonConverters
{
    internal sealed class Avatar_Type_Converter : JsonConverter<AvatarType>
    {
        public override AvatarType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number) return (AvatarType)reader.GetByte();

            return EnumExtensions.ToEnum<AvatarType>(reader.GetString() ?? throw new JsonException("Error when converting " + nameof(AvatarType)));
        }

        public override void Write(Utf8JsonWriter writer, AvatarType value, JsonSerializerOptions options) => writer.WriteNumberValue((byte)value);
    }
}
