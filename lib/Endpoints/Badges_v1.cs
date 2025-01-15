using Roblox_Sharp.Enums;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Models;
using Roblox_Sharp.Models.Badges;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
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
        /// Asynchronously Gets timestamps for when badges were awarded to the given <paramref name="userId"/>
        /// <br></br>
        /// <see href="https://badges.roblox.com//docs/index.html?urls.primaryName=Badges%20Api%20v1">Badges Api v1 Documentation</see>
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="badgeIds"></param>
        /// <returns>List of Badge_Award</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidUserException"></exception>
        public static async Task<IReadOnlyList<Badge_Award>> Get_BadgesAwardedDatesAsync(ulong userId, List<ulong> badgeIds)
        {
            if (badgeIds.Count == 0) throw new InvalidUserException("atleast one badge id is required");
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

        /// <summary>
        /// Gets a list of badges a user has been awarded.
        /// </summary>
        /// <param name="userId">The user id </param>
        /// <param name="limit">The number of results per request</param>
        /// <param name="sortOrder">the order the results are stored in</param>
        /// <param name="page">used for the paging cursor</param>
        /// <returns>Page of Badges</returns>
        public static async Task<Page<Badge>> Get_BadgesAsync(ulong userId, Limit limit = Limit.Minimum, Sort sortOrder = Sort.Asc, Page<Badge>? page = null) =>
            //url example 'https://badges.roblox.com/v1/users/2/badges?limit=50&sortOrder=Asc' 
            JsonSerializer.Deserialize<Page<Badge>>(
                await Get_RequestAsync(
                    $"https://badges.roblox.com/v1/users/{userId}/badges?limit={EnumExtensions.ToString(limit)}" +
                    $"&sortOrder={sortOrder}" +
                    $"&cursor={page?.nextPageCursor}")
            )!;

    }
}
