using Roblox_Sharp.Enums;
using Roblox_Sharp.Models;
using System;
using System.Drawing;
using System.Text.Json;


namespace xUnitTests.Deserialization
{
    [Trait(nameof(xUnitTests), nameof(Deserialization))]
    public class Avatar_Object
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

            Assert.True(avatar.defaultShirtApplied);
            Assert.True(avatar.defaultPantsApplied);
            Assert.Equal(AvatarType.R15, avatar.playerAvatarType);

            Avatar.Emote emotes = avatar.emotes![0];
            Assert.Equal<ulong>(0, emotes.assetId);
            Assert.Equal("string", emotes.assetName);
            Assert.Equal(0, emotes.position);

            Avatar.Asset assets = avatar.assets![0];
            Assert.Equal<ulong>(0, assets.assetId);
            Assert.Equal("string", assets.assetName);
            Assert.Equal<ulong>(0, assets.assetType.id);
            Assert.Equal("string", assets.assetType.name);
            Assert.Equal<ulong>(0, assets.currentVersionId);
            Assert.Equal(0, assets.meta.order);
            Assert.Equal(0, assets.meta.puffiness);
            Assert.Equal(0, assets.meta.position.X);
            Assert.Equal(0, assets.meta.position.Y);
            Assert.Equal(0, assets.meta.position.Z);
            Assert.Equal(0, assets.meta.rotation.X);
            Assert.Equal(0, assets.meta.rotation.Y);
            Assert.Equal(0, assets.meta.rotation.Z);
            Assert.Equal(0, assets.meta.scale.X);
            Assert.Equal(0, assets.meta.scale.Y);
            Assert.Equal(0, assets.meta.scale.Z);
            Assert.Equal<ulong>(0, assets.meta.version);

            Avatar.Scales scales = avatar.scales!;
            Assert.Equal(0, scales.height);
            Assert.Equal(0, scales.width);
            Assert.Equal(0, scales.head);
            Assert.Equal(0, scales.depth);
            Assert.Equal(0, scales.proportion);
            Assert.Equal(0, scales.bodyType);

            Avatar.BodyColors bodyColors = avatar.bodyColors!;
            Assert.Equal(0, bodyColors.headColorId);
            Assert.Equal(0, bodyColors.torsoColorId);
            Assert.Equal(0, bodyColors.rightArmColorId);
            Assert.Equal(0, bodyColors.leftArmColorId);
            Assert.Equal(0, bodyColors.rightLegColorId);
            Assert.Equal(0, bodyColors.leftLegColorId);
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


            Assert.True(avatar.defaultShirtApplied);
            Assert.True(avatar.defaultPantsApplied);
            Assert.Equal(AvatarType.R6, avatar.playerAvatarType);

            Avatar.Emote emotes = avatar.emotes![0];
            Assert.Equal<ulong>(0, emotes.assetId);
            Assert.Equal("string", emotes.assetName);
            Assert.Equal(0, emotes.position);

            Avatar.Asset assets = avatar.assets![0];
            Assert.Equal<ulong>(0, assets.assetId);
            Assert.Equal("string", assets.assetName);
            Assert.Equal<ulong>(0, assets.assetType.id);
            Assert.Equal("string", assets.assetType.name);
            Assert.Equal<ulong>(0, assets.currentVersionId);
            Assert.Equal(0, assets.meta.order);
            Assert.Equal(0, assets.meta.puffiness);
            Assert.Equal(0, assets.meta.position.X);
            Assert.Equal(0, assets.meta.position.Y);
            Assert.Equal(0, assets.meta.position.Z);
            Assert.Equal(0, assets.meta.rotation.X);
            Assert.Equal(0, assets.meta.rotation.Y);
            Assert.Equal(0, assets.meta.rotation.Z);
            Assert.Equal(0, assets.meta.scale.X);
            Assert.Equal(0, assets.meta.scale.Y);
            Assert.Equal(0, assets.meta.scale.Z);
            Assert.Equal<ulong>(0, assets.meta.version);

            Avatar.Scales scales = avatar.scales!;
            Assert.Equal(0, scales.height);
            Assert.Equal(0, scales.width);
            Assert.Equal(0, scales.head);
            Assert.Equal(0, scales.depth);
            Assert.Equal(0, scales.proportion);
            Assert.Equal(0, scales.bodyType);



            Color expected_color = ColorTranslator.FromHtml("#A3A2A5");
            Avatar.BodyColor3s bodyColor3s = JsonSerializer.Deserialize<Avatar>(json_response)!.bodyColor3s;


            Assert.Equal(expected_color, bodyColor3s.headColor3);
            Assert.Equal(expected_color, bodyColor3s.torsoColor3);
            Assert.Equal(expected_color, bodyColor3s.rightArmColor3);
            Assert.Equal(expected_color, bodyColor3s.leftArmColor3);
            Assert.Equal(expected_color, bodyColor3s.rightLegColor3);
            Assert.Equal(expected_color, bodyColor3s.leftLegColor3);
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
