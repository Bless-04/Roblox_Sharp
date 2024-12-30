using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Enums;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Models;

using System.Collections.Generic;


namespace xUnitTests.HTTP
{
    /// <summary>
    /// Test <see cref="Friends_v1"/> Endpoint
    /// </summary>
    [Collection("Endpoints")]
    [Trait("Tests", "Integration")]
    public class Friends : IRateLimited
    {
        [Fact]
        public void Get_FriendsCount() => Test(async () =>
        {

            byte roblox = await Friends_v1.Get_FriendsCountAsync(1); //roblox
            byte erik = await Friends_v1.Get_FriendsCountAsync(16); //erik.cassel

            Assert.True(
                roblox == 0 &&  //roblox has not friends
                erik > 0,  //erik has friends
                "Get_FriendsCount() is failing"
            );

            //error checking
            await Assert.ThrowsAsync<InvalidIdException>(() => Friends_v1.Get_FriendsCountAsync(0)); //doesnt exist
            await Assert.ThrowsAsync<InvalidIdException>(() => Friends_v1.Get_FriendsCountAsync(5)); //terminated user
        }, "Get_FriendsCount()");


        [Fact]
        public void Get_FollowersCount() => Test(async () =>
        {

            await Assert.ThrowsAsync<InvalidIdException>(() => Friends_v1.Get_FollowersCountAsync(0)); //doesnt exist
            await Assert.ThrowsAsync<InvalidIdException>(() => Friends_v1.Get_FollowersCountAsync(5)); //terminated user

            ulong roblox = await Friends_v1.Get_FollowersCountAsync(1);
            ulong erik = await Friends_v1.Get_FollowersCountAsync(16);

            Assert.True(roblox != erik, "Get_FollowersCount() is failing");

        }, "Get_FollowersCount()");

        [Fact]
        public void Get_FollowingsCount() => Test(async () =>
        {

            ulong roblox = await Friends_v1.Get_FollowingsCountAsync(1); //roblox
            ulong erik = await Friends_v1.Get_FollowingsCountAsync(16); //erik.cassel

            Assert.True(roblox == 0 && erik > 0, "Get_FollowingsCount() is failing");

            //error checking
            await Assert.ThrowsAsync<InvalidIdException>(() => Friends_v1.Get_FollowingsCountAsync(0)); //doesnt exist
            await Assert.ThrowsAsync<InvalidIdException>(() => Friends_v1.Get_FollowingsCountAsync(5)); //terminated user
        }, "Get_Following");


        [RateLimitedFact]
        public void Get_Followings() => Test(async () =>
        {

            Page<User> roblox = await Friends_v1.Get_FollowingsAsync(1); //roblox
            Page<User> erik = await Friends_v1.Get_FollowingsAsync(16, Limit.Ten); //erik.cassel

            Assert.True(roblox.data.Count == 0 && erik.data.Count != 0, "Get_Followings() is failing");

            //error checking
            await Assert.ThrowsAsync<InvalidIdException>(() => Friends_v1.Get_FollowingsAsync(0)); //doesnt exist
            await Assert.ThrowsAsync<InvalidIdException>(() => Friends_v1.Get_FollowingsAsync(5)); //terminated user
        });

        [RateLimitedFact]
        public void Get_Friends() => Test(async () =>
        {

            IReadOnlyList<User> erik_friends = await Friends_v1.Get_FriendsAsync(16); //erik
            IReadOnlyList<User> roblox_friends = await Friends_v1.Get_FriendsAsync(1); //roblox

            Assert.True(erik_friends.Count != 0 && roblox_friends.Count == 0, "Get_Friends() is failing");

            //error checking
            await Assert.ThrowsAsync<InvalidIdException>(() => Friends_v1.Get_FriendsAsync(0)); //doesnt exist
            await Assert.ThrowsAsync<InvalidIdException>(() => Friends_v1.Get_FriendsAsync(5)); //terminated user
        });

        [RateLimitedFact]
        public void Get_Followers() => Test(async () =>
        {
            Page<User> page = await Friends_v1.Get_FollowersAsync(1); //roblox

            //old page
            ulong some_id = page.data[0].userId;

            Assert.Null(page.previousPageCursor);

            //error checking
            await Assert.ThrowsAsync<InvalidIdException>(() => Friends_v1.Get_FollowersAsync(0)); //doesnt exist
            await Assert.ThrowsAsync<InvalidIdException>(() => Friends_v1.Get_FollowersAsync(5)); //terminated user

            //new page
            page = Friends_v1.Get_FollowersAsync(1, page: page).Result; //roblox


            Assert.True(page.previousPageCursor != null, "Get_Followers() is failing");

            Assert.True(page.data[0].userId != some_id, "Get_Followers() is failing");

        }, "Get_Followers()");
    }
}
