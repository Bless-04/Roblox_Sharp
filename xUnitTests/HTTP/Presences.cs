using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Models.Users;

using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace xUnitTests.HTTP
{
    /// <summary>
    /// Tests <see cref="Presence_v1"/> endpoint
    /// </summary>
    [Collection("Endpoints")]
    [Trait("Tests", "Integration")]
    public class Presences
    {
        [Fact]
        public async Task Get_Presences()
        {
            IReadOnlyList<User_Presence> presences = await Presence_v1.Get_PresencesAsync([156, 16, 1]); //youngst to oldest sorting

            presences = presences
                .OrderBy(p => p)
                .ToList();

            //await Assert.ThrowsAsync<InvalidIdException>(() => Presence_v1.Get_PresencesAsync([])); doesnt throw anything
            await Assert.ThrowsAsync<InvalidIdException>(() => Presence_v1.Get_PresencesAsync([0]));

            Assert.True(
                presences[2].userId == 1 &&
                presences[1].userId == 16 &&
                presences[0].userId == 156,
                "User_Presence.userId is failing"
            );
        }
    }
}
