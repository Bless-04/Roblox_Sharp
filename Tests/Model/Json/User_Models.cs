using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Models;
using Roblox_Sharp.Models.v1;
using System.Text.Json;

using static Tests.TestHelper;
namespace Tests.Model.Json
{
    /// <summary>
    /// Tests Serialization for <see cref="Roblox_Sharp.Abstractions.User"/> based Models
    /// </summary>
    [Trait(nameof(Roblox_Sharp.Models), nameof(Json))]
    public class User_Models
    {
        /// <summary>
        /// Tests Serialization for <see cref="Roblox_Sharp.Models.v1.UserInfo"/>
        /// </summary>
        [Fact]
        public void UserInfo()
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

            UserInfo? user = JsonSerializer.Deserialize<UserInfo>(json_response);

            Assert.NotNull(user);

            Assert.True(user.Description.Length > 50, isFailing(nameof(user.Description)));
            Assert.Equal(2006, user.Created.Year);
            Assert.False(user.IsBanned, isFailing(nameof(user.IsBanned)));
            Assert.True(user.HasVerifiedBadge, isFailing(nameof(user.HasVerifiedBadge)));
            Assert.Equal<ulong>(1, user.UserId);
            Assert.Equal("Roblox", user.Username);
            Assert.Equal(user.Username, user.DisplayName);

            Assert.True(RoundTrip(user));
        }

        [Fact]
        public void UserByUserId()
        {
            const string json = "{\r\n  \"data\": [\r\n    {\r\n      \"hasVerifiedBadge\": true,\r\n      \"id\": 1,\r\n      \"name\": \"Roblox\",\r\n      \"displayName\": \"Roblox\"\r\n    },\r\n    {\r\n      \"hasVerifiedBadge\": true,\r\n      \"id\": 156,\r\n      \"name\": \"builderman\",\r\n      \"displayName\": \"builderman\"\r\n    },\r\n    {\r\n      \"hasVerifiedBadge\": false,\r\n      \"id\": 256,\r\n      \"name\": \"UN109175575\",\r\n      \"displayName\": \"UN109175575\"\r\n    }\r\n  ]\r\n}";

            var page = JsonSerializer.Deserialize<Page<UserByUserId>>(json);

            Assert.NotNull(page);

            Assert.True(page.Count != 0, isFailing(nameof(page.Count)));

            var user1 = page.Data[0];

            Assert.NotNull(page);
            foreach (var user in page.Data)
            {
                Assert.NotNull(user);
                Assert.True(user.UserId > 0, isFailing(nameof(user.UserId)));
                Assert.True(user.Username.Length > 0, isFailing(nameof(user.Username)));
                Assert.True(user.DisplayName.Length > 0, isFailing(nameof(user.DisplayName)));
            }

            Assert.True(RoundTrip(user1));

        }

        [Fact]
        public void UserByUsername()
        {
            const string json = "{\r\n      \"requestedUsername\": \"string\",\r\n      \"hasVerifiedBadge\": true,\r\n      \"id\": 8,\r\n      \"name\": \"string\",\r\n      \"displayName\": \"string\"\r\n    }";

            var user = JsonSerializer.Deserialize<UserByUsername>(json);

            Assert.NotNull(user);
            Assert.True(user.HasVerifiedBadge, isFailing(nameof(user.HasVerifiedBadge)));
            Assert.True(user.UserId == 8, isFailing(nameof(user.UserId)));
            Assert.True(user.Username.Length > 0, isFailing(nameof(user.Username)));
            Assert.True(user.DisplayName.Length > 0, isFailing(nameof(user.DisplayName)));

            Assert.True(RoundTrip(user));

        }

        [Fact]
        public void UserAuthenticated()
        {
            const string json = "  {\r\n  \"id\": 1,\r\n  \"name\": \"string\",\r\n  \"displayName\": \"string\"\r\n}";

            var user = JsonSerializer.Deserialize<UserAuthenticated>(json);

            Assert.NotNull(user);
            Assert.True(user.UserId == 1, isFailing(nameof(user.UserId)));
            Assert.True(user.Username.Length > 0, isFailing(nameof(user.Username)));
            Assert.True(user.DisplayName.Length > 0, isFailing(nameof(user.DisplayName)));

            Assert.Equal(user.Username, user.DisplayName);
            Assert.True(RoundTrip(user));

        }

        [Fact]
        public void UserBySearch()
        {
            Limit x = Limit.TwentyFive;

            var b = (byte)x;


            b = 9;
        }
    }
}
