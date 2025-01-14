using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Enums;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit.Sdk;
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
            await Assert.ThrowsAsync<InvalidUserException>(() => Friends_v1.Get_FriendsCountAsync(BANNED));
        }

        [IntegrationTrait.Long_Integration]
        [Fact]
        public async Task Get_FollowersCount()
        {

            await Assert.ThrowsAsync<InvalidUserException>(() => Friends_v1.Get_FollowersCountAsync(DOEST_EXIST)); 
            await Assert.ThrowsAsync<InvalidUserException>(() => Friends_v1.Get_FollowersCountAsync(BANNED));

            ulong roblox = await Friends_v1.Get_FollowersCountAsync(1);
            ulong erik = await Friends_v1.Get_FollowersCountAsync(16);

            Assert.True(roblox > 100000 && erik > 100000, "Get_FollowersCount() is failing");

        }

        [IntegrationTrait]
        [Fact]
        public async Task Get_FollowingsCount()
        {

            ulong roblox = await Friends_v1.Get_FollowingsCountAsync(1); //roblox
            ulong erik = await Friends_v1.Get_FollowingsCountAsync(16); //erik.cassel

            Assert.True(roblox == 0 && erik > 0, "Get_FollowingsCount() is failing");

            //error checking
            await Assert.ThrowsAsync<InvalidUserException>(() => Friends_v1.Get_FollowingsCountAsync(0)); //doesnt exist
            await Assert.ThrowsAsync<InvalidUserException>(() => Friends_v1.Get_FollowingsCountAsync(5)); //BANNED user
        }

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

            //error checking

            await Assert.ThrowsAsync<InvalidUserException>(() => Friends_v1.Get_FollowingsAsync(5));
        }

       
        [IntegrationTrait.Long_Integration]
        [Fact]
        public async Task Get_Followings_Error() => 
            await Assert.ThrowsAsync<InvalidUserException>(() => Friends_v1.Get_FollowingsAsync(BANNED)); //throws nothing for doesnt exist

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


        [IntegrationTrait.Long_Integration]
        [Fact]
        public async Task Get_Followers()
        {
            Page<User> page = await Friends_v1.Get_FollowersAsync(1); //roblox

            //old page
            ulong some_id = page.data[0].userId;

            Assert.Null(page.previousPageCursor);

            //error checking
            await Assert.ThrowsAsync<InvalidUserException>(() => Friends_v1.Get_FollowersAsync(0)); //doesnt exist
            await Assert.ThrowsAsync<InvalidUserException>(() => Friends_v1.Get_FollowersAsync(5)); //BANNED user

            //new page
            page = await Friends_v1.Get_FollowersAsync(1, page: page); //roblox


            Assert.True(page.previousPageCursor != null, "Get_Followers() is failing");

            Assert.True(page.data[0].userId != some_id, "Get_Followers() is failing");

        }
    }
}
