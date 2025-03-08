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


            Assert.Equal<ulong>(0, group.GroupId);
            Assert.Equal("string", group.name);

            Assert.Equal("string", group.description);

            Assert.True(group.owner!.HasVerifiedBadge);
            Assert.Equal<ulong>(0, group.owner!.UserId);
            Assert.Equal("string", group.owner.Username);
            Assert.Null(group.owner.DisplayName);

            Assert.Equal("string", group.shout!.Body);
            Assert.True(group.shout.Poster.HasVerifiedBadge);
            Assert.Equal<ulong>(0, group.shout.Poster.UserId);
            Assert.Equal("string", group.shout.Poster.Username);
            Assert.Equal("poster", group.shout.Poster.DisplayName);

            Assert.Equal(2024, group.shout.Created.Year);
            Assert.Equal(2024, group.shout.Updated.Year);

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
            Assert.Equal<ulong>(0, group.GroupId);

            Group.Role role = group.Roles![0];


            Assert.Equal<ulong>(0, role.RoleId);
            Assert.Equal("string", role.Name);
            Assert.Equal("string", role.Description);
            Assert.Equal<ulong>(0, role.Rank);
            Assert.Equal<ulong>(0, role.MemberCount);
        }
    }
}
