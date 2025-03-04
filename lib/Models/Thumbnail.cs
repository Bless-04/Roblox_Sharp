﻿namespace Roblox_Sharp.Models;
/** example return 
 * 
 {
    "data": [
        {
            "targetId": 0,
            "state": "Error",
            "imageUrl": "string",
            "version": "string"
        }
    ]
}*/

/// <summary>
/// class used to serialize Thumbnail based requests
/// </summary>
public class Thumbnail
{
    public ulong targetId { get; init; }

    required public string state { get; init; }

    /// <summary>
    /// image url of thumbnail 
    /// </summary>
    required public string imageUrl { get; init; }

    required public string version { get; init; }
}
