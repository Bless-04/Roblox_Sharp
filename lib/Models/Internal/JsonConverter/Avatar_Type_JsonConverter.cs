
using Roblox_Sharp.Enums;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models.Internal.JsonConverter
{
    internal class Avatar_Type_JsonConverter : JsonConverter<Avatar_Type>
    {
        public override Avatar_Type Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number) return (Avatar_Type)reader.GetSByte();

            return EnumExtensions.ToEnum<Avatar_Type>(reader.GetString() ?? throw new JsonException("Error when converting Avatar_Type"));
        }


        public override void Write(Utf8JsonWriter writer, Avatar_Type value, JsonSerializerOptions options) =>
            writer.WriteNumberValue((byte)value);
    }
}
