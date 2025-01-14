using Microsoft.VisualBasic;
using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Enums;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Framework;
using Roblox_Sharp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using xUnitTests.HTTP;

using static xUnitTests.User_Constants;
namespace xUnitTests.HTTP
{
    
    
    /// <summary>
    /// Tests <see cref="Users_v1"/> endpoint
    /// </summary>
    [Collection("Endpoints")]
    public class Users 
    {
        public static IEnumerable<object[]> Safe_Users => User_Constants.Safe_Users;

        public static IEnumerable<object[]> Error => User_Constants.Unsafe_Users;

        [IntegrationTrait]
        [Fact]
        public async Task Get_User()
        {
            //error checking
            await Assert.ThrowsAsync<InvalidUserException>(() => Users_v1.Get_UserAsync(ROBLOX));
            await Assert.ThrowsAsync<InvalidUserException>(() => Users_v1.Get_UserAsync(TERMINATED)); //terminated user

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
        [MemberData(nameof(Safe_Users))]
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
        [MemberData(nameof(Safe_Users))]
        public async Task Get_Users(ulong expected_id,string username)
        {
            User test = (await Users_v1.Get_UsersAsync([username])) [0];

            await Assert.ThrowsAsync<InvalidUserException>(() => Users_v1.Get_UsersAsync([]));

            Assert.True( test.userId == expected_id,"User.userId is failing");
        }

        [IntegrationTrait]
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

        [IntegrationTrait]
        [Theory]
        [MemberData(nameof(Error))]
        public async Task Get_UsernameHistory_Error(ulong id) =>
            await Assert.ThrowsAsync<InvalidUserException>(() => Users_v1.Get_UsernameHistoryAsync(id)); 
        
        
    }

    



}
