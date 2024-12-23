using System.Text.Json;

using Roblox_Sharp.JSON_Models;

namespace Roblox_SharpTests.Deserialization
{
    /// <summary>
    /// Tests Serialization for all Group endpoints
    /// </summary>
    [TestCategory("Deserialization Tests")]
    [TestClass]
    public class Group_Object
    {
        [TestMethod]
        public void Get_Group()
        {
            const string json_response = @"
            {
                ""id"": 0,
                ""name"": ""string"",
                ""description"": ""string"",
                ""owner"": {
                ""buildersClubMembershipType"": 0,
                ""hasVerifiedBadge"": true,
                ""userId"": 0,
                ""username"": ""string"",
                ""displayName"": ""string""
                },
                ""shout"": {
                ""body"": ""string"",
                ""poster"": {
                    ""buildersClubMembershipType"": 0,
                    ""hasVerifiedBadge"": true,
                    ""userId"": 0,
                    ""username"": ""string"",
                    ""displayName"": ""string""
                },
                ""created"": ""2024-12-23T06:22:04.576Z"",
                ""updated"": ""2024-12-23T06:22:04.576Z""
                },
                ""memberCount"": 0,
                ""isBuildersClubOnly"": true,
                ""publicEntryAllowed"": true,
                ""isLocked"": true,
                ""hasVerifiedBadge"": true
            } ";
            
            Group group = JsonSerializer.Deserialize<Group>(json_response) 
                ?? throw new AssertFailedException("Group object should not be null here");

            Assert.AreEqual<ulong>(0, group.groupId);
            Assert.AreEqual("string", group.name);

            Assert.AreEqual("string", group.description);
            
            Assert.AreEqual(true, group.owner.hasVerifiedBadge);
            Assert.AreEqual<ulong>(0, group.owner.userId);
            Assert.AreEqual("string", group.owner.username);
            Assert.AreEqual("string", group.owner.displayName);

            Assert.AreEqual("string", group.shout.body);
            Assert.AreEqual(true, group.shout.poster.hasVerifiedBadge);
            Assert.AreEqual<ulong>(0, group.shout.poster.userId);
            Assert.AreEqual("string", group.shout.poster.username);
            Assert.AreEqual("string", group.shout.poster.displayName);
            
            Assert.AreEqual(2024, group.shout.created.Year);
            Assert.AreEqual(2024, group.shout.updated.Year);
            
            Assert.AreEqual<ulong>(0, group.memberCount);
            Assert.AreEqual(true, group.isBuildersClubOnly);
            Assert.AreEqual(true, group.publicEntryAllowed);
            Assert.AreEqual(true, group.isLocked);
            Assert.AreEqual(true, group.hasVerifiedBadge); 
        }

        [TestMethod]
        public void Get_GroupRoles()
        {
            const string json_reponse = @"
            {
              ""groupId"": 0,
              ""roles"": [
                {
                  ""id"": 0,
                  ""name"": ""string"",
                  ""description"": ""string"",
                  ""rank"": 0,
                  ""memberCount"": 0
                }
              ]
            }";

            Group group = JsonSerializer.Deserialize<Group>(json_reponse) 
                ?? throw new AssertFailedException("Group object should not be null here");
            
            Assert.AreEqual<ulong>(0, group.groupId);

            Group.Role role = group.roles![0];
           
                
            Assert.AreEqual<ulong>(0, role.roleId);
            Assert.AreEqual("string", role.name);
            Assert.AreEqual("string", role.description);
            Assert.AreEqual<ulong>(0, role.rank);
            Assert.AreEqual<ulong>(0, role.memberCount);
        }
    }
}
