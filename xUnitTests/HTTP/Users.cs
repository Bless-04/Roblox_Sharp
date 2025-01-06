

using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Enums;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xUnitTests.HTTP
{
    /// <summary>
    /// Tests <see cref="Users_v1"/> endpoint
    /// </summary>
    [Collection("Endpoints")]
    [Trait("Tests", "Integration")]
    public class Users : IRateLimited
    {
        [Fact]
        public async Task Get_User()
        {
            //error checking
            await Assert.ThrowsAsync<InvalidUserException>(() => Users_v1.Get_UserAsync(0));
            await Assert.ThrowsAsync<InvalidUserException>(() => Users_v1.Get_UserAsync(5)); //terminated user

            User roblox = await Users_v1.Get_UserAsync(1);

            Assert.True(roblox.userId == 1, "User.userId is failing");

            Assert.True(
                roblox.username == "Roblox" && roblox.displayName!.Equals(roblox.username),
                "User.username is failing"
            );
        }

        [RateLimitedFact]
        public void Get_Usernames() => Test(async () =>
        {
            IReadOnlyList<User> user_list = await Users_v1.Get_UsernamesAsync([1, 16]);//roblox, erik.cassel

            await Assert.ThrowsAsync<InvalidUserException>(() => Users_v1.Get_UsernamesAsync([0])); //doesnt exist
            await Assert.ThrowsAsync<InvalidUserException>(() => Users_v1.Get_UsernamesAsync([])); //empty

            Assert.True(user_list[0].username == "Roblox", "User.username is failing");

        }, "Get_Usernames()", 0);

        [Fact]
        public async Task Get_Users()
        {
            IReadOnlyList<User> user_list = await Users_v1.Get_UsersAsync(["roblox", "erik.cassel", "builderman"]);

            user_list = user_list
                .OrderBy(u => u)
                .ToList();

            await Assert.ThrowsAsync<InvalidUserException>(() => Users_v1.Get_UsersAsync([]));

            Assert.True(
                   user_list[2].userId == 1 &&
                   user_list[1].userId == 16 &&
                   user_list[0].userId == 156,
                   "User.userId is failing"
            );
        }

        [RateLimitedFact]
        public void Get_UserSearch() => Test(async () =>
        {
            Page<User> page = await Users_v1.Get_UserSearchAsync("robl", Limit.MAX);

            Assert.True(page.data.Count != 0, "Page.data should not be empty");
            Assert.True(page.previousPageCursor == null, "previouspagecursor should be null");
            Assert.True(page.nextPageCursor != null, "nextpagecursor should not be null");
        }, "Get_UserSearch()", 0);

        [RateLimitedFact]
        public void Get_UsernameHistory() => Test(async () =>
        {
            //7733466 is an admin
            //Page<User> x = Users_v1.Get_UsernameHistoryAsync(1).Result;
            Page<User> y = await Users_v1.Get_UsernameHistoryAsync(7733466, Limit.MAX);

            await Assert.ThrowsAsync<InvalidUserException>(() => Users_v1.Get_UsernameHistoryAsync(5)); //terminated user

            Assert.False(y.data.Count == 0, "Page.data should not be empty");
        }, "Get_UsernameHistory()", 0);




    }



}
