using static Roblox_Sharp.WebData;
using Roblox_Sharp.Enums.Thumbnail;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.JSON;
using System.Diagnostics;
using Roblox_Sharp;
namespace Roblox_SharpTests
{

    
    [TestClass]
    public class WebData_Test
    {
       
        
        public WebData_Test()
        {
            WebData.OnSuccessfulRequest += OnSuccessfulRequest;
            WebData.OnFailedRequest += OnFailedRequest;
        }
        //test event successfulrequest event

        public void OnSuccessfulRequest(object? sender, EventArgs e) => Debug.WriteLine("SUCCESS " + (sender as HttpResponseMessage)?.RequestMessage);
        public void OnFailedRequest(object? sender, EventArgs e) => Debug.WriteLine("FAILED "  + (sender as HttpResponseMessage)?.RequestMessage );


        [TestMethod]
        public void DetailedUser()
        {
            var x = Get_UserAsync(1).Result; //roblox
            var xx = Get_UserAsync(1).Result; 

            var y = Get_UserAsync(16).Result; //erik.cassel

            
            //error checking
            Assert.ThrowsExceptionAsync<InvalidUserIdException>(() => Get_UserAsync(0)); //doesnt exist
            Assert.ThrowsExceptionAsync<InvalidUserIdException>(() => Get_UserAsync(5)); //terminated user

            
            // value checking
            Assert.AreEqual(x.id,(ulong) 1);
            Assert.AreEqual(x, xx);
            Assert.AreNotEqual(x, y);
        }

        [TestMethod]
        public void Usernames()
        {

            User[] user_list = Get_UsernamesAsync([1,16,156]).Result;//roblox, erik.cassel, builderman
            
            Assert.ThrowsExceptionAsync<InvalidUserIdException>(() => Get_UsernamesAsync([0])); //doesnt exist
            Assert.ThrowsExceptionAsync<InvalidUserIdException>(() => Get_UsernamesAsync([])); //empty

            foreach (User u in user_list)
                Assert.AreEqual(u.name, Get_UserAsync(u.id).Result.name);
        }

        [TestMethod]
        public void Users()
        {
            User[] user_list = Get_UsersAsync(["roblox","erik.cassel","builderman"]).Result;

            Assert.ThrowsExceptionAsync<InvalidUsernameException>(() => Get_UsersAsync([]));

            foreach (User u in user_list) 
                Assert.AreEqual(u.Equals(Get_UserAsync(u.id).Result), true);
        }

        [TestMethod]
        public void Followers()
        {
            Page<User> x = Get_FollowersAsync(1).Result; //roblox

            //old page
            ulong some_id = x.data[0].id;

            Assert.IsNotNull(some_id);


            Assert.IsNull(x.previousPageCursor);

            //error checking
            Assert.ThrowsExceptionAsync<InvalidUserIdException>(() => Get_FollowersAsync(0)); //doesnt exist
            Assert.ThrowsExceptionAsync<InvalidUserIdException>(() => Get_FollowersAsync(5)); //terminated user
            Assert.ThrowsExceptionAsync<InvalidUserIdException>(() => Get_FollowersAsync(2, page: x)); //cursor doesnt exist for userid 2 therefore the userid is invalid

            //new page
            x = Get_FollowersAsync(1,page: x).Result; //roblox


            Assert.IsNotNull(x.previousPageCursor);

            Assert.AreNotEqual(x.data[0].id, some_id);

        }

        [TestMethod]
        public void Followings()
        {
            Page<User> x = Get_FollowingsAsync(1).Result; //roblox
            Page<User> y = Get_FollowingsAsync(16).Result; //erik.cassel

            Assert.IsTrue(x.data.Length == 0);
            Assert.IsTrue(y.data.Length != 0);

            

            //error checking
            Assert.ThrowsExceptionAsync<InvalidUserIdException>(() => Get_FollowingsAsync(0)); //doesnt exist
            Assert.ThrowsExceptionAsync<InvalidUserIdException>(() => Get_FollowingsAsync(5)); //terminated user
           
        }

        [TestMethod]
        public void Friends()
        {

            User[] erik_friends = Get_FriendsAsync(16).Result; //erik
            User[] roblox_friends = Get_FriendsAsync(1).Result; //roblox

            Assert.AreNotEqual(erik_friends.Length, 0);
            Assert.AreEqual(roblox_friends.Length, 0);
        }
      
        [TestMethod]
        public void BadgeAwardedDates()
        {
            Assert.ThrowsExceptionAsync<ArgumentException>(() => Get_BadgesAwardedDatesAsync(0, [])); //doesnt exist

            ulong[] badges = [2126601323, 2126601209, 94278219];
            BadgeAward[] eriks_badges = Get_BadgesAwardedDatesAsync(16,badges).Result; //eik.cassel


            Assert.AreEqual(1, eriks_badges.Length); //erik has only 1 of these

        }

        [TestMethod]
        public void Presence()
        {
            userPresence[] x =  Get_LastOnlinesAsync([1,16,156]).Result;
            userPresence[] y = Get_PresencesAsync([1,16,156]).Result;

            Assert.AreEqual(x[0].userId, y[0].userId);
        }

        [TestMethod]
        public void PreviousUsernames()
        {

        }

