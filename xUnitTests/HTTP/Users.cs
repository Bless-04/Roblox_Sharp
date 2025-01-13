using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Enums;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace xUnitTests.HTTP
{
    /// <summary>
    /// Tests <see cref="Users_v1"/> endpoint
    /// </summary>
    [Collection("Endpoints")]
    [Trait("Tests", "Integration")]
    public class Users : IDelayedTest
    {
        public const int TERMINATED = 5;
        public const int DOEST_EXIST = 0;


        public static IEnumerable<object[]> Error_Cases()
        {
            yield return new object[] { TERMINATED };
            yield return new object[] { DOEST_EXIST };
            yield return new object[] { };
        }

        [Fact]
        public async Task Get_User()
        {
            //error checking
            await Assert.ThrowsAsync<InvalidUserException>(() => Users_v1.Get_UserAsync(0));
            await Assert.ThrowsAsync<InvalidUserException>(() => Users_v1.Get_UserAsync(5)); //terminated user

            User roblox = await Users_v1.Get_UserAsync(1);

            Assert.True(roblox.userId == 1, "User.userId is failing");

            Assert.True(
                roblox.username == "Roblox" && roblox.displayName == null,
                "User.username is failing"
            );
        }

        [Theory]
        [InlineData(1,"roblox")]
        [InlineData(16,"erik.cassel")]
        public async Task Get_Usernames(ulong id,string username)
        {

            User test = (await Users_v1.Get_UsernamesAsync([id]))[0] ;//

            Assert.True(
                test.userId == id && 
                test.username.Equals(username,System.StringComparison.OrdinalIgnoreCase),
                "Get_Usernames() is failing"
            );

        }

        [Fact]
        public async Task Get_Usernames_Error()
        {
            await Assert.ThrowsAsync<InvalidUserException>(() => Users_v1.Get_UsernamesAsync([0])); //doesnt exist
            await Assert.ThrowsAsync<InvalidUserException>(() => Users_v1.Get_UsernamesAsync([])); //empty});
        }

        [Theory]
        [InlineData(1,"roblox")]
        [InlineData(16,"erik.cassel")]
        [InlineData(156,"builderman")]
        public async Task Get_Users(ulong expected_id,string username)
        {
            User test = (await Users_v1.Get_UsersAsync([username])) [0];

            await Assert.ThrowsAsync<InvalidUserException>(() => Users_v1.Get_UsersAsync([]));

            Assert.True( test.userId == expected_id,"User.userId is failing");
        }

        [Fact]
        public async Task Get_UserSearch()
        {
            Page<User> page = await Users_v1.Get_UserSearchAsync("robl", Limit.MAX);

            Assert.True(page.data.Count != 0, "Page.data should not be empty");
            Assert.True(page.previousPageCursor == null, "previouspagecursor should be null");
            Assert.True(page.nextPageCursor != null, "nextpagecursor should not be null");
        }

        [Fact]
        public async Task Get_UsernameHistory()
        {
            //7733466 is an admin
            Page<User> y = await Users_v1.Get_UsernameHistoryAsync(7733466, Limit.MAX);

            Assert.False(y.data.Count != 0, "Page.data should not be empty");
        }


        [Theory]
        [MemberData(nameof(Error_Cases))]
        public async Task Get_UsernameHistory_Error(ulong id) =>
            await Assert.ThrowsAsync<InvalidUserException>(() => Users_v1.Get_UsernameHistoryAsync(id)); 
        
    }



}
