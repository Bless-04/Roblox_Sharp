using Roblox_Sharp.Models.v1;
using System.Text.Json;

namespace Tests.Model.Json
{
    [Trait(nameof(Roblox_Sharp.Models), nameof(Json))]
    public class Avatar_Models
    {
        #region v1
        [Fact]
        public void Avatar1()
        {
            const string json = @"{
  ""scales"": {
    ""height"": 1.05,
    ""width"": 1.05,
    ""head"": 1.05,
    ""depth"": 1.05,
    ""proportion"": 1.06,
    ""bodyType"": 1.4
  },
  ""playerAvatarType"": ""R15"",
  ""bodyColors"": {
    ""headColorId"": 1003,
    ""torsoColorId"": 1003,
    ""rightArmColorId"": 1003,
    ""leftArmColorId"": 1003,
    ""rightLegColorId"": 1003,
    ""leftLegColorId"": 1003
  },
  ""assets"": [
    {
      ""id"": 111902832,
      ""name"": ""Red Animal Hoodie"",
      ""assetType"": {
        ""id"": 8,
        ""name"": ""Hat""
      },
      ""currentVersionId"": 883364938
    },
    {
      ""id"": 212296936,
      ""name"": ""Red Hyperlaser Gun"",
      ""assetType"": {
        ""id"": 19,
        ""name"": ""Gear""
      },
      ""currentVersionId"": 504763793
    },
    {
      ""id"": 262669756,
      ""name"": ""Hiccup’s (Improved) Helmet"",
      ""assetType"": {
        ""id"": 8,
        ""name"": ""Hat""
      },
      ""currentVersionId"": 883367816
    },
    {
      ""id"": 619521311,
      ""name"": ""Robot Climb"",
      ""assetType"": {
        ""id"": 48,
        ""name"": ""ClimbAnimation""
      },
      ""currentVersionId"": 13806699885
    },
    {
      ""id"": 619522642,
      ""name"": ""Robot Swim"",
      ""assetType"": {
        ""id"": 54,
        ""name"": ""SwimAnimation""
      },
      ""currentVersionId"": 13806699912
    },
    {
      ""id"": 619542203,
      ""name"": ""Levitation Idle"",
      ""assetType"": {
        ""id"": 51,
        ""name"": ""IdleAnimation""
      },
      ""currentVersionId"": 13943504087
    },
    {
      ""id"": 619544080,
      ""name"": ""Levitation Walk"",
      ""assetType"": {
        ""id"": 55,
        ""name"": ""WalkAnimation""
      },
      ""currentVersionId"": 13806699786
    },
    {
      ""id"": 658830056,
      ""name"": ""Ninja Run"",
      ""assetType"": {
        ""id"": 53,
        ""name"": ""RunAnimation""
      },
      ""currentVersionId"": 13806699839
    },
    {
      ""id"": 658831500,
      ""name"": ""Ninja Fall"",
      ""assetType"": {
        ""id"": 50,
        ""name"": ""FallAnimation""
      },
      ""currentVersionId"": 13806699845
    },
    {
      ""id"": 658832070,
      ""name"": ""Ninja Jump"",
      ""assetType"": {
        ""id"": 52,
        ""name"": ""JumpAnimation""
      },
      ""currentVersionId"": 21158792270
    },
    {
      ""id"": 5754364453,
      ""name"": ""Accelerator [+]"",
      ""assetType"": {
        ""id"": 11,
        ""name"": ""Shirt""
      },
      ""currentVersionId"": 6928419750
    },
    {
      ""id"": 5984763414,
      ""name"": ""[TDS] Accelerator [-]"",
      ""assetType"": {
        ""id"": 12,
        ""name"": ""Pants""
      },
      ""currentVersionId"": 7225470301
    },
    {
      ""id"": 10919788323,
      ""name"": ""(1.0) Purple Character Outline Aura"",
      ""assetType"": {
        ""id"": 67,
        ""name"": ""JacketAccessory""
      },
      ""currentVersionId"": 13726830530,
      ""meta"": {
        ""order"": 0,
        ""puffiness"": 1,
        ""version"": 1
      }
    },
    {
      ""id"": 11308848181,
      ""name"": ""Err... - Mood"",
      ""assetType"": {
        ""id"": 78,
        ""name"": ""MoodAnimation""
      },
      ""currentVersionId"": 14302545651
    },
    {
      ""id"": 11308877966,
      ""name"": ""Err... - Eyebrow"",
      ""assetType"": {
        ""id"": 76,
        ""name"": ""EyebrowAccessory""
      },
      ""currentVersionId"": 15094164595,
      ""meta"": {
        ""order"": 0,
        ""puffiness"": 1,
        ""version"": 1
      }
    },
    {
      ""id"": 11308884165,
      ""name"": ""Err... - Head"",
      ""assetType"": {
        ""id"": 79,
        ""name"": ""DynamicHead""
      },
      ""currentVersionId"": 16660491391
    },
    {
      ""id"": 12575827264,
      ""name"": ""Menacing Head"",
      ""assetType"": {
        ""id"": 42,
        ""name"": ""FaceAccessory""
      },
      ""currentVersionId"": 16153984334
    },
    {
      ""id"": 13540224935,
      ""name"": ""Angel's wings"",
      ""assetType"": {
        ""id"": 8,
        ""name"": ""Hat""
      },
      ""currentVersionId"": 17524595677
    }
  ],
  ""defaultShirtApplied"": true,
  ""defaultPantsApplied"": true,
  ""emotes"": [
    {
      ""assetId"": 10214406616,
      ""assetName"": ""Frosty Flair - Tommy Hilfiger"",
      ""position"": 1
    },
    {
      ""assetId"": 3696757129,
      ""assetName"": ""Hype Dance"",
      ""position"": 2
    },
    {
      ""assetId"": 5915779043,
      ""assetName"": ""Applaud"",
      ""position"": 3
    },
    {
      ""assetId"": 3576968026,
      ""assetName"": ""Shrug"",
      ""position"": 4
    },
    {
      ""assetId"": 3576686446,
      ""assetName"": ""Hello"",
      ""position"": 5
    },
    {
      ""assetId"": 3360686498,
      ""assetName"": ""Stadium"",
      ""position"": 6
    },
    {
      ""assetId"": 3360692915,
      ""assetName"": ""Tilt"",
      ""position"": 7
    },
    {
      ""assetId"": 5917570207,
      ""assetName"": ""Floss Dance"",
      ""position"": 8
    }
  ]
}";

