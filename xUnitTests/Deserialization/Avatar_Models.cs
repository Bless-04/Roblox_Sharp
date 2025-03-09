using Roblox_Sharp.Enums;
using Roblox_Sharp.Models;
using System;
using System.Drawing;
using System.Text.Json;

namespace xUnitTests.Deserialization
{
    [Trait(nameof(Roblox_Sharp.Models), nameof(Deserialization))]
    public class Avatar_Models
    {
        [Fact]
        public void Get_Avatar_v1()
        {
            const string json_response = @"
            {
              ""scales"": {
                ""height"": 0,
                ""width"": 0,
                ""head"": 0,
                ""depth"": 0,
                ""proportion"": 0,
                ""bodyType"": 0
              },
              ""playerAvatarType"": 3,
              ""bodyColors"": {
                ""headColorId"": 0,
                ""torsoColorId"": 0,
                ""rightArmColorId"": 0,
                ""leftArmColorId"": 0,
                ""rightLegColorId"": 0,
                ""leftLegColorId"": 0
              },
              ""assets"": [
                {
                  ""id"": 0,
                  ""name"": ""string"",
                  ""assetType"": {
                    ""id"": 0,
                    ""name"": ""string""
                  },
                  ""currentVersionId"": 0,
                  ""meta"": {
                    ""order"": 0,
                    ""puffiness"": 0,
                    ""position"": {
                      ""X"": 0,
                      ""Y"": 0,
                      ""Z"": 0
                    },
                    ""rotation"": {
                      ""X"": 0,
                      ""Y"": 0,
                      ""Z"": 0
                    },
                    ""scale"": {
                      ""X"": 0,
                      ""Y"": 0,
                      ""Z"": 0
                    },
                    ""version"": 0
                  }
                }
              ],
              ""defaultShirtApplied"": true,
              ""defaultPantsApplied"": true,
              ""emotes"": [
                {
                  ""assetId"": 0,
                  ""assetName"": ""string"",
                  ""position"": 0
                }
              ]
            }";

            Avatar? avatar = JsonSerializer.Deserialize<Avatar>(json_response);

            Assert.NotNull(avatar);

            Assert.True(avatar.DefaultShirtApplied);
            Assert.True(avatar.DefaultPantsApplied);
            Assert.Equal(AvatarType.R15, avatar.PlayerAvatarType);

            Avatar.Emote emotes = avatar.Emotes![0];
            Assert.Equal<ulong>(0, emotes.AssetId);
            Assert.Equal("string", emotes.AssetName);
            Assert.Equal(0, emotes.Position);

            Avatar.Asset assets = avatar.Assets![0];
            
            Assert.Equal<ulong>(0, assets.AssetId);
            Assert.Equal("string", assets.AssetName);
            Assert.Equal(0, (byte)assets.AssetType!.Id);
            Assert.Equal("string", assets.AssetType.Name);
            Assert.Equal<ulong>(0, assets.CurrentVersionId);

            Assert.NotNull(assets.Meta);
            Assert.Equal(0, assets.Meta.Order);
            Assert.Equal(0, assets.Meta.Puffiness);
            Assert.Equal(0, assets.Meta.Position.X);
            Assert.Equal(0, assets.Meta.Position.Y);
            Assert.Equal(0, assets.Meta.Position.Z);
            Assert.Equal(0, assets.Meta.Rotation.X);
            Assert.Equal(0, assets.Meta.Rotation.Y);
            Assert.Equal(0, assets.Meta.Rotation.Z);
            Assert.Equal(0, assets.Meta.Scale.X);
            Assert.Equal(0, assets.Meta.Scale.Y);
            Assert.Equal(0, assets.Meta.Scale.Z);
            Assert.Equal<ulong>(0, assets.Meta.Version);

            Avatar.Scale? scales = avatar.Scales;
            Assert.NotNull(scales);

            Assert.Equal(0, scales.Height);
            Assert.Equal(0, scales.Width);
            Assert.Equal(0, scales.Head);
            Assert.Equal(0, scales.Depth);
            Assert.Equal(0, scales.Proportion);
            Assert.Equal(0, scales.BodyType);

            Avatar.BodyColor bodyColors = avatar.BodyColors;

            Assert.Equal(0, bodyColors.HeadColorId);
            Assert.Equal(0, bodyColors.TorsoColorId);
            Assert.Equal(0, bodyColors.RightArmColorId);
            Assert.Equal(0, bodyColors.LeftArmColorId);
            Assert.Equal(0, bodyColors.RightLegColorId);
            Assert.Equal(0, bodyColors.LeftLegColorId);
        }

