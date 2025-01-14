using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Enums;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using static xUnitTests.User_Constants;


namespace xUnitTests.HTTP
{
    /// <summary>
    /// Test <see cref="Friends_v1"/> Endpoint
    /// </summary>
    [Collection("Endpoints")]
    public class Friends
    {
        [IntegrationTrait.Long_Integration]
        [Fact]
        public async Task Get_FriendsCount()
        {
            byte roblox = await Friends_v1.Get_FriendsCountAsync(1); //roblox
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
            ulong builderman = await Friends_v1.Get_FollowersCountAsync(BUILDERMAN);

            Assert.True(roblox > 100000 && builderman > 100000, "Get_FollowersCount() is failing");
        }

        [IntegrationTrait]
        [Theory]
        [InlineData(DOEST_EXIST)]
        [InlineData(DELETED)]
        public async Task Get_FollowersCount_Error(ulong id) => 
            await Assert.ThrowsAsync<InvalidUserException>(() => Friends_v1.Get_FollowersCountAsync(id));

        [IntegrationTrait.Long_Integration]
        [Fact]
        public async Task Get_FollowingsCount()
        {

            ulong roblox = await Friends_v1.Get_FollowingsCountAsync(ROBLOX); //roblox
            ulong erik = await Friends_v1.Get_FollowingsCountAsync(16); //erik.cassel

            Assert.True(roblox == 0 && erik > 0, "Get_FollowingsCount() is failing");

            //error checking
            await Assert.ThrowsAsync<InvalidUserException>(() => Friends_v1.Get_FollowingsCountAsync(DOEST_EXIST)); //doesnt exist
            await Assert.ThrowsAsync<InvalidUserException>(() => Friends_v1.Get_FollowingsCountAsync(BANNED)); //BANNED user
        }

        [IntegrationTrait]
        [Theory]
        [InlineData(DOEST_EXIST)]
        [InlineData(DELETED)]
        public async Task Get_FollowingsCount_Error(ulong id) => 
            await Assert.ThrowsAsync<InvalidUserException>(() => Friends_v1.Get_FollowingsAsync(id));

        [IntegrationTrait]
        [Theory]
        [InlineData(Limit.OneHundred)]
        [InlineData(Limit.Fifty)]
        [InlineData(Limit.TwentyFive)]
        [InlineData(Limit.Ten)]
        public async Task Get_Followings(Limit limit = Limit.Maximum, Sort sort = Sort.Asc, string? cursor = null)
        {
            const int id = 156; //builderman 


            Page<User> test = await Friends_v1.Get_FollowingsAsync(id, limit, sort, cursor);


            Assert.True(test.data.Count == (int)limit, "Get_Followings() is failing");
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
            IReadOnlyList<User> roblox_friends = await Friends_v1.Get_FriendsAsync(1); //roblox

            Assert.True(erik_friends.Count != 0 && roblox_friends.Count == 0, "Get_Friends() is failing");

            //error checking
            await Assert.ThrowsAsync<InvalidUserException>(() => Friends_v1.Get_FriendsAsync(0)); //doesnt exist
            await Assert.ThrowsAsync<InvalidUserException>(() => Friends_v1.Get_FriendsAsync(5)); //BANNED user
        }


        [IntegrationTrait]
        [Fact]
        public async Task Get_Followers()
        {
            Page<User> page = await Friends_v1.Get_FollowersAsync(ROBLOX); //roblox

            //old page
            ulong some_id = page.data[0].userId;

            Assert.Null(page.previousPageCursor);
            //new page
            page = await Friends_v1.Get_FollowersAsync(ROBLOX, page: page); //roblox


            Assert.True(page.previousPageCursor != null, "Get_Followers() is failing");

            Assert.True(page.data[0].userId != some_id, "Get_Followers() is failing");

        }

        [IntegrationTrait]
        [Theory]
        [InlineData(DOEST_EXIST)]
        [InlineData(DELETED)]
        public async Task Get_Followers_Error(ulong id) => await Assert.ThrowsAsync<InvalidUserException>(() => Friends_v1.Get_FollowersAsync(id));
    }
}