            Avatar? avatar = JsonSerializer.Deserialize<Avatar>(json);
            Assert.NotNull(avatar);

            Avatar.Type type = avatar.PlayerAvatarType;
            Assert.Equal(Avatar.Type.R15, type);


            Avatar.Scale scale = avatar.Scales;
            Assert.Equal(1.05, scale.Height);
            Assert.Equal(1.05, scale.Width);
            Assert.Equal(1.05, scale.Head);
            Assert.Equal(1.05, scale.Depth);
            Assert.Equal(1.06, scale.Proportion);
            Assert.Equal(1.4, scale.BodyType);

            Avatar.BodyColor bodycolor = avatar.BodyColors;
            Assert.Equal(1003, bodycolor.HeadColorId);
            Assert.Equal(1003, bodycolor.TorsoColorId);
            Assert.Equal(1003, bodycolor.RightArmColorId);
            Assert.Equal(1003, bodycolor.LeftArmColorId);
            Assert.Equal(1003, bodycolor.RightLegColorId);
            Assert.Equal(1003, bodycolor.LeftLegColorId);

            Assert.NotEmpty(avatar.Assets);
            Avatar.Asset asset = avatar.Assets[0];
            Assert.Equal<ulong>(111902832, asset.AssetId);
            Assert.Equal<ulong>(883364938, asset.CurrentVersionId);
            Assert.True(asset.AssetName.Length > 5, nameof(asset.AssetName).isFailing());
            Assert.Equal(8, (byte)asset.AssetType.Id);
            Assert.True(asset.AssetName.Length > 0, nameof(asset.AssetName).isFailing());
            Assert.Equal("Hat", asset.AssetType.Name);
            Assert.True(asset.RoundTrip());

            Assert.NotEmpty(avatar.Emotes);
            Avatar.Emote emote = avatar.Emotes[0];
            Assert.Equal<ulong>(10214406616, emote.AssetId);
            Assert.True(emote.AssetName.Length > 10, nameof(emote.AssetName).isFailing());
            Assert.Equal(1, emote.Position);
            Assert.True(emote.RoundTrip());
        }
        #endregion

        #region v2
        [Fact]
        public void Avatar2()
        {

        }

        #endregion
    }
}
