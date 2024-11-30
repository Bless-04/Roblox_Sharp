
using System.Diagnostics;

using Roblox_Sharp;

using Roblox_Sharp.Enums;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.JSON;

using Roblox_Sharp.Endpoints;
using Roblox_Sharp.JSON.Users;

namespace Roblox_SharpTests
{
    [TestClass]
    public partial class WebAPI_Test
    {
        public WebAPI_Test()
        {
           WebAPI.OnSuccessfulRequest += OnSuccessfulRequest;
           WebAPI.OnFailedRequest += OnFailedRequest;  
        }

        public void OnSuccessfulRequest(object? sender, EventArgs e) => Debug.WriteLine("SUCCESS " + (sender as HttpResponseMessage)?.RequestMessage);
        public void OnFailedRequest(object? sender, EventArgs e) => Debug.WriteLine("HANDLED "  + (sender as HttpResponseMessage)?.RequestMessage );

        [TestMethod]
        public void Viewable_Inventory()
        {
            bool x = Inventory_v1.Get_CanViewInventoryAsync(1).Result; 

            Assert.IsFalse(x);
        }

        [TestMethod]
        public void GroupData()
        {
            Group group = Groups_v1.Get_GroupAsync(2).Result;

            
            Assert.AreEqual((ulong) 261,group.owner.id); //owner is 261

            Assert.AreEqual( (ulong) 2, group.id); //group id is 2

            Assert.IsTrue(group.memberCount > 100000); //over 100k members as of 11/27/24
            Assert.ThrowsExceptionAsync<InvalidIdException>(() => Groups_v1.Get_GroupAsync(0)); //doesnt exist
        }

        [TestMethod]
        public void DetailedUser()
        {
            var x = Users_v1.Get_UserAsync(1).Result; //roblox
            var xx = Users_v1.Get_UserAsync(1).Result; 

            var y = Users_v1.Get_UserAsync(16).Result; //erik.cassel

            
            //error checking
            Assert.ThrowsExceptionAsync<InvalidIdException>(() => Users_v1.Get_UserAsync(0)); //doesnt exist
            Assert.ThrowsExceptionAsync<InvalidIdException>(() => Users_v1.Get_UserAsync(5)); //terminated user

            
            // value checking
            Assert.AreEqual(x.id,(ulong) 1);
            Assert.AreEqual(x, xx);
            Assert.AreNotEqual(x, y);
        }

        [TestMethod]
        public void Usernames()
        {
            
            User[] user_list = Users_v1.Get_UsernamesAsync([1,16,156]).Result;//roblox, erik.cassel, builderman
            
            Assert.ThrowsExceptionAsync<InvalidIdException>(() => Users_v1.Get_UsernamesAsync([0])); //doesnt exist
            Assert.ThrowsExceptionAsync<InvalidIdException>(() => Users_v1.Get_UsernamesAsync([])); //empty

            foreach (User u in user_list)
                Assert.AreEqual(u.name, Users_v1.Get_UserAsync(u.id).Result.name);
        }

        [TestMethod]
        public void Users()
        {
            User[] user_list = Users_v1.Get_UsersAsync(["roblox","erik.cassel","builderman"]).Result;

            Assert.ThrowsExceptionAsync<InvalidUsernameException>(() => Users_v1.Get_UsersAsync([]));

            foreach (User u in user_list) 
                Assert.AreEqual(u.Equals(Users_v1.Get_UserAsync(u.id).Result), true);
        }

        [TestMethod]
        public void UserSearch()
        {
            Page<User> page =  Users_v1.Get_UserSearchAsync("robl",Limit.MAX).Result;

            Assert.IsTrue(page.data.Length != 0);

            Assert.IsNull(page.previousPageCursor);

            Assert.IsNotNull(page.nextPageCursor);
        }

        [TestMethod]
        public void Followers()
        {
            Page<User> x = Friends_v1.Get_FollowersAsync(1).Result; //roblox

            //old page
            ulong some_id = x.data[0].id;

            Assert.IsNotNull(some_id);


            Assert.IsNull(x.previousPageCursor);

            //error checking
            Assert.ThrowsExceptionAsync<InvalidIdException>(() => Friends_v1.Get_FollowersAsync(0)); //doesnt exist
            Assert.ThrowsExceptionAsync<InvalidIdException>(() => Friends_v1.Get_FollowersAsync(5)); //terminated user
            
            //new page
            x = Friends_v1.Get_FollowersAsync(1,page: x).Result; //roblox


            Assert.IsNotNull(x.previousPageCursor);

            Assert.AreNotEqual(x.data[0].id, some_id);

        }

        [TestMethod]
        public void Followings()
        {
            Page<User> x = Friends_v1.Get_FollowingsAsync(1).Result; //roblox
            Page<User> y = Friends_v1.Get_FollowingsAsync(16,Limit.Ten).Result; //erik.cassel

            Assert.IsTrue(x.data.Length == 0);
            Assert.IsTrue(y.data.Length != 0);

            //error checking
            Assert.ThrowsExceptionAsync<InvalidIdException>(() => Friends_v1.Get_FollowingsAsync(0)); //doesnt exist
            Assert.ThrowsExceptionAsync<InvalidIdException>(() => Friends_v1.Get_FollowingsAsync(5)); //terminated user
        }

        [TestMethod]
        public void Friends()
        {

            User[] erik_friends = Friends_v1.Get_FriendsAsync(16).Result; //erik
            User[] roblox_friends = Friends_v1.Get_FriendsAsync(1).Result; //roblox

            Assert.AreNotEqual(erik_friends.Length, 0);
            Assert.AreEqual(roblox_friends.Length, 0);
        }
      
        [TestMethod]
        public void BadgeAwardedDates()
        {
            Assert.ThrowsExceptionAsync<ArgumentException>(() => Badges_v1.Get_BadgesAwardedDatesAsync(0, [])); //doesnt exist

            ulong[] badges = [2126601323, 2126601209, 94278219];
            Badge.Award[] eriks_badges = Badges_v1.Get_BadgesAwardedDatesAsync(16,badges).Result; //eik.cassel

            Assert.AreEqual(1, eriks_badges.Length); //erik has only 1 of these
        }

        [TestMethod]
        public void User_Presence()
        {
           
            User_Presence[] y = Presence_v1.Get_PresencesAsync([1,16,156]).Result;

            Array.Sort(y); //youngest to oldest

            Assert.ThrowsExceptionAsync<InvalidIdException>(() => Presence_v1.Get_PresencesAsync([]));  
            Assert.ThrowsExceptionAsync<InvalidIdException>(() => Presence_v1.Get_PresencesAsync([0]));

            Assert.AreEqual(y[2].userId, (ulong) 1);
            Assert.AreEqual(y[1].userId, (ulong) 16);
            Assert.AreEqual(y[0].userId, (ulong) 156);
        }

        [TestMethod]
        public void Username_History()
        {

            //7733466 is an admin
            Page<User> x = Users_v1.Get_UsernameHistoryAsync(1).Result;
            Page<User> y = Users_v1.Get_UsernameHistoryAsync(7733466).Result;

            Assert.ThrowsExceptionAsync<InvalidIdException>(() => Users_v1.Get_UsernameHistoryAsync(0)); //doesnt exist
            Assert.ThrowsExceptionAsync<InvalidIdException>(() => Users_v1.Get_UsernameHistoryAsync(5)); //terminated user
            
            Assert.AreEqual(x.data.Length,0);
            Assert.AreNotEqual(y.data.Length, 0);
            Assert.IsTrue(x.previousPageCursor == null);
        }
    }
}