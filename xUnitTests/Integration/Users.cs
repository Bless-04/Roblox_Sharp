using Roblox_Sharp;
using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Models.v1;
using System;
using System.Threading.Tasks;

using static xUnitTests.User_Constants;
namespace xUnitTests.Integration
{
    /// <summary>
    /// Tests <see cref="Users_v1"/> endpoint
    /// </summary>
    [Collection(nameof(Integration))]
    public class Users
    {

        #region v1

        [IntegrationTrait]
        [Fact]
        public async Task Get_User()
        {
            User? roblox = await Users_v1.Get_UserAsync(ROBLOX);

            Assert.NotNull(roblox);

            Assert.True(roblox.UserId == ROBLOX, TestHelper.isFailing(nameof(roblox.UserId)));

            Assert.Equal(nameof(ROBLOX), roblox.Username, ignoreCase: true);
        }

        [IntegrationTrait]
        [Fact]
        public async Task Get_UserFail()
        {
            
            WebAPI.OnFailedRequest += (sender,args) =>
            {
                var s = 
            }
            
            User? user = await Users_v1.Get_UserAsync(5);
           
            
            Assert.Null(user);

            

        }

        /*
        [IntegrationTrait]
        [Theory]
        [InlineData(ROBLOX, nameof(ROBLOX))]
        [InlineData(BUILDERMAN, nameof(BUILDERMAN))]
        [InlineData(SHEDLETSKY, nameof(SHEDLETSKY))]
        public async Task Get_Usernames(ulong id, string Username)
        {
            Response test = (await Users_v1.Get_UsernamesAsync([id]))[0];//

            Assert.NotNull(test.Username);
            Assert.True(
                test.UserId == id &&
                test.Username.Equals(Username, System.StringComparison.OrdinalIgnoreCase),
                "Get_Usernames() is failing"
            );
        }

        [IntegrationTrait]
        [Fact]
        public async Task Get_Usernames_Error()
        {
            await Assert.ThrowsAsync<InvalidUserException>(() => Users_v1.Get_UsernamesAsync([DOEST_EXIST]));
            await Assert.ThrowsAsync<InvalidUserException>(() => Users_v1.Get_UsernamesAsync([])); //empty});
        }

        [IntegrationTrait]
        [Theory]
        [InlineData(ROBLOX, nameof(ROBLOX))]
        [InlineData(BUILDERMAN, nameof(BUILDERMAN))]
        [InlineData(SHEDLETSKY, nameof(SHEDLETSKY))]
        public async Task Get_Users(ulong expectedCreationId, string Username)
        {
            Response test = (await Users_v1.Get_UsersAsync([Username]))[0];

            await Assert.ThrowsAsync<InvalidUserException>(() => Users_v1.Get_UsersAsync([]));

            Assert.True(test.UserId == expectedCreationId, "User.userId is failing");
        }

        [IntegrationTrait.Long_Integration]
        [Fact]
        public async Task Get_UserSearch()
        {
            Page<Response> page = await Users_v1.Get_UserSearchAsync("robl", Limit.MAX);

            Assert.True(page.Data.Count != 0, "Page.data should not be empty");
            Assert.True(page.PreviousPageCursor == null, "previouspagecursor should be null");
            Assert.True(page.NextPageCursor != null, "nextpagecursor should not be null");
        }

        [IntegrationTrait.Long_Integration]
        [Fact]
        public async Task Get_UsernameHistory()
        {
            //7733466 is an admin
            Page<string> y = await Users_v1.Get_UsernameHistoryAsync(7733466, Limit.Ten);

            Assert.False(y.Data.Count == 0, "Page.data should not be empty");
        }

        [IntegrationTrait.Long_Integration]
        [Theory]
        [InlineData(BANNED)]
        [InlineData(DOEST_EXIST)]
        public async Task Get_UsernameHistory_Error(ulong id) =>
            await Assert.ThrowsAsync<InvalidUserException>(() => Users_v1.Get_UsernameHistoryAsync(id));

        */

        #endregion
    }
}
