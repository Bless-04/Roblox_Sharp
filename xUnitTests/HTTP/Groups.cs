using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Models;
using Roblox_Sharp.Exceptions;
using System.Collections.Generic;

using System.Threading.Tasks;
namespace xUnitTests.HTTP
{
    /// <summary>
    /// Tests <see cref="Groups_v1"/> and <see cref="Groups_v2"/> endpoints
    /// </summary>
    [Collection("Endpoints")]
    [Trait("Tests", "Integration")]
    public class Groups
    {
        [Fact]
        public async Task Get_Group()
        {
            Group group = await Groups_v1.Get_GroupAsync(2);

            Assert.True(261 == group.owner.userId, "Group.owner.userId is failing"); //owner is 261
            Assert.True(2 == group.groupId, "Group.groupId is failing"); //group id is 2
            Assert.True(group.memberCount > 100000, "Group.memberCount is failing"); //over 100k members as of 11/27/24

            await Assert.ThrowsAsync<InvalidIdException>(() => Groups_v1.Get_GroupAsync(0)); //doesnt exist
        }

        [Fact]
        public async Task Get_GroupRoles()
        {
            IReadOnlyList<Group.Role> roles = await Groups_v1.Get_GroupRolesAsync(9);

            Assert.True(roles.Count > 1, "Group.Role.Count is failing");

            Assert.True(roles[1].memberCount > 400000, "Group.Role.memberCount is failing"); //more than 400k as of 11/30

        }

        [Fact]
        public async Task Get_Groups()
        {
            IReadOnlyList<Group> groups = await Groups_v2.Get_GroupsAsync([1, 2, 3]);

            Assert.True(groups.Count == 3, "Group.count is failing");

            Group group1 = groups[0];
            Group group2 = groups[1];
            Group group3 = groups[2];

            Assert.True(
                1179762 == group1.owner.userId &&
                261 == group2.owner.userId &&
                24941 == group3.owner.userId,
                "Group.owner.userId is failing"
            );
            Assert.True(
                group1.created.Year == group2.created.Year &&
                group3.created.Year == group2.created.Year,
                "Group.created.Year is failing"
            ); // all created in 2009
        }
    }
}