        [Fact]
        public void Get_Avatar_v2()
        {
            const string json_response = @"
            {
              ""scales"": {
                ""height"": 0,
                ""width"": 0,
                ""head"": 0,
                ""depth"": 0,
                ""proportion"": 0,
                ""bodyType"": 0
              },
              ""playerAvatarType"": ""R6"",
              ""bodyColor3s"": {
                ""headColor3"": ""A3A2A5"",
                ""torsoColor3"": ""#A3A2A5"",
                ""rightArmColor3"": ""A3A2A5"",
                ""leftArmColor3"": ""A3A2A5"",
                ""rightLegColor3"": ""A3A2A5"",
                ""leftLegColor3"": ""A3A2A5""
              },
              ""assets"": [
                {
                  ""id"": 0,
                  ""name"": ""string"",
                  ""assetType"": {
                    ""id"": 0,
                    ""name"": ""string""
                  },
                  ""currentVersionId"": 0,
                  ""meta"": {
                    ""order"": 0,
                    ""puffiness"": 0,
                    ""position"": {
                      ""X"": 0,
                      ""Y"": 0,
                      ""Z"": 0
                    },
                    ""rotation"": {
                      ""X"": 0,
                      ""Y"": 0,
                      ""Z"": 0
                    },
                    ""scale"": {
                      ""X"": 0,
                      ""Y"": 0,
                      ""Z"": 0
                    },
                    ""version"": 0
                  }
                }
              ],
              ""defaultShirtApplied"": true,
              ""defaultPantsApplied"": true,
              ""emotes"": [
                {
                  ""assetId"": 0,
                  ""assetName"": ""string"",
                  ""position"": 0
                }
              ]
            }";

            Avatar? avatar = JsonSerializer.Deserialize<Avatar>(json_response);

            Assert.NotNull(avatar);


            Assert.True(avatar.DefaultShirtApplied);
            Assert.True(avatar.DefaultPantsApplied);
            Assert.Equal(AvatarType.R6, avatar.PlayerAvatarType);

            Avatar.Emote emotes = avatar.Emotes![0];
            Assert.Equal<ulong>(0, emotes.AssetId);
            Assert.Equal("string", emotes.AssetName);
            Assert.Equal(0, emotes.Position);

            Avatar.Asset assets = avatar.Assets![0];
            Assert.Equal<ulong>(0, assets.AssetId);
            Assert.Equal("string", assets.AssetName);

            Assert.NotNull(assets.AssetType);
            Assert.Equal<AssetType>(0, assets.AssetType.Id);
            Assert.Equal("string", assets.AssetType.Name);
            Assert.Equal<ulong>(0, assets.CurrentVersionId);

            Assert.NotNull(assets.Meta);
            Assert.Equal(0, assets.Meta.Order);
            Assert.Equal(0, assets.Meta.Puffiness);
            Assert.Equal(0, assets.Meta.Position.X);
            Assert.Equal(0, assets.Meta.Position.Y);
            Assert.Equal(0, assets.Meta.Position.Z);
            Assert.Equal(0, assets.Meta.Rotation.X);
            Assert.Equal(0, assets.Meta.Rotation.Y);
            Assert.Equal(0, assets.Meta.Rotation.Z);
            Assert.Equal(0, assets.Meta.Scale.X);
            Assert.Equal(0, assets.Meta.Scale.Y);
            Assert.Equal(0, assets.Meta.Scale.Z);
            Assert.Equal<ulong>(0, assets.Meta.Version);

            Avatar.Scale scales = avatar.Scales!;
            Assert.Equal(0, scales.Height);
            Assert.Equal(0, scales.Width);
            Assert.Equal(0, scales.Head);
            Assert.Equal(0, scales.Depth);
            Assert.Equal(0, scales.Proportion);
            Assert.Equal(0, scales.BodyType);


            Color expected_color = ColorTranslator.FromHtml("#A3A2A5");
            Avatar.BodyColor3? bodyColor3s = JsonSerializer.Deserialize<Avatar>(json_response)!.BodyColor3s;

            Assert.NotNull(bodyColor3s);
            Assert.Equal(expected_color, bodyColor3s.HeadColor3);
            Assert.Equal(expected_color, bodyColor3s.TorsoColor3);
            Assert.Equal(expected_color, bodyColor3s.RightArmColor3);
            Assert.Equal(expected_color, bodyColor3s.LeftArmColor3);
            Assert.Equal(expected_color, bodyColor3s.RightLegColor3);
            Assert.Equal(expected_color, bodyColor3s.LeftLegColor3);
        }

        [Fact]
        public void Get_Avatar_Type()
        {
            const string R6 = "1";

            const string r6 = "R6";

            const string R15 = "3";
            const string r15 = "r15";

            const string bad1 = "Rddoesntexist";

            Assert.Equal(AvatarType.R6, EnumExtensions.ToEnum<AvatarType>(R6));
            Assert.Equal(AvatarType.R6, EnumExtensions.ToEnum<AvatarType>(r6));

            Assert.Equal(AvatarType.R15, EnumExtensions.ToEnum<AvatarType>(R15));
            Assert.Equal(AvatarType.R15, EnumExtensions.ToEnum<AvatarType>(r15));

            Assert.Throws<ArgumentException>(() => EnumExtensions.ToEnum<AvatarType>(bad1));

        }
    }
}
