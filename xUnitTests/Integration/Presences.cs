﻿using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Models;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace xUnitTests.Integration
{
    /// <summary>
    /// Tests <see cref="Presence_v1"/> endpoint
    /// </summary>
    [Collection(nameof(Integration))]
    public class Presences
    {
        [IntegrationTrait]
        [Fact]
        public async Task Get_Presences()
        {
            await Assert.ThrowsAsync<InvalidIdException>(() => Presence_v1.Get_PresencesAsync([0]));

            IReadOnlyList<User_Presence> presences = await Presence_v1.Get_PresencesAsync([156, 16, 1]); //youngest to newest 

            presences = [.. presences.OrderByDescending(user => user.userId)];

            //await Assert.ThrowsAsync<InvalidUserException>(() => Presence_v1.Get_PresencesAsync([])); doesnt throw anything

            Assert.True(
                presences[2].userId == 1 &&
                presences[1].userId == 16 &&
                presences[0].userId == 156,
                "User_Presence.userId is failing"
            );
        }
    }
}
