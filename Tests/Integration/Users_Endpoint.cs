using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Models.v1;
using System.Threading.Tasks;

using static Tests.User_Constants;
namespace Tests.Integration
{
    /// <summary>
    /// Tests <see cref="Users_v1"/> endpoint
    /// </summary>
    [Collection(nameof(Integration))]
    public class Users_Endpoint : TestHelper
    {
        public const bool ExcludeBannedUsers = false;

        #region v1

        [IntegrationTrait]
        [Fact]
        public async Task Get_User()
        {
            UserInfo? roblox = await Users_v1.Get_UserAsync(ROBLOX);

            Assert.NotNull(roblox);

            Assert.True(roblox.UserId == ROBLOX, isFailing(nameof(roblox.UserId)));

            Assert.Equal(nameof(ROBLOX), roblox.Username, ignoreCase: true);
            Assert.True(roblox.Description.Length > 50,isFailing(nameof(roblox.Description)));
            Assert.True(roblox.DisplayName.Length > 0,isFailing(nameof(roblox.DisplayName)));

            Assert.True(roblox.HasVerifiedBadge, isFailing(nameof(roblox.HasVerifiedBadge)));

            Assert.False(roblox.IsBanned, isFailing(nameof(roblox.IsBanned)));
        }

        [IntegrationTrait.FailCase]
        [Fact]
        public async Task Get_User_Fail()
        {
            UserInfo? user = await Users_v1.Get_UserAsync(DOEST_EXIST);

            Assert.Null(user);
        }

        [IntegrationTrait]
        [Fact]
        public async Task Get_UserByUsername()
        {
            string message = isFailing(nameof(Users_v1.Get_UsersAsync) + " for usernames");

            var users = await Users_v1.Get_UsersAsync(["erik.cassel","Roblox"],ExcludeBannedUsers);

            Assert.NotNull(users);
            Assert.True(users.Count == 2,message);

            foreach (var user in users)
            {
                Assert.NotNull(user);
                Assert.Equal(user.Username,user.RequestedUsername);
                Assert.True(user.UserId != default,message);
                Assert.True(user.Username.Length > 0,message);
            }
        }

        [IntegrationTrait.FailCase]
        [Fact]
        public async Task Get_UserByUsername_Fail()
        {
            var user = await Users_v1.Get_UsersAsync([""],ExcludeBannedUsers);
            
            Assert.Empty(user!);
        }

        [IntegrationTrait]
        [Fact]
        public async Task Get_UserById()
        {
            string message = isFailing(nameof(Users_v1.Get_UsersAsync) + " for ids");
            var users = await Users_v1.Get_UsersAsync([ROBLOX,SHEDLETSKY,BUILDERMAN],ExcludeBannedUsers);

            Assert.NotNull(users);
            Assert.True(users.Count == 3, message);

            foreach (var user in users)
            {
                Assert.NotNull(user);

                if (user.UserId == SHEDLETSKY) Assert.False(user.HasVerifiedBadge, message);
                else Assert.True(user.HasVerifiedBadge,message);
                Assert.True(user.UserId != default,message);
                Assert.True(user.Username.Length > 0, message);
            }
        }

        [IntegrationTrait.FailCase]
        [Fact]
        public async Task Get_UserById_Fail()
        {
            var user = await Users_v1.Get_UsersAsync([DOEST_EXIST],ExcludeBannedUsers);

            Assert.Empty(user!);
        }

        [IntegrationTrait.RateLimitted]
        [Fact]
        public async Task Get_UsernameHistory()
        {
            var user = await Users_v1.Get_UsernameHistoryAsync(INCEPTIONTIME);

            
            Assert.NotNull(user);
            Assert.True(user.Count > 1 && user[0].Length > 0, isFailing(nameof(Get_UsernameHistory)));
        }


        [IntegrationTrait.RateLimitted.FailCase2]
        [Fact]
        public async Task Get_UsernameHistory_Fail()
        {
            var user = await Users_v1.Get_UsernameHistoryAsync(DELETED);

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
