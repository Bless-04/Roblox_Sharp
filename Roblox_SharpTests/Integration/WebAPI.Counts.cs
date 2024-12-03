using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Exceptions;

namespace Roblox_SharpTests.Integration;

public partial class WebAPI_Test
{
    //After 60 secs these test must always succeed
    [TestClass]
    public class Counts
    {
        [TestMethod]
        public void FriendsCount()
        {

            var x = Friends_v1.Get_FriendsCountAsync(1).Result; //roblox
            var y = Friends_v1.Get_FriendsCountAsync(16).Result; //erik.cassel
            var z = Friends_v1.Get_FriendsCountAsync(156).Result; //builderman

            Assert.AreEqual(x, z);
            Assert.AreNotEqual(x, y);

            //error checking
            Assert.ThrowsExceptionAsync<InvalidIdException>(() => Friends_v1.Get_FriendsCountAsync(0)); //doesnt exist
            Assert.ThrowsExceptionAsync<InvalidIdException>(() => Friends_v1.Get_FriendsCountAsync(5)); //terminated user

        }

        [TestMethod]
        public void FollowersCount()
        {
            Assert.ThrowsExceptionAsync<InvalidIdException>(() => Friends_v1.Get_FollowersCountAsync(0)); //doesnt exist
            Assert.ThrowsExceptionAsync<InvalidIdException>(() => Friends_v1.Get_FollowersCountAsync(5)); //terminated user
                                                                                                          //roblox vs erik.cassel
            Assert.AreNotEqual(Friends_v1.Get_FollowersCountAsync(1).Result, Friends_v1.Get_FollowersCountAsync(16).Result);

        }


        [TestMethod]
        public void FollowingsCount()
        {

            var x = Friends_v1.Get_FollowingsCountAsync(1).Result; //roblox
            var y = Friends_v1.Get_FollowingsCountAsync(16).Result; //erik.cassel

            Assert.AreEqual(x, (ulong)0);

            Assert.AreNotEqual(x, y);
            Assert.AreNotEqual(y, (ulong)0);

            //error checking
            Assert.ThrowsExceptionAsync<InvalidIdException>(() => Friends_v1.Get_FollowingsCountAsync(0)); //doesnt exist
            Assert.ThrowsExceptionAsync<InvalidIdException>(() => Friends_v1.Get_FollowingsCountAsync(5)); //terminated user
        }

    }
}
