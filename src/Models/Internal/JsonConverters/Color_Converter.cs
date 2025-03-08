using System;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models.Internal.JsonConverters
{
    /// <summary>
    /// used to convert the color to and from RGB hex
    /// </summary>
    internal sealed class Color_Converter : JsonConverter<Color>
    {
        public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
           ColorTranslator.FromHtml(
              reader.GetString()![0] != '#' //if for some reason it doesnt start with a #
                   ? $"#{reader.GetString()}"
                   : reader.GetString() ?? throw new JsonException("Error when converting " + nameof(Color)) 
           );

        public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options) =>
            writer.WriteStringValue(
                ColorTranslator.ToHtml(value)
            );
    }
}
