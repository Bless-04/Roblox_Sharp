using System.Text.Json;
using Roblox_Sharp.Enums;
using Roblox_Sharp.JSON_Models;
using Roblox_Sharp.JSON_Models.Users;

namespace Roblox_SharpTests.Deserialization
{
    /// <summary>
    /// Tests Serialization for <paramref name="User"/>
    /// </summary>
    [TestCategory("Deserialization Tests")]
    [TestClass]
    public class User_Object
    {
        [TestMethod]
        public void Get_User()
        {
            const string json_response = @"
            {
                ""description"": ""string"",
                ""created"": ""2024-12-23T05:47:33.196Z"",
                ""isBanned"": true,
                ""externalAppDisplayName"": ""string"",
                ""hasVerifiedBadge"": true,
                ""id"": 0,
                ""name"": ""string"",
                ""displayName"": ""string""
            }";


            User user = JsonSerializer.Deserialize<User>(json_response)
                ?? throw new AssertFailedException("User object should not be null here");

            Assert.AreEqual("string", user.description);
            Assert.AreEqual(2024, user.created.Year);
            Assert.AreEqual(true, user.isBanned);
            Assert.AreEqual("string", user.externalAppDisplayName);
            Assert.AreEqual(true, user.hasVerifiedBadge);
            Assert.AreEqual<ulong>(0, user.userId);
            Assert.AreEqual("string", user.username);
            Assert.AreEqual("string", user.displayName);
        }

        [TestMethod]
        public void Get_UsernameHistory()
        {
            const string json_response = @"
            {
              ""previousPageCursor"": ""string"",
              ""nextPageCursor"": ""string"",
              ""data"": [
                {
                  ""previousUsernames"": [
                    ""string""
                  ],
                  ""hasVerifiedBadge"": true,
                  ""id"": 0,
                  ""name"": ""string"",
                  ""displayName"": ""string""
                }
              ]
            }";

            Page<User> page = JsonSerializer.Deserialize<Page<User>>(json_response)
                ?? throw new AssertFailedException("Page object should not be null here"); 
            
            Assert.AreEqual("string", page.previousPageCursor);
            Assert.AreEqual("string", page.nextPageCursor);

            User user = page.data[0];


            Assert.IsNotNull(user.previousUsernames);
            Assert.AreEqual(1,user.previousUsernames.Count);

            Assert.AreEqual(true, user.hasVerifiedBadge);
            Assert.AreEqual<ulong>(0, user.userId);
            Assert.AreEqual("string", user.username);
            Assert.AreEqual("string", user.displayName);

        }

        /// <summary>
        /// Tests Serialization for ambiguity between userid and id
        /// </summary>
        /// <exception cref="AssertFailedException"></exception>
        [TestMethod]
        public void Id_Ambiguity()
        {
            const string json_response = @"
            {
                ""userId"": 0
            }";

            User user = JsonSerializer.Deserialize<User>(json_response)
                ?? throw new AssertFailedException("User should not be null here");

            Assert.AreEqual<ulong>(0, user.userId);
            
            User_Presence presence  = JsonSerializer.Deserialize<User_Presence>(json_response)
                ?? throw new AssertFailedException("User_Presence should not be null here");
        }

        public void Get_UserPresence()
        {
            const string json_response = @"
            {
              ""userPresenceType"": 0,
              ""lastLocation"": ""string"",
              ""placeId"": 0,
              ""rootPlaceId"": 0,
              ""gameId"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
              ""universeId"": 0,
              ""userId"": 0,
              ""lastOnline"": ""2024-12-23T16:36:03.740Z"",
              ""invisibleModeExpiry"": ""2024-12-23T16:36:03.740Z""
            }";

            User_Presence userPresence = JsonSerializer.Deserialize<User_Presence>(json_response)
                ?? throw new AssertFailedException("User_Presence should not be null here");

            Assert.AreEqual<Presence_Type>(0, userPresence.presenceType);
            Assert.AreEqual("string", userPresence.lastLocation);
            Assert.AreEqual<ulong?>(0, userPresence.placeId);
            Assert.AreEqual<ulong?>(0, userPresence.rootPlaceId);
            Assert.AreEqual("3fa85f64-5717-4562-b3fc-2c963f66afa6", userPresence.gameId);
            Assert.AreEqual<ulong?>(0, userPresence.universeId);
            Assert.AreEqual<ulong?>(0, userPresence.userId);
            Assert.AreEqual(2024, userPresence.lastOnline.Year);
            Assert.AreEqual(2024, userPresence.invisibleModeExpiry.Year);
        }
        
    }
}
