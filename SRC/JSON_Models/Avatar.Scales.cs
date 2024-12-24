﻿using System.Text.Json.Serialization;

namespace Roblox_Sharp.JSON_Models;

[JsonSerializable(typeof(Avatar.Scales))]
public partial class Avatar
{
    public readonly struct Scales
    {
        public double height { get; init; }
        public double width { get; init; }
        public double head { get; init; }
        public double depth { get; init; }
        public double proportion { get; init; }
        public double bodyType { get; init; }
    }
}
