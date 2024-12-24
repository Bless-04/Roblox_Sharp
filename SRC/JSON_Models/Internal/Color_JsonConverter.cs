using System.Drawing;
using System.Text.Json.Serialization;
using System.Text.Json;

using System;

namespace Roblox_Sharp.JSON_Models.Internal
{
    /// <summary>
    /// used to convert the color to and from RGB hex
    /// </summary>
    internal sealed class Color_JsonConverter : JsonConverter<Color>
    {
        public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
           ColorTranslator.FromHtml(
               reader.GetString()!
           );

        public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options) =>
            writer.WriteStringValue(
                ColorTranslator.ToHtml(value)
            );
    }
}