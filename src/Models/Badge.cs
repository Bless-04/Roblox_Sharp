using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Framework;
using System;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models
{
    /// <summary>
    /// class used to serialize Badge based requests
    /// </summary>
    public class Badge : Creation
    {
        /// <summary>
        /// the badge id 
        /// </summary>
        public ulong badgeId
        {
            get => base.id ?? throw new NotRequestedException(nameof(badgeId));
            init => base.id = value;
        }

        /// <summary>
        /// the name of the badge 
        /// </summary>
        public string? name { get; init; }

        /// <summary>
        /// the badge description 
        /// </summary>
        public string? description { get; init; }

        /// <summary>
        /// the localized name of the badge 
        /// </summary>
        public string? displayName { get; init; }

        /// <summary>
        /// the localized description of the badge
        /// </summary>
        public string? displayDescription { get; init; }

        /// <summary>
        /// whether or not the badge is enabled
        /// </summary>
        public bool enabled { get; init; }

        /// <summary>
        /// The badge icon asset Id.
        /// </summary>
        public ulong iconImageId { get; init; }

        /// <summary>
        /// The localized badge icon asset Id.
        /// </summary>
        public ulong displayIconImageId { get; init; }

        /// <summary>
        /// When the badge was created.
        /// </summary>
        public DateTime created { get; init; }

        /// <summary>
        /// When the badge was updated.
        /// </summary>
        public DateTime updated { get; init; }

        /// <summary>
        /// <inheritdoc cref="Statistics"/>
        /// </summary>
        public Statistics statistics { get; init; }

        /// <summary>
        /// the place that awarded the badge
        /// </summary>
        public Game? awardingUniverse { get; init; }

        /// <summary>
        /// ambiguous with awarding universe
        /// </summary>
        [JsonInclude]
        protected Game? awarder
        {
            get => awardingUniverse;
            init => awardingUniverse = value;
        }

        /// <summary>
        /// the user that created the badge
        /// </summary>
        public User? creator { get; init; }

        /// <summary>
        /// Holds the statistics of the badge
        /// </summary>
        public readonly struct Statistics
        {
            /// <summary>
            /// the number of times the badge has been awarded in the last day
            /// </summary>
            public ulong pastDayAwardedCount { get; init; }

            /// <summary>
            /// the total number of times the badge has been awarded
            /// </summary>
            public ulong awardedCount { get; init; }

            /// <summary>
            /// the win rate of the badge
            /// </summary>
            public double winRatePercentage { get; init; }
        }

        /// <inheritdoc/>
        public Badge Clone() =>
            new Badge()
            {
                badgeId = badgeId,
                name = name,
                description = description,
                displayName = displayName,
                displayDescription = displayDescription,
                enabled = enabled,
                iconImageId = iconImageId,
                displayIconImageId = displayIconImageId,
                created = created,
                updated = updated,
                statistics = statistics,
                awardingUniverse = awardingUniverse?.Clone(),
                creator = creator?.Clone()
            };
    }
}