        [TestMethod]
        public void IUserOperatorTests()
        {

            // x > y > z
            User x = new(1); //roblox
            
            
            
            User y = new(16); //erik.cassel
            User z = new(156); //builderman
            User X = new(1); //roblox
            
            Assert.AreNotEqual(x, y);

            Assert.IsTrue(x > y);
            Assert.IsTrue(y > z); 
            Assert.IsTrue(x > z);

            Assert.IsTrue(z < x);
            Assert.IsTrue(z < x);
            Assert.IsTrue(y < x);

            Assert.IsFalse(x.Equals(y));
            Assert.IsTrue(x.Equals(X));
           
        }


        //These tests need extensive testing and take longer
        [TestClass]
        public class Avatars
        {
            [TestMethod]
            public void Headshots()
            {
                ulong[] id = [1];

                //error checking to loop through every possible Size and Format enum

                Size[] s_BLACKLIST = [Size.x30];
                bool isCircular = false;
                foreach (Size s in Enum.GetValues(typeof(Size)))
                {
                    if (s_BLACKLIST.Contains(s))
                    {
                        Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => Get_AvatarHeadshotsAsync(id, s, Format.Png, isCircular));
                        continue;
                    }
                    foreach (Format f in Enum.GetValues(typeof(Format)))
                    {
                        isCircular = !isCircular;
                        
                        Assert.IsNotNull(Get_AvatarHeadshotsAsync(id, s, f, isCircular).Result[0].imageUrl);
                    }
                }
            }

            [TestMethod]
            public void FullAvatar()
            {
                ulong[] id = [1];


                Size[] s_BLACKLIST = [Size.x50];
                //Format[] f_BLACKLIST = [Format.Jpeg];


                bool isCircular = false;
                foreach (Size s in Enum.GetValues(typeof(Size)))
                {
                    if (s_BLACKLIST.Contains(s))
                    {
                        Assert.ThrowsExceptionAsync<ArgumentException>(() => Get_AvatarsAsync(id, s, Format.Png, isCircular));
                        continue;
                    }
                    foreach (Format f in Enum.GetValues(typeof(Format)))
                    {
                        isCircular = !isCircular;

                        Assert.IsNotNull(Get_AvatarsAsync(id, s, f, isCircular).Result[0].imageUrl);
                    }
                }
            }

            [TestMethod]
            public void Busts()
            {
                ulong[] id = [1];


                Size[] s_BLACKLIST = [Size.x30,Size.x110,Size.x720];
                Format[] f_BLACKLIST = [Format.Jpeg];
                

                bool isCircular = false;
                foreach (Size s in Enum.GetValues(typeof(Size)))
                {
                    if (s_BLACKLIST.Contains(s))
                    {
                        Assert.ThrowsExceptionAsync<ArgumentException>(() => Get_AvatarBustsAsync(id, s, Format.Png, isCircular));
                        continue;
                    }
                    foreach (Format f in Enum.GetValues(typeof(Format)))
                    {
                        if (f_BLACKLIST.Contains(f))
                        {
                            Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => Get_AvatarBustsAsync(id, s, f, isCircular));
                            continue;
                        }
                        isCircular = !isCircular;

                        Assert.IsNotNull(Get_AvatarBustsAsync(id,s, f, isCircular).Result[0].imageUrl);
                    }
                }
            }

        }

        //After 60 secs these test must always succeed
        [TestClass]  
        public class Counts
        {
            [TestMethod]
            public void FriendsCount()
            {

                var x = Get_FriendsCountAsync(1).Result; //roblox
                var y = Get_FriendsCountAsync(16).Result; //erik.cassel
                var z = Get_FriendsCountAsync(156).Result; //builderman

                Assert.AreEqual(x, z);
                Assert.AreNotEqual(x, y);

                //error checking
                Assert.ThrowsExceptionAsync<InvalidUserIdException>(() => Get_FriendsCountAsync(0)); //doesnt exist
                Assert.ThrowsExceptionAsync<InvalidUserIdException>(() => Get_FriendsCountAsync(5)); //terminated user

            }

            [TestMethod]
            public void FollowersCount()
            {
                Assert.ThrowsExceptionAsync<InvalidUserIdException>(() => Get_FollowersCountAsync(0)); //doesnt exist
                Assert.ThrowsExceptionAsync<InvalidUserIdException>(() => Get_FollowersCountAsync(5)); //terminated user
                                                                                                       //roblox vs erik.cassel
                Assert.AreNotEqual(Get_FollowersCountAsync(1).Result, Get_FollowersCountAsync(16).Result);

            }

           
            [TestMethod]
            public void FollowingsCount()
            {

                var x = Get_FollowingsCountAsync(1).Result; //roblox
                var y = Get_FollowingsCountAsync(16).Result; //erik.cassel

                Assert.AreEqual(x, (ulong)0);

                Assert.AreNotEqual(x, y);
                Assert.AreNotEqual(y, (ulong)0);

                //error checking
                Assert.ThrowsExceptionAsync<InvalidUserIdException>(() => Get_FollowingsCountAsync(0)); //doesnt exist
                Assert.ThrowsExceptionAsync<InvalidUserIdException>(() => Get_FollowingsCountAsync(5)); //terminated user
            }

        }
    }
}