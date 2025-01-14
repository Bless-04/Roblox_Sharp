using Microsoft.VisualBasic;
using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Enums;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using static xUnitTests.User_Constants;
namespace xUnitTests.Integration
{
    /// <summary>
    /// Tests <see cref="Users_v1"/> endpoint
    /// </summary>
    [Collection("Integration")]
    public class Users 
    {
        [IntegrationTrait]
        [Fact]
        public async Task Get_User()
        {
            //error checking
            await Assert.ThrowsAsync<InvalidUserException>(() => Users_v1.Get_UserAsync(DOEST_EXIST));
            //await Assert.ThrowsAsync<InvalidUserException>(() => Users_v1.Get_UserAsync(BANNED)); //allows banned users

            User roblox = await Users_v1.Get_UserAsync(ROBLOX);

            Assert.True(roblox.userId == ROBLOX, "User.userId is failing");

            Assert.True(
                roblox.username.Equals(nameof(ROBLOX), StringComparison.OrdinalIgnoreCase) 
                && roblox.displayName == null,
                "User.username is failing"
            );
        }

        [IntegrationTrait]
        [Theory]
        [InlineData(ROBLOX, nameof(ROBLOX))]
        [InlineData(BUILDERMAN, nameof(BUILDERMAN))]
        [InlineData(SHEDLETSKY,nameof(SHEDLETSKY))]
        public async Task Get_Usernames(ulong id,string username)
        {
            User test = (await Users_v1.Get_UsernamesAsync([id]))[0] ;//

            Assert.True(
                test.userId == id && 
                test.username.Equals(username,System.StringComparison.OrdinalIgnoreCase),
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
        public async Task Get_Users(ulong expected_id,string username)
        {
            User test = (await Users_v1.Get_UsersAsync([username])) [0];

            await Assert.ThrowsAsync<InvalidUserException>(() => Users_v1.Get_UsersAsync([]));

            Assert.True( test.userId == expected_id,"User.userId is failing");
        }

        [IntegrationTrait.Long_Integration]
        [Fact]
        public async Task Get_UserSearch()
        {
            Page<User> page = await Users_v1.Get_UserSearchAsync("robl", Limit.MAX);

            Assert.True(page.data.Count != 0, "Page.data should not be empty");
            Assert.True(page.previousPageCursor == null, "previouspagecursor should be null");
            Assert.True(page.nextPageCursor != null, "nextpagecursor should not be null");
        }

        [IntegrationTrait.Long_Integration]
        [Fact]
        public async Task Get_UsernameHistory()
        {
            //7733466 is an admin
            Page<User> y = await Users_v1.Get_UsernameHistoryAsync(7733466);

            Assert.False(y.data.Count != 0, "Page.data should not be empty");
        }

        [IntegrationTrait.Long_Integration]
        [Theory]
        [InlineData(BANNED)]
        [InlineData(DOEST_EXIST)]
        public async Task Get_UsernameHistory_Error(ulong id) =>
            await Assert.ThrowsAsync<InvalidUserException>(() => Users_v1.Get_UsernameHistoryAsync(id)); 
        
    }

    



}
