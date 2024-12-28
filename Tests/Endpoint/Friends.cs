using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Exceptions;

using System.Threading.Tasks;



namespace Tests.Endpoint
{
    [Collection("Endpoints")]
    public class Friends : IRateLimited
    {
        [RateLimited]
        public void Get_FriendsCount() => Test(async () =>
        {

            byte roblox = await Friends_v1.Get_FriendsCountAsync(1); //roblox
            byte erik = await Friends_v1.Get_FriendsCountAsync(16); //erik.cassel
           
            Assert.True(
                roblox == 0  &&  //roblox has not friends
                erik > 0,  //erik has friends
                "Get_FriendsCount() is failing"
            );

            //error checking
            await Assert.ThrowsAsync<InvalidIdException>(() => Friends_v1.Get_FriendsCountAsync(0)); //doesnt exist
            await Assert.ThrowsAsync<InvalidIdException>(() => Friends_v1.Get_FriendsCountAsync(5)); //terminated user
        }, "Get_FriendsCount()") ;


        [RateLimited]
        public void Get_FollowersCount() => Test(async () => {
            
            await Assert.ThrowsAsync<InvalidIdException>(() => Friends_v1.Get_FollowersCountAsync(0)); //doesnt exist
            await Assert.ThrowsAsync<InvalidIdException>(() => Friends_v1.Get_FollowersCountAsync(5)); //terminated user

            ulong roblox = await Friends_v1.Get_FollowersCountAsync(1);
            ulong erik = await Friends_v1.Get_FollowersCountAsync(16);

            Assert.True(roblox != erik, "Get_FollowersCount() is failing");

        }, "Get_FollowersCount()") ;
        
    }
}
