﻿using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Enums;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace xUnitTests.Integration
{
    /// <summary>
    /// Tests <see cref="Badges_v1"/> Endpoint
    /// </summary>
    [Collection(nameof(Integration))]
    public class Badges
    {
        [IntegrationTrait]
        [Fact]
        public async Task Get_Badges()
        {
            Page<Badge> page = await Badges_v1.Get_BadgesAsync(16, Limit.Ten); //erik.cassel

            Badge erik_badge1 = page.Data[0];

            Assert.NotNull(page.NextPageCursor);

            await Assert.ThrowsAsync<InvalidIdException>(() => Badges_v1.Get_BadgesAsync(0)); //doesnt exist

            Assert.NotNull(erik_badge1.creator);
            Assert.NotNull(erik_badge1.awardingUniverse);

            Assert.True(2925703 == erik_badge1.creator.UserId, nameof(erik_badge1.creator.UserId) + " is failing");
            Assert.True(2009 == erik_badge1.Created.Year, nameof(erik_badge1.Created.Year) + " is failing");
            Assert.True(10277240 == erik_badge1.awardingUniverse.UniverseId, nameof(erik_badge1.awardingUniverse.UniverseId) + " is failing"); //game id

            Assert.True(erik_badge1.Statistics.AwardedCount > 1000000, $"{nameof(erik_badge1.Statistics.AwardedCount)}Badge.Statistics.AwardedCount is failing"); ///over 1000000 as of 11/29/24
        }

        [IntegrationTrait]
        [Fact]
        public async Task Get_Badge()
        {
            Badge badge = await Badges_v1.Get_BadgeAsync(14417332); //john loved of muses 

            Assert.NotNull(badge);

            await Assert.ThrowsAsync<InvalidIdException>(() => Badges_v1.Get_BadgeAsync(0)); //doesnt exist

            Assert.True(14417332 == badge.BadgeId, nameof(badge.BadgeId) + " is failing");

            Assert.True(badge.Created.Year == 2009, nameof(badge.Created.Year) + " is failing");
        }

        [IntegrationTrait.Long_Integration]
        [Fact]
        public async Task BadgeAwardedDates()
        {
            await Assert.ThrowsAsync<InvalidUserException>(() => Badges_v1.Get_BadgesAwardedDatesAsync(0, [])); //doesnt exist

            List<ulong> badges = [2126601323, 2126601209, 94278219];
            IReadOnlyList<Badge.Award> eriks_badges = await Badges_v1.Get_BadgesAwardedDatesAsync(16, badges); //eik.cassel

            Assert.True(1 == eriks_badges.Count, nameof(eriks_badges.Count) + " is failing"); //erik has only 1 of these
        }
    }
}
