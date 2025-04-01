using Roblox_Sharp.Enums;
using Roblox_Sharp.Models.JsonConverters;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models.v1
{
    //example return 
    /*{
  "Scales": {
    "height": 0,
    "width": 0,
    "head": 0,
    "depth": 0,
    "proportion": 0,
    "bodyType": 0
  },
  "playerAvatarType": 1,
  "BodyColors": {
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

    /*
    /// <summary>
    /// used to serialize v
    /// </summary>
    public partial class Avatar
    {
        /// <summary>
        /// <inheritdoc cref="Scale"/>
        /// </summary>
        [JsonPropertyName("scales")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public required Scale Scales { get; init; }

        /// <summary>
        /// <inheritdoc cref="AvatarType"/>
        /// </summary>
        [JsonConverter(typeof(Avatar_Type_Converter))]
        [JsonPropertyName("playerAvatarType")]
        public required AvatarType PlayerAvatarType { get; init; }

        /// <summary>
        /// the brickcolor ids for each bodypart
        /// <note>unique to <seealso cref="Endpoints.Avatars_v1"/> based requests </note>
        /// </summary>
        [JsonPropertyName("bodyColors")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BodyColor BodyColors { get; init; }

        /// <summary>
        /// the assets worn on the avatar
        /// </summary>
        [JsonPropertyName("assets")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IReadOnlyList<Asset> Assets { get; init; }

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
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IReadOnlyList<Emote> Emotes { get; init; }

    }
    */
}
    
    