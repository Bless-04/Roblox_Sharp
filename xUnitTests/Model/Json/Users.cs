using Roblox_Sharp.Models.v1;
using System.Text.Json;

using static xUnitTests.TestHelper;
namespace xUnitTests.Model.Json
{
    /// <summary>
    /// Tests Serialization for <see cref="Roblox_Sharp.Models.v1.User"/>
    /// </summary>
    [Trait(nameof(Roblox_Sharp.Models), nameof(Json))]
    public class Users
    {
        /// <summary>
        /// Tests Serialization for <see cref="Roblox_Sharp.Models.v1.User"/>
        /// </summary>
        [Fact]
        public void User_Json()
        {
            const string json_response = @"
            {
              ""description"": ""Welcome to the Roblox profile! This is where you can check out the newest items in the catalog, and get a jumpstart on exploring and building on our Imagination Platform. If you want news on updates to the Roblox platform, or great new experiences to play with friends, check out blog.roblox.com. Please note, this is an automated account. If you need to reach Roblox for any customer service needs find help at www.roblox.com/help"",
              ""created"": ""2006-02-27T21:06:40.3Z"",
              ""isBanned"": false,
              ""externalAppDisplayName"": ""string"",
              ""hasVerifiedBadge"": true,
              ""id"": 1,
              ""name"": ""Roblox"",
              ""displayName"": ""Roblox""
            }";
            

            User? user = JsonSerializer.Deserialize<User>(json_response);

            Assert.NotNull(user);

            Assert.True(user.Description.Length > 50,isFailing(nameof(user.Description)));
            Assert.Equal(2006, user.Created.Year);
            Assert.False(user.IsBanned,isFailing(nameof(user.IsBanned)));
            Assert.True(user.HasVerifiedBadge,isFailing(nameof(user.HasVerifiedBadge)));
            Assert.Equal<ulong>(1, user.UserId);
            Assert.Equal("Roblox", user.Username);
            Assert.Equal(user.Username,user.DisplayName);

            Assert.True(RoundTrip(user));
        }

    }
}
