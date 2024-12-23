using System.Text.Json;
using Roblox_Sharp.JSON_Models;

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
            Assert.AreEqual<ulong>(0, user.id);
            Assert.AreEqual("string", user.name);
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
            Assert.AreEqual<ulong>(0, user.id);
            Assert.AreEqual("string", user.name);
            Assert.AreEqual("string", user.displayName);

        }
    }
}
