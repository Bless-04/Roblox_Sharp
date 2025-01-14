using Roblox_Sharp.Enums;
using Roblox_Sharp.Models;
using System.Text.Json;

namespace xUnitTests.Deserialization
{
    /// <summary>
    /// Tests Serialization for <paramref name="User"/>
    /// </summary>
    [Trait(nameof(xUnitTests), nameof(Deserialization))]
    public class User_Object
    {
        [Fact]
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


            User? user = JsonSerializer.Deserialize<User>(json_response);


            Assert.NotNull(user);

            Assert.Equal("string", user.description);
            Assert.Equal(2024, user.created.Year);
            Assert.True(user.isBanned);
            Assert.Equal("string", user.externalAppDisplayName);
            Assert.True(user.hasVerifiedBadge);
            Assert.Equal<ulong>(0, user.userId);
            Assert.Equal("string", user.username);
            Assert.Null(user.displayName);
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

            Assert.Equal("string", page.previousPageCursor);
            Assert.Equal("string", page.nextPageCursor);

            User user = page.data[0];

            Assert.NotNull(user.previousUsernames);
            Assert.True(1 == user.previousUsernames.Count);

            Assert.True(user.hasVerifiedBadge);
            Assert.Equal<ulong>(0, user.userId);
            Assert.Equal("string", user.username);
            Assert.Equal("displayName", user.displayName);

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

            User_Presence? presence = JsonSerializer.Deserialize<User_Presence>(json_response);
            Assert.NotNull(presence);


            Assert.True(
                presence.userId == user.userId,
                "The id in the User_Presence object should be the same as the id in the User object");

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

            User_Presence? userPresence = JsonSerializer.Deserialize<User_Presence>(json_response);


            Assert.NotNull(userPresence);

            Assert.Equal<Presence_Type>(0, userPresence.presenceType);
            Assert.Equal("string", userPresence.lastLocation);
            Assert.Equal<ulong?>(0, userPresence.placeId);
            Assert.Equal<ulong?>(0, userPresence.rootPlaceId);
            Assert.Equal("3fa85f64-5717-4562-b3fc-2c963f66afa6", userPresence.gameId);
            Assert.Equal<ulong?>(0, userPresence.universeId);
            Assert.Equal<ulong?>(0, userPresence.userId);
            Assert.Equal(2024, userPresence.lastOnline.Year);
            Assert.Equal(2024, userPresence.invisibleModeExpiry.Year);
        }

    }
}
