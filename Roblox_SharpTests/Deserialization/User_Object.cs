using System.Text.Json;
using Roblox_Sharp.JSON_Models;

namespace Roblox_SharpTests.Deserialization
{
    /// <summary>
    /// Tests Serialization for Users_v1 endpoint
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

    }
}
