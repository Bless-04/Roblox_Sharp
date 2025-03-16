using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Framework;
using System;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models
{
    /// <summary>
    /// class used to serialize Badge based requests
    /// </summary>
    public partial class Badge : Creation<IBadge> , IBadge
    {
        /// <summary>
        /// the badge id 
        /// </summary>
        [JsonPropertyName("badgeId")]
        public ulong BadgeId
        {
            get => base.CreationId ?? throw new NotRequestedException(nameof(BadgeId));
            init => base.CreationId = value;
        }

        /// <summary>
        /// the name of the badge 
        /// </summary>
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

        public string? BadgeName { get; init; }

        /// <summary>
        /// the badge description 
        /// </summary>
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Description { get; init; }

        /// <summary>
        /// the localized name of the badge 
        /// </summary>
        [JsonPropertyName("displayName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DisplayName { get; init; }

        /// <summary>
        /// the localized description of the badge
        /// </summary>
        [JsonPropertyName("displayDescription")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DisplayDescription { get; init; }

        /// <summary>
        /// whether or not the badge is Enabled
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool Enabled { get; init; }

        /// <summary>
        /// The badge icon asset Id.
        /// </summary>
        [JsonPropertyName("iconImageId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ulong IconImageId { get; init; }

        /// <summary>
        /// The localized badge icon asset Id.
        /// </summary>
        [JsonPropertyName("displayIconImageId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ulong DisplayIconImageId { get; init; }

        /// <summary>
        /// When the badge was created.
        /// </summary>
        [JsonPropertyName("created")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Created { get; init; }

        /// <summary>
        /// When the badge was updated.
        /// </summary>
        [JsonPropertyName("updated")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Updated { get; init; }

        /// <summary>
        /// <inheritdoc cref="Badge.Statistic"/>
        /// </summary>
        [JsonPropertyName("statistics")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Statistic? Statistics { get; init; }

        /// <summary>
        /// the place that awarded the badge
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

        public Game? awardingUniverse { get; init; }

        /// <summary>
        /// ambiguous with awarding universe
        /// </summary>
        [JsonInclude]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        protected Game? awarder
        {
            get => awardingUniverse;
            init => awardingUniverse = value;
        }

        /// <summary>
        /// the user that created the badge
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public User? creator { get; init; }

        /// <inheritdoc/>
        public Badge Clone() => new()
        {
            BadgeId = BadgeId,
            BadgeName = BadgeName,
            Description = Description,
            DisplayName = DisplayName,
            DisplayDescription = DisplayDescription,
            Enabled = Enabled,
            IconImageId = IconImageId,
            DisplayIconImageId = DisplayIconImageId,
            Created = Created,
            Updated= Updated,
            Statistics = Statistics,
            awardingUniverse = awardingUniverse?.Clone(),
            creator = creator?.Clone()
        };
    }
}
