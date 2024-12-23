using System.Text.Json.Serialization;
using System;

namespace Roblox_Sharp.JSON_Models;

[JsonSerializable(typeof(Badge))]
public class Badge
{
    /// <summary>
    /// the badge id 
    /// </summary>
    public ulong badgeId { get; init; }

    /// <summary>
    /// ambiguous with badge id
    /// </summary>
    [JsonInclude]
    private ulong id { init => badgeId = value; }

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

    public Statistics statistics { get; init; }

    /// <summary>
    /// the place that awarded the badge
    /// </summary>
    public Game? awardingUniverse { get; init; }

    /// <summary>
    /// ambiguous with awarding universe
    /// </summary>
    [JsonInclude]
    private Game? awarder { init => awardingUniverse = value; }

    /// <summary>
    /// the user that created the badge
    /// </summary>
    public User? creator { get; init; }

    
    public readonly struct Statistics
    {
        public ulong pastDayAwardedCount { get; init; }

        public ulong awardedCount { get; init; }

        public double winRatePercentage { get; init; }
    }
}

