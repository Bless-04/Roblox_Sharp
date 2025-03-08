using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Enums;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using static xUnitTests.User_Constants;

namespace xUnitTests.Integration
{
    /// <summary>
    /// Test <see cref="Friends_v1"/> Endpoint
    /// </summary>
    [Collection(nameof(Integration))]
    public class Friends
    {
        [IntegrationTrait.Long_Integration]
        [Fact]
        public async Task Get_FriendsCount()
        {
            byte roblox = await Friends_v1.Get_FriendsCountAsync(ROBLOX); //roblox
            byte erik = await Friends_v1.Get_FriendsCountAsync(16); //erik.cassel

            Assert.True(
                roblox == 0 &&  //roblox has no friends
                erik > 0,  //erik has friends
                "Get_FriendsCount() is failing"
            );

            //error checking
            await Assert.ThrowsAsync<InvalidUserException>(() => Friends_v1.Get_FriendsCountAsync(DOEST_EXIST));
            //await Assert.ThrowsAsync<InvalidUserException>(() => Friends_v1.Get_FriendsCountAsync(BANNED)); //allows banned users
        }

        [IntegrationTrait.Long_Integration]
        [Fact]
        public async Task Get_FollowersCount()
        {
            //await Assert.ThrowsAsync<InvalidUserException>(() => Friends_v1.Get_FollowersCountAsync(BANNED)); it allows banned users

            ulong roblox = await Friends_v1.Get_FollowersCountAsync(ROBLOX);
           

            Assert.True(roblox > 100000, "Get_FollowersCount() is failing");
        }

        [IntegrationTrait.Long_Integration]
        [Theory]
        [InlineData(DOEST_EXIST)]
        [InlineData(DELETED)]
        public async Task Get_FollowersCount_Error(ulong id) => 
            await Assert.ThrowsAsync<InvalidUserException>(() => Friends_v1.Get_FollowersCountAsync(id));

        [IntegrationTrait]
        [Fact]
        public async Task Get_FollowingsCount()
        {
            ulong test = await Friends_v1.Get_FollowingsCountAsync(BUILDERMAN); //builderman follows millions of players

            Assert.True(test > ushort.MaxValue, "Get_FollowingsCount() is failing");
        }

        [IntegrationTrait.Long_Integration]
        [Theory]
        [InlineData(DOEST_EXIST)]
        [InlineData(DELETED)]
        public async Task Get_FollowingsCount_Error(ulong id) => 
            await Assert.ThrowsAsync<InvalidUserException>(() => Friends_v1.Get_FollowingsAsync(id));

        [IntegrationTrait.Long_Integration]
        [Theory]
        [InlineData(Limit.OneHundred)]
        [InlineData(Limit.Fifty)]
        [InlineData(Limit.TwentyFive)]
        [InlineData(Limit.Ten)]
        public async Task Get_Followings(Limit limit = Limit.Maximum, Sort sort = Sort.Asc, string? cursor = null)
        {
            Page<User> test = await Friends_v1.Get_FollowingsAsync(BUILDERMAN, limit, sort, cursor);
            Assert.True(test.Data.Count == (int)limit, "Get_Followings() is failing");
        }

        [IntegrationTrait.Long_Integration]
        [Theory]
        [InlineData(DOEST_EXIST)]
        [InlineData(DELETED)]
        public async Task Get_Followings_Error(ulong id) => 
            await Assert.ThrowsAsync<InvalidUserException>(() => Friends_v1.Get_FollowingsAsync(id)); //throws nothing for doesnt exist

        [IntegrationTrait]
        [Fact]
        public async Task Get_Friends()
        {

            IReadOnlyList<User> erik_friends = await Friends_v1.Get_FriendsAsync(16); //erik
            IReadOnlyList<User> roblox_friends = await Friends_v1.Get_FriendsAsync(ROBLOX); //roblox

            Assert.True(erik_friends.Count != 0 && roblox_friends.Count == 0, "Get_Friends() is failing");

            //error checking
            await Assert.ThrowsAsync<InvalidUserException>(() => Friends_v1.Get_FriendsAsync(0)); //doesnt exist
            await Assert.ThrowsAsync<InvalidUserException>(() => Friends_v1.Get_FriendsAsync(5)); //BANNED user
        }


        [IntegrationTrait.Long_Integration]
        [Fact]
        public async Task Get_Followers()
        {
            Page<User> page = await Friends_v1.Get_FollowersAsync(ROBLOX); //roblox

            //old page
            ulong some_id = page.Data[0].UserId;

            Assert.Null(page.PreviousPageCursor);


            await Task.Delay(61000); //special case 
            //new page
            page = await Friends_v1.Get_FollowersAsync(ROBLOX, page: page); //roblox


            Assert.True(page.PreviousPageCursor != null, "Get_Followers() is failing");

            Assert.True(page.Data[0].UserId != some_id, "Get_Followers() is failing");

        }

        [IntegrationTrait.Long_Integration]
        [Theory]
        [InlineData(DOEST_EXIST)]
        [InlineData(DELETED)]
        public async Task Get_Followers_Error(ulong id) => await Assert.ThrowsAsync<InvalidUserException>(() => Friends_v1.Get_FollowersAsync(id));
    }
}
