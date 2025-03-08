using Roblox_Sharp.Enums;
using Roblox_Sharp.Framework;
using Roblox_Sharp.Models.Internal.JsonConverters;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models
{
    //example return 
    /*{
  "scales": {
    "height": 0,
    "width": 0,
    "head": 0,
    "depth": 0,
    "proportion": 0,
    "bodyType": 0
  },
  "playerAvatarType": 1,
  "bodyColors": {
    "headColorId": 0,
    "torsoColorId": 0,
    "rightArmColorId": 0,
    "leftArmColorId": 0,
    "rightLegColorId": 0,
    "leftLegColorId": 0
  },
  "assets": [
    {
      "id": 0,
      "name": "string",
      "assetType": {
        "id": 0,
        "name": "string"
      },
      "currentVersionId": 0,
      "meta": {
        "order": 0,
        "puffiness": 0,
        "position": {
          "X": 0,
          "Y": 0,
          "Z": 0
        },
        "rotation": {
          "X": 0,
          "Y": 0,
          "Z": 0
        },
        "scale": {
          "X": 0,
          "Y": 0,
          "Z": 0
        },
        "version": 0
      }
    }
  ],
  "defaultShirtApplied": true,
  "defaultPantsApplied": true,
  "emotes": [
    {
      "assetId": 0,
      "assetName": "string",
      "position": 0
    }
  ]
}*/

    /// <summary>
    /// used to serialize avatar based requests
    /// </summary>
    public partial class Avatar : ICloneable<Avatar>
    {
        /// <summary>
        /// <inheritdoc cref="Scales"/>
        /// </summary>
        public Scales scales { get; init; }

        /// <summary>
        /// <inheritdoc cref="AvatarType"/>
        /// </summary>
        [JsonConverter(typeof(Avatar_Type_Converter))]
        public AvatarType playerAvatarType { get; init; }

        /// <summary>
        /// the brickcolor ids for each bodypart
        /// <note>unique to <seealso cref="Endpoints.Avatars_v1"/> based requests </note>
        /// </summary>
        public BodyColors bodyColors { get; init; }

        /// <summary>
        /// the rgb hex colors for each bodypart
        /// <note>unique to <seealso cref="Endpoints.Avatars_v2"/> based requests </note>
        /// </summary>
        public BodyColor3s? bodyColor3s { get; init; } 

        /// <summary>
        /// the assets worn on the avatar
        /// </summary>
        [JsonPropertyName("assets")]
        public IReadOnlyList<Asset>? Assets { get; init; }

        /// <summary>
        /// <see langword="true"/> if the default shirt is applied to this avatar
        /// </summary>
        [JsonPropertyName("defaultShirtApplied")]
        public bool DefaultShirtApplied { get; init; }

        /// <summary>
        /// <see langword="true"/> if the default pants are applied to this avatar
        /// </summary>
        [JsonPropertyName("defaultPantsApplied")]
        public bool DefaultPantsApplied { get; init; }

        /// <summary>
        /// the emotes on the avatar
        /// </summary>
        [JsonPropertyName("emotes")]
        public IReadOnlyList<Emote>? Emotes { get; init; }

        ///<inheritdoc/>
        public Avatar Clone() => new()
        {
            scales = scales,
            playerAvatarType = playerAvatarType,
            bodyColors = bodyColors,
            bodyColor3s = bodyColor3s,
            Assets = Assets,
            DefaultShirtApplied = DefaultShirtApplied,
            DefaultPantsApplied = DefaultPantsApplied,
            Emotes = Emotes
        };
    }
}
