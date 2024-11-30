using System.Text.Json.Serialization;
using System;

namespace Roblox_Sharp.JSON;

public class Badge
{
    /// <summary>
    /// the badge id 
    /// </summary>
    [JsonPropertyName("id")]
    public ulong id { get; init; }

    /// <summary>
    /// the name of the badge 
    /// </summary>
    [JsonPropertyName("name")]
    public string? name { get; init; }

    /// <summary>
    /// the badge description 
    /// </summary>
    [JsonPropertyName("description")]
    public string? description { get; init; }

    /// <summary>
    /// the localized name of the badge 
    /// </summary>
    [JsonPropertyName("displayName")]
    public string? displayName { get; init; }

    /// <summary>
    /// the localized description of the badge
    /// </summary>
    [JsonPropertyName("displayDescription")]
    public string? displayDescription { get; init; }

    /// <summary>
    /// whether or not the badge is enabled
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool enabled { get; init; }

    /// <summary>
    /// The badge icon asset Id.
    /// </summary>
    [JsonPropertyName("iconImageId")]
    public ulong iconImageId { get; init; }

    /// <summary>
    /// The localized badge icon asset Id.
    /// </summary>
    [JsonPropertyName("displayIconImageId")]
    public ulong displayIconImageId { get; init; }

    /// <summary>
    /// When the badge was created.
    /// </summary>
    [JsonPropertyName("created")]
    public DateTime created { get; init; }

    /// <summary>
    /// When the badge was updated.
    /// </summary>
    [JsonPropertyName("updated")]
    public DateTime updated { get; init; }

    [JsonPropertyName("statistics")]
    public Statistics statistics { get; init; }

    /// <summary>
    /// the place that awarded the badge
    /// </summary>
    [JsonPropertyName("awardingUniverse")]
    public Game? awardingUniverse { get; init; }

    /// <summary>
    /// the place that awarded the badge
    /// </summary>
    [JsonPropertyName("awarder")]
    public Game? awarder 
    { 
        get => awardingUniverse; 
        init => awardingUniverse = value; 
    }

    /// <summary>
    /// the user that created the badge
    /// </summary>
    [JsonPropertyName("creator")]
    public User? creator { get; init; }

    public readonly struct Statistics
    {
        [JsonPropertyName("pastDayAwardedCount")]
        public ulong pastDayAwardedCount { get; init; }

        [JsonPropertyName("awardedCount")]
        public ulong awardedCount { get; init; }

        [JsonPropertyName("winRatePercentage")]
        public double winRatePercentage { get; init; }
    }
}

