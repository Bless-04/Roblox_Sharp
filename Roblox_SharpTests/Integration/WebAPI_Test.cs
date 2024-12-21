
using System.Diagnostics;

using Roblox_Sharp;

using Roblox_Sharp.Enums;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.JSON_Models.Badges;
using Roblox_Sharp.JSON_Models;

using Roblox_Sharp.Endpoints;
using Roblox_Sharp.JSON_Models.Users;

namespace Roblox_SharpTests.Integration;

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
    public void GroupsData()
    {
        IReadOnlyList<Group> groups = Groups_v2.Get_GroupsAsync([1,2,3]).Result;

        Assert.IsTrue(groups.Count == 3);

        Group group1 = groups[0];
        Group group2 = groups[1];
        Group group3 = groups[2];

        Assert.AreEqual((ulong) 1179762, group1.owner.id); //owner is 1179762
        Assert.AreEqual((ulong) 261, group2.owner.id); //owner is 261
        Assert.AreEqual((ulong) 24941, group3.owner.id);  //owner is 24941

        Assert.IsTrue(group1.created.Year == group2.created.Year && group3.created.Year == group2.created.Year); // all created in 2009
    }

    [TestMethod]
    public void GroupRoles()
    {
        IReadOnlyList<Group.Role> roles = Groups_v1.Get_GroupRolesAsync(9).Result;

        Assert.IsTrue(roles.Count > 1);

        Assert.IsTrue(roles[1].memberCount > 400000); //more than 400k as of 11/30

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

        IReadOnlyList<User> user_list = Users_v1.Get_UsernamesAsync([1,16,156]).Result;//roblox, erik.cassel, builderman
        
        Assert.ThrowsExceptionAsync<InvalidIdException>(() => Users_v1.Get_UsernamesAsync([0])); //doesnt exist
        Assert.ThrowsExceptionAsync<InvalidIdException>(() => Users_v1.Get_UsernamesAsync([])); //empty

        foreach (User u in user_list)
            Assert.AreEqual(u.name, Users_v1.Get_UserAsync(u.id).Result.name);
    }

    [TestMethod]
    public void Users()
    {
        IReadOnlyList<User> user_list = Users_v1.Get_UsersAsync(["roblox","erik.cassel","builderman"]).Result;

        Assert.ThrowsExceptionAsync<InvalidUsernameException>(() => Users_v1.Get_UsersAsync([]));

        foreach (User u in user_list) 
            Assert.AreEqual(u.Equals(Users_v1.Get_UserAsync(u.id).Result), true);
    }

    [TestMethod]
    public void UserSearch()
    {
        Page<User> page =  Users_v1.Get_UserSearchAsync("robl",Limit.MAX).Result;

        Assert.IsTrue(page.data.Count != 0);

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
    public void Users_Badges()
    {
        Page<Badge> page = Badges_v1.Get_BadgesAsync(16,Limit.Ten).Result; //erik.cassel

        Badge erik_badge1 = page.data[0];

        Assert.IsNotNull(page.nextPageCursor);
        Assert.IsNull(page.previousPageCursor);

        Assert.ThrowsExceptionAsync<InvalidIdException>(() => Badges_v1.Get_BadgesAsync(0)); //doesnt exist

        Assert.IsNotNull(erik_badge1.creator);
        Assert.IsNotNull(erik_badge1.awarder);
        Assert.IsNotNull(erik_badge1.statistics);

        Assert.AreEqual((ulong)2925703, erik_badge1.creator.id);
        Assert.AreEqual(2009, erik_badge1.created.Year);
        Assert.AreEqual((ulong)10277240,erik_badge1.awarder.id); //game id 

        Assert.IsTrue(erik_badge1.statistics.awardedCount > 1000000); ///over 1000000 as of 11/29/24
    }
    [TestMethod]
    public void Badge()
    {
        Badge badge = Badges_v1.Get_BadgeAsync(14417332).Result; //john loved of muses 

        Assert.IsNotNull(badge);

        Assert.ThrowsExceptionAsync<InvalidIdException>(() => Badges_v1.Get_BadgeAsync(0)); //doesnt exist
        
        Assert.AreEqual((ulong) 14417332, badge.id);

        Assert.IsTrue(badge.created.Year == 2009);
    }

    [TestMethod]
    public void BadgeAwardedDates()
    {
        Assert.ThrowsExceptionAsync<ArgumentException>(() => Badges_v1.Get_BadgesAwardedDatesAsync(0, [])); //doesnt exist

        ulong[] badges = [2126601323, 2126601209, 94278219];
        IReadOnlyList<Badge_Award> eriks_badges = Badges_v1.Get_BadgesAwardedDatesAsync(16,badges).Result; //eik.cassel

        Assert.AreEqual(1, eriks_badges.Count); //erik has only 1 of these
    }

    [TestMethod]
    public void User_Presence()
    {

        IReadOnlyList<User_Presence> presences = Presence_v1.Get_PresencesAsync([156, 16, 1]) //youngst to oldest sorting
            .Result
            .OrderBy(p => p)
            .ToList();

        Assert.ThrowsExceptionAsync<InvalidIdException>(() => Presence_v1.Get_PresencesAsync([]));  
        Assert.ThrowsExceptionAsync<InvalidIdException>(() => Presence_v1.Get_PresencesAsync([0]));

        Assert.AreEqual(presences[2].userId, (ulong) 1);
        Assert.AreEqual(presences[1].userId, (ulong) 16);
        Assert.AreEqual(presences[0].userId, (ulong) 156);
    }

    [TestMethod]
    public void Username_History()
    {

        //7733466 is an admin
        Page<User> x = Users_v1.Get_UsernameHistoryAsync(1).Result;
        Page<User> y = Users_v1.Get_UsernameHistoryAsync(7733466).Result;

        Assert.ThrowsExceptionAsync<InvalidIdException>(() => Users_v1.Get_UsernameHistoryAsync(0)); //doesnt exist
        Assert.ThrowsExceptionAsync<InvalidIdException>(() => Users_v1.Get_UsernameHistoryAsync(5)); //terminated user
        
        Assert.AreEqual(x.data.Count,0);
        Assert.AreNotEqual(y.data.Count, 0);
        Assert.IsTrue(x.previousPageCursor == null);
    }
}