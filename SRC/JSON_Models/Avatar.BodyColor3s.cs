using System.Drawing;
using System.Text.Json.Serialization;
using Roblox_Sharp.JSON_Models.Internal.JsonConverter;
namespace Roblox_Sharp.JSON_Models;

public partial class Avatar
{

    /// <summary>
    /// the body color of the avatar using RGB hex
    /// </summary>
    
    public readonly struct BodyColor3s
    {
        /// <summary>
        /// The RGB hex color for head color, e.g. #FFFFFF
        /// </summary>
        [JsonConverter(typeof(Color_JsonConverter))]
        public Color headColor3 { get; init ; }

        /// <summary>
        /// The RGB hex color for torso color
        /// </summary>
        [JsonConverter(typeof(Color_JsonConverter))]
        public Color torsoColor3 { get; init; }

        /// <summary>
        /// The RGB hex color for right arm color, e.g. #FFFFFF
        /// </summary>
        [JsonConverter(typeof(Color_JsonConverter))]
        public Color rightArmColor3 { get; init; }

        /// <summary>
        /// The RGB hex color for left arm color, e.g. #FFFFFF
        /// </summary>
        [JsonConverter(typeof(Color_JsonConverter))]
        public Color leftArmColor3 { get; init; }

        /// <summary>
        /// The RGB hex color for right leg color, e.g. #FFFFFF
        /// </summary>
        [JsonConverter(typeof(Color_JsonConverter))]
        public Color rightLegColor3 { get; init ; }

        /// <summary>
        /// The RGB hex color for left leg color, e.g. #FFFFFF
        /// </summary>
        [JsonConverter(typeof(Color_JsonConverter))]
        public Color leftLegColor3 { get; init ; }
    }    
}
