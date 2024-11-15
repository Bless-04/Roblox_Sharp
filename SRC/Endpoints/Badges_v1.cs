using Newtonsoft.Json;
using Roblox_Sharp.JSON;
using System.Threading.Tasks;
using System;
using static Roblox_Sharp.WebAPI;

namespace Roblox_Sharp.Endpoints
{
    public static class Badges_v1
    {
        /// <summary>
        /// Asynchronously Gets timestamps for when badges were awarded to the given <typeparamref name="userId"/>
        /// <br></br>
        /// <see href="https://badges.roblox.com//docs/index.html?urls.primaryName=Badges%20Api%20v1">Badges Api v1 Documentation</see>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="badgeIds"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidUserIdException"></exception>
        public static async Task<BadgeAward[]> Get_BadgesAwardedDatesAsync(ulong userId, ulong[] badgeIds)
        {
            if (badgeIds.Length == 0) throw new ArgumentException("atleast one badge id is required");


            //URL example https://badges.roblox.com/v1/users/63225213/badges/awarded-dates?badgeIds=2126601323,2126601209,94278219,-1

            string content = await Get_RequestAsync(
                $"https://badges.roblox.com/v1/users/{userId}/badges/awarded-dates?badgeIds={string.Join(',', badgeIds)}"
            );
            return JsonConvert.DeserializeObject<Page<BadgeAward>>(content)!.data;
        }

    }
}
