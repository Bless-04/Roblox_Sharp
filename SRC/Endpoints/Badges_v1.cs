using System;
using System.Threading.Tasks;
using System.Text.Json;

using Roblox_Sharp.JSON.Badges;
using Roblox_Sharp.JSON;
using static Roblox_Sharp.WebAPI;

namespace Roblox_Sharp.Endpoints
{
    /// <summary>
    ///Endpoints for badges and badge awards management <br></br>
    /// <b><see href="https://badges.roblox.com//docs/index.html?urls.primaryName=Badges%20Api%20v1">Badges Documentation</see></b>
    /// </summary>
    public static class Badges_v1
    {
        /// <summary>
        /// Asynchronously Gets timestamps for when badges were awarded to the given <typeparamref name="userId"/>
        /// <br></br>
        /// <see href="https://badges.roblox.com//docs/index.html?urls.primaryName=Badges%20Api%20v1">Badges Api v1 Documentation</see>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="badgeIds"></param>
        /// <returns>Badge_Award[]</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidUserIdException"></exception>
        public static async Task<Badge_Award[]> Get_BadgesAwardedDatesAsync(ulong userId, ulong[] badgeIds)
        {
            if (badgeIds.Length == 0) throw new ArgumentException("atleast one badge id is required");
            //URL example https://badges.roblox.com/v1/users/63225213/badges/awarded-dates?badgeIds=2126601323,2126601209,94278219,-1
            return 
                JsonSerializer.Deserialize<Page<Badge_Award>>(
                    await Get_RequestAsync(
                        $"https://badges.roblox.com/v1/users/{userId}" +
                        $"/badges/awarded-dates?badgeIds={string.Join(',', badgeIds)}")
                )!.data;
        }
        /// <summary>
        /// Get detailed badge information by the given <paramref name="badgeId"/>
        /// </summary>
        /// <param name="badgeId"></param>
        /// <returns>Badge</returns>
        public static async Task<Badge> Get_BadgeAsync(ulong badgeId) =>
            //url 'https://badges.roblox.com/v1/badges/2839010492385863
            JsonSerializer.Deserialize<Badge>(
                await Get_RequestAsync($"https://badges.roblox.com/v1/badges/{badgeId}")
            )!;
    }
}
