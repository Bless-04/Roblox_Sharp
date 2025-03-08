using Roblox_Sharp.Models.Internal.JsonConverters;
using System.Drawing;
using System.Text.Json.Serialization;
namespace Roblox_Sharp.Models;

public partial class Avatar
{

    /// <summary>
    /// the body color of the avatar using RGB hex
    /// </summary>

    public class BodyColor3s
    {
        /// <summary>
        /// The RGB hex color for head color, e.g. #FFFFFF
        /// </summary>
        [JsonConverter(typeof(Color_Converter))]
        [JsonPropertyName("headColor3")]
        public Color HeadColor3 { get; init; }

        /// <summary>
        /// The RGB hex color for torso color
        /// </summary>
        [JsonConverter(typeof(Color_Converter))]
        [JsonPropertyName("torsoColor3")]
        public Color TorsoColor3 { get; init; }

        /// <summary>
        /// The RGB hex color for right arm color, e.g. #FFFFFF
        /// </summary>
        [JsonConverter(typeof(Color_Converter))]
        [JsonPropertyName("rightArmColor3")]
        public Color RightArmColor3 { get; init; }

        /// <summary>
        /// The RGB hex color for left arm color, e.g. #FFFFFF
        /// </summary>
        [JsonConverter(typeof(Color_Converter))]
        [JsonPropertyName("leftArmColor3")]
        public Color LeftArmColor3 { get; init; }

        /// <summary>
        /// The RGB hex color for right leg color, e.g. #FFFFFF
        /// </summary>
        [JsonConverter(typeof(Color_Converter))]
        [JsonPropertyName("rightLegColor3")]
        public Color RightLegColor3 { get; init; }

        /// <summary>
        /// The RGB hex color for left leg color, e.g. #FFFFFF
        /// </summary>
        [JsonConverter(typeof(Color_Converter))]
        [JsonPropertyName("leftLegColor3")]
        public Color LeftLegColor3 { get; init; }
    }
}
