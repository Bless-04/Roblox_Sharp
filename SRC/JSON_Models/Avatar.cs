using System.Collections.Generic;

using System.Text.Json.Serialization;

using Roblox_Sharp.Enums;

namespace Roblox_Sharp.JSON_Models
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
    [JsonSerializable(typeof(Avatar))]
    public partial class Avatar
    {
        public Scales scales { get; init; }
        public Avatar_Type playerAvatarType { get; init; }
        /// <summary>
        /// the brickcolor ids for each bodypart
        /// </summary>
        public BodyColors bodyColors { get; init; } //unique to v1

        public BodyColor3s bodyColor3s { get; init; } //unique to v2

        /// <summary>
        /// the assets worn on the avatar
        /// </summary>
        public IReadOnlyList<Asset>? assets { get; init; } 
        /// <summary>
        /// true if the default shirt is applied to this avatar
        /// </summary>
        public bool defaultShirtApplied { get; init; }

        /// <summary>
        /// true if the default pants are applied to this avatar
        /// </summary>
        public bool defaultPantsApplied { get; init; }

        /// <summary>
        /// the emotes on the avatar
        /// </summary>
        public IReadOnlyList<Emote>? emotes { get; init; }
    }
}
