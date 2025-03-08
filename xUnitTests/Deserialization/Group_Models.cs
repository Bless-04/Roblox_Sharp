using Roblox_Sharp.Models;
using System.Text.Json;

namespace xUnitTests.Deserialization
{
    /// <summary>
    /// Tests Serialization for all Group endpoints
    /// </summary>
    [Trait(nameof(Roblox_Sharp.Models), nameof(Deserialization))]
    public class Group_Models
    {
        [Fact]
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
                    ""displayName"": ""poster""
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

            Group? group = JsonSerializer.Deserialize<Group>(json_response);

            Assert.NotNull(group);


            Assert.Equal<ulong>(0, group.groupId);
            Assert.Equal("string", group.name);

            Assert.Equal("string", group.description);

            Assert.True(group.owner!.hasVerifiedBadge);
            Assert.Equal<ulong>(0, group.owner!.userId);
            Assert.Equal("string", group.owner.Username);
            Assert.Null(group.owner.DisplayName);

            Assert.Equal("string", group.shout!.body);
            Assert.True(group.shout.poster.hasVerifiedBadge);
            Assert.Equal<ulong>(0, group.shout.poster.userId);
            Assert.Equal("string", group.shout.poster.Username);
            Assert.Equal("poster", group.shout.poster.DisplayName);

            Assert.Equal(2024, group.shout.created.Year);
            Assert.Equal(2024, group.shout.updated.Year);

            Assert.Equal<ulong>(0, group.memberCount);
            Assert.True(group.isBuildersClubOnly);
            Assert.True(group.publicEntryAllowed);
            Assert.True(group.isLocked);
            Assert.True(group.hasVerifiedBadge);
        }

        [Fact]
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

            Group? group = JsonSerializer.Deserialize<Group>(json_reponse);

            Assert.NotNull(group);
            Assert.Equal<ulong>(0, group.groupId);

            Group.Role role = group.roles![0];


            Assert.Equal<ulong>(0, role.roleId);
            Assert.Equal("string", role.name);
            Assert.Equal("string", role.description);
            Assert.Equal<ulong>(0, role.rank);
            Assert.Equal<ulong>(0, role.memberCount);
        }
    }
}
