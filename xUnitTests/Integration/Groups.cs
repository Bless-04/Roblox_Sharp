using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace xUnitTests.Integration
{
    /// <summary>
    /// Tests <see cref="Groups_v1"/> and <see cref="Groups_v2"/> endpoints
    /// </summary>
    [Collection(nameof(Integration))]
    public class Groups
    {
        [IntegrationTrait]
        [Fact]
        public async Task Get_Group()
        {
            Group group = await Groups_v1.Get_GroupAsync(2);

            Assert.NotNull(group.Owner);
            Assert.True(User_Constants.SHEDLETSKY == group.Owner.UserId, nameof(group.Owner.UserId) + " is failing"); //owner is 261
            Assert.True(2 == group.GroupId, $"{nameof(group.GroupId)} is failing"); //group id is 2
            Assert.True(group.MemberCount > 100000, $"{nameof(group.MemberCount)} is failing"); //over 100k members as of 11/27/24

            await Assert.ThrowsAsync<InvalidUserException>(() => Groups_v1.Get_GroupAsync(0)); //doesnt exist
        }

        [IntegrationTrait]
        [Fact]
        public async Task Get_GroupRoles()
        {
            IReadOnlyList<Group.Role> roles = await Groups_v1.Get_GroupRolesAsync(9);

            Assert.True(roles.Count > 1, "Group.Role.Count is failing");

            Assert.True(roles[1].MemberCount > 400000, "Group.Role.memberCount is failing"); //more than 400k as of 11/30

        }

        [IntegrationTrait.Long_Integration]
        [Fact]
        public async Task Get_Groups()
        {
            IReadOnlyList<Group> groups = await Groups_v2.Get_GroupsAsync([1, 2, 3]);

            Assert.True(groups.Count == 3, $"{nameof(groups.Count)} is failing");

            Group group1 = groups[0];
            Group group2 = groups[1];
            Group group3 = groups[2];

            Assert.True(
                1179762 == group1.Owner!.UserId &&
                261 == group2.Owner!.UserId &&
                24941 == group3.Owner!.UserId,
                "Group.owner.userId is failing"
            );
            Assert.True(
                group1.Created.Year == group2.Created.Year &&
                group3.Created.Year == group2.Created.Year,
                $"{nameof(group1.Created.Year)} is failing"
            ); // all created in 2009
        }
    }
}
