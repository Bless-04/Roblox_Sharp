using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Enums;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.JSON_Models;

namespace Roblox_SharpTests.Integration;

public partial class WebAPI_Test
{
    /// <summary>
    /// These tests are prone to rate limitting 
    /// </summary>
    [TestCategory("Integration (Exhaustive)")]
    [TestClass]
    public class Exhaustive
    {
        [TestInitialize]
        public void Initialize() => Task.Delay(60000).Wait();

       

        [TestMethod]
        public void Viewable_Inventory()
        {
            bool x = Inventory_v1.Get_CanViewInventoryAsync(1).Result;

            Assert.IsFalse(x);
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


        [TestMethod]
        public void Followings()
        {
            
            Page<User> x = Friends_v1.Get_FollowingsAsync(1).Result; //roblox
            Page<User> y = Friends_v1.Get_FollowingsAsync(16, Limit.Ten).Result; //erik.cassel

            Assert.IsTrue(x.data.Count == 0);
            Assert.IsTrue(y.data.Count != 0);

            //error checking
            Assert.ThrowsExceptionAsync<InvalidIdException>(() => Friends_v1.Get_FollowingsAsync(0)); //doesnt exist
            Assert.ThrowsExceptionAsync<InvalidIdException>(() => Friends_v1.Get_FollowingsAsync(5)); //terminated user
        }

        [TestMethod]
        public void Friends()
        {

            IReadOnlyList<User> erik_friends = Friends_v1.Get_FriendsAsync(16).Result; //erik
            IReadOnlyList<User> roblox_friends = Friends_v1.Get_FriendsAsync(1).Result; //roblox

            Assert.AreNotEqual(erik_friends.Count, 0);
            Assert.AreEqual(roblox_friends.Count, 0);
        }

        [TestMethod]
        public void Followers()
        {
            Page<User> x = Friends_v1.Get_FollowersAsync(1).Result; //roblox

            //old page
            ulong some_id = x.data[0].userId;

            Assert.IsNotNull(some_id);


            Assert.IsNull(x.previousPageCursor);

            //error checking
            Assert.ThrowsExceptionAsync<InvalidIdException>(() => Friends_v1.Get_FollowersAsync(0)); //doesnt exist
            Assert.ThrowsExceptionAsync<InvalidIdException>(() => Friends_v1.Get_FollowersAsync(5)); //terminated user

            //new page
            x = Friends_v1.Get_FollowersAsync(1, page: x).Result; //roblox


            Assert.IsNotNull(x.previousPageCursor);

            Assert.AreNotEqual(x.data[0].userId, some_id);

        }

       

    }
}
