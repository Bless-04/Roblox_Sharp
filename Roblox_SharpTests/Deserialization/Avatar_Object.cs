using System;
using System.Drawing;
using System.Text.Json;
using Roblox_Sharp.Enums;
using Roblox_Sharp.JSON_Models;


namespace Roblox_SharpTests.Deserialization
{
    [TestCategory("Deserialization Tests (Avatar)")]
    [TestClass]
    public class Avatar_Object
    {
        [TestMethod]
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

            Avatar avatar = JsonSerializer.Deserialize<Avatar>(json_response)
                ?? throw new AssertFailedException("Avatar should not be null here");

            Assert.AreEqual(true, avatar.defaultShirtApplied);
            Assert.AreEqual(true, avatar.defaultPantsApplied);
            Assert.AreEqual(Avatar_Type.R15, avatar.playerAvatarType);

            Avatar.Emote emotes = avatar.emotes![0];
                Assert.AreEqual<ulong>(0, emotes.assetId);
                Assert.AreEqual("string", emotes.assetName);
                Assert.AreEqual(0, emotes.position);

            Avatar.Asset assets = avatar.assets![0];
                Assert.AreEqual<ulong>(0, assets.assetId);
                Assert.AreEqual("string", assets.assetName);
                Assert.AreEqual<ulong>(0, assets.assetType.id);
                Assert.AreEqual("string", assets.assetType.name);
                Assert.AreEqual<ulong>(0, assets.currentVersionId);
                Assert.AreEqual(0, assets.meta.order);
                Assert.AreEqual(0, assets.meta.puffiness);
                Assert.AreEqual(0, assets.meta.position.X);
                Assert.AreEqual(0, assets.meta.position.Y);
                Assert.AreEqual(0, assets.meta.position.Z);
                Assert.AreEqual(0, assets.meta.rotation.X);
                Assert.AreEqual(0, assets.meta.rotation.Y);
                Assert.AreEqual(0, assets.meta.rotation.Z);
                Assert.AreEqual(0, assets.meta.scale.X);
                Assert.AreEqual(0, assets.meta.scale.Y);
                Assert.AreEqual(0, assets.meta.scale.Z);
                Assert.AreEqual<ulong>(0, assets.meta.version);

            Avatar.Scales scales = avatar.scales!;
                Assert.AreEqual(0, scales.height);
                Assert.AreEqual(0, scales.width);
                Assert.AreEqual(0, scales.head);
                Assert.AreEqual(0, scales.depth);
                Assert.AreEqual(0, scales.proportion);
                Assert.AreEqual(0, scales.bodyType);

            Avatar.BodyColors bodyColors = avatar.bodyColors!;
                Assert.AreEqual(0, bodyColors.headColorId);
                Assert.AreEqual(0, bodyColors.torsoColorId);
                Assert.AreEqual(0, bodyColors.rightArmColorId);
                Assert.AreEqual(0, bodyColors.leftArmColorId);
                Assert.AreEqual(0, bodyColors.rightLegColorId);
                Assert.AreEqual(0, bodyColors.leftLegColorId);
        }

        [TestMethod]
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

            Avatar avatar = JsonSerializer.Deserialize<Avatar>(json_response)
                ?? throw new AssertFailedException("Avatar should not be null here");

            Assert.AreEqual(true, avatar.defaultShirtApplied);
            Assert.AreEqual(true, avatar.defaultPantsApplied);
            Assert.AreEqual(Avatar_Type.R6, avatar.playerAvatarType);

            Avatar.Emote emotes = avatar.emotes![0];
                Assert.AreEqual<ulong>(0, emotes.assetId);
                Assert.AreEqual("string", emotes.assetName);
                Assert.AreEqual(0, emotes.position);

            Avatar.Asset assets = avatar.assets![0];
                Assert.AreEqual<ulong>(0, assets.assetId);
                Assert.AreEqual("string", assets.assetName);
                Assert.AreEqual<ulong>(0, assets.assetType.id);
                Assert.AreEqual("string", assets.assetType.name);
                Assert.AreEqual<ulong>(0, assets.currentVersionId);
                Assert.AreEqual(0, assets.meta.order);
                Assert.AreEqual(0, assets.meta.puffiness);
                Assert.AreEqual(0, assets.meta.position.X);
                Assert.AreEqual(0, assets.meta.position.Y);
                Assert.AreEqual(0, assets.meta.position.Z);
                Assert.AreEqual(0, assets.meta.rotation.X);
                Assert.AreEqual(0, assets.meta.rotation.Y);
                Assert.AreEqual(0, assets.meta.rotation.Z);
                Assert.AreEqual(0, assets.meta.scale.X);
                Assert.AreEqual(0, assets.meta.scale.Y);
                Assert.AreEqual(0, assets.meta.scale.Z);
                Assert.AreEqual<ulong>(0, assets.meta.version);
            
            Avatar.Scales scales = avatar.scales!;
                Assert.AreEqual(0, scales.height);
                Assert.AreEqual(0, scales.width);
                Assert.AreEqual(0, scales.head);
                Assert.AreEqual(0, scales.depth);
                Assert.AreEqual(0, scales.proportion);
                Assert.AreEqual(0, scales.bodyType);

            

            Color expected_color = ColorTranslator.FromHtml("#A3A2A5");
            Avatar.BodyColor3s bodyColor3s = JsonSerializer.Deserialize<Avatar>(json_response)!.bodyColor3s;
            
           
            Assert.AreEqual(expected_color, bodyColor3s.headColor3);
            Assert.AreEqual(expected_color, bodyColor3s.torsoColor3);
            Assert.AreEqual(expected_color, bodyColor3s.rightArmColor3);
            Assert.AreEqual(expected_color, bodyColor3s.leftArmColor3);
            Assert.AreEqual(expected_color, bodyColor3s.rightLegColor3);
            Assert.AreEqual(expected_color, bodyColor3s.leftLegColor3);
        }

        [TestMethod]
        public void Get_Avatar_Type()
        {
            const string R6 = "1";

            const string r6 = "R6";

            const string R15 = "3";
            const string r15 = "r15";

            const string bad1 = "Rddoesntexist";

            Assert.AreEqual(Avatar_Type.R6, EnumExtensions.ToAvatar_Type(R6));
            Assert.AreEqual(Avatar_Type.R6, EnumExtensions.ToAvatar_Type(r6));

            Assert.AreEqual(Avatar_Type.R15, EnumExtensions.ToAvatar_Type(R15));
            Assert.AreEqual(Avatar_Type.R15, EnumExtensions.ToAvatar_Type(r15));

            Assert.ThrowsException<NotImplementedException>(() => EnumExtensions.ToAvatar_Type(bad1));
            
           
            

        }
    }
}
