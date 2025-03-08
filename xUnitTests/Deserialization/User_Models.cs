using Roblox_Sharp.Enums;
using Roblox_Sharp.Models;
using System.Text.Json;
using static xUnitTests.Deserialization.Miscellaneous;

namespace xUnitTests.Deserialization
{
    /// <summary>
    /// Tests Serialization for <paramref name="User"/>
    /// </summary>
    [Trait(nameof(Roblox_Sharp.Models), nameof(Deserialization))]
    public class User_Models
    {
        [Fact]
        public void Get_User()
        {
            const string json_response = @"
            {
                ""description"": ""string"",
                ""created"": ""2024-12-23T05:47:33.196Z"",
                ""isBanned"": true,
                ""isDeleted"": true,
                ""externalAppDisplayName"": ""string"",
                ""hasVerifiedBadge"": true,
                ""id"": 0,
                ""name"": ""string"",
                ""displayName"": ""string""
            }";

            User? user = JsonSerializer.Deserialize<User>(json_response);

            Assert.NotNull(user);

            Assert.Equal("string", user.description);
            Assert.Equal(2024, user.Created.Year);
            Assert.True(user.isBanned && user.IsDeleted);
            Assert.Equal("string", user.externalAppDisplayName);
            Assert.True(user.hasVerifiedBadge);
            Assert.Equal<ulong>(0, user.UserId);
            Assert.Equal("string", user.Username);
            Assert.Null(user.DisplayName);


            RoundTripTest(user);
        }

        [Fact]
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
                  ""displayName"": ""displayName""
                }
              ]
            }";

            Page<User>? page = JsonSerializer.Deserialize<Page<User>>(json_response);
            Assert.NotNull(page);

            Assert.Equal("string", page.PreviousPageCursor);
            Assert.Equal("string", page.NextPageCursor);

            User user = page.Data[0];

            Assert.NotNull(user.previousUsernames);
            Assert.Single(user.previousUsernames);

            Assert.True(user.hasVerifiedBadge);
            Assert.Equal<ulong>(0, user.UserId);
            Assert.Equal("string", user.Username);
            Assert.Equal("displayName", user.DisplayName);

            Assert.Equal(page.Data.Count, RoundTrip(page).Data.Count);
        }

        /// <summary>
        /// Tests Serialization for ambiguity between userid and id
        /// </summary>
        /// <exception cref="AssertFailedException"></exception>
        [Fact]
        public void Id_Ambiguity()
        {
            const string json_response = @"
            {
                ""userId"": 0
            }";

            User? user = JsonSerializer.Deserialize<User>(json_response);
            Assert.NotNull(user);

            User.Presence? presence = JsonSerializer.Deserialize<User.Presence>(json_response);
            Assert.NotNull(presence);


            Assert.True(
                presence.UserId == user.UserId,
                "The id in the User.Presence object should be the same as the id in the User object");

            RoundTripTest(user);
        }

        [Fact]
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

            User.Presence? userPresence = JsonSerializer.Deserialize<User.Presence>(json_response);


            Assert.NotNull(userPresence);

            Assert.Equal<UserPresenceType>(0, userPresence.PresenceType);
            Assert.Equal("string", userPresence.LastLocation);
            Assert.Equal<ulong?>(0, userPresence.PlaceId);
            Assert.Equal<ulong?>(0, userPresence.RootPlaceId);
            Assert.Equal("3fa85f64-5717-4562-b3fc-2c963f66afa6", userPresence.GameId);
            Assert.Equal<ulong?>(0, userPresence.UniverseId);
            Assert.Equal<ulong?>(0, userPresence.UserId);
            Assert.Equal(2024, userPresence.LastOnline.Year);
            Assert.Equal(2024, userPresence.InvisibleModeExpiry.Year);

            RoundTripTest(userPresence);
        }

    }
}
