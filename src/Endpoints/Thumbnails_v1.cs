﻿
using Roblox_Sharp.Enums;
using Roblox_Sharp.Enums.Thumbnail;
using Roblox_Sharp.Models;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using static Roblox_Sharp.WebAPI;

namespace Roblox_Sharp.Endpoints
{
    /// <summary>
    /// Endpoints for requesting thumbnails
    /// <b><see href="https://thumbnails.roblox.com//docs/index.html">Thumbnails API Documentation v1</see></b>
    /// </summary>
    public static class Thumbnails_v1
    {
        /// <summary>
        /// Get Avatar Headshots for the given array of <paramref name="userIds"/> 
        /// <br></br>
        /// <b><seealso href="https://thumbnails.roblox.com//docs/index.html">Thumbnails API Documentation v1</seealso></b>
        /// <br></br>
        /// <b>Will ignore users that, dont exist , are terminated/banned or are already in list</b>
        /// <br></br>
        /// <br></br>
        /// <code><paramref name="SIZE"/> blacklist: 
        /// <br></br> Size.x30</code>
        /// </summary>
        /// <param name="userIds"></param>
        /// <param name="SIZE"></param>
        /// <param name="FORMAT"></param>
        /// <param name="isCircular">if image should be circular</param>
        /// <returns>List of Avatar</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static async Task<IReadOnlyList<Thumbnail>> Get_AvatarHeadshotsAsync(ulong[] userIds, Size SIZE = Size.x48, Format FORMAT = Format.Png, bool isCircular = false)
        {
            if (SIZE == Size.x30) throw new ArgumentOutOfRangeException($"{SIZE} is not supported for this request.");
            // example https://thumbnails.roblox.com/v1/users/avatar-headshot?userIds=1&size=48x48&format=Png&isCircular=false

            return
                JsonSerializer.Deserialize<Page<Thumbnail>>(
                    await Get_RequestAsync(
                        $"https://thumbnails.roblox.com/v1/users/avatar-headshot?userIds={string.Join(",", userIds)}" +
                        $"&size={EnumExtensions.ToString(SIZE)}" +
                        $"&format={FORMAT}" +
                        $"&isCircular={isCircular}")
            )!.Data;
        }

        /// <summary>
        /// Get Avatar Busts for the given array of <paramref name="userIds"/>
        /// <br></br>
        /// <b><seealso href="https://thumbnails.roblox.com//docs/index.html">Thumbnails API Documentation v1</seealso></b>
        /// <br></br>
        /// <b>Will ignore users that, dont exist , are terminated/banned or are already in list</b>
        /// <br></br>
        /// <br></br>
        /// <code><paramref name="SIZE"/> blacklist:
        /// <br></br> Size.x30, Size.x110, Size.x720</code> 
        /// </summary>
        /// <param name="userIds"></param>
        /// <param name="SIZE"></param>
        /// <param name="FORMAT"></param>
        /// <param name="isCircular"></param>
        /// <returns>Avatar[]</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static async Task<IReadOnlyList<Thumbnail>> Get_AvatarBustsAsync(ulong[] userIds, Size SIZE = Size.x48, Format FORMAT = Format.Png, bool isCircular = false)
        {
            if (((Size_Flags.x30 | Size_Flags.x110 | Size_Flags.x720) & EnumExtensions.ToFlag<Size_Flags>(SIZE)) != 0) throw new ArgumentException($"{SIZE} is not valid for this request");
            // url example https://thumbnails.roblox.com/v1/users/avatar-bust?userIds=1,156,256,2,16&size=48x48&format=Png&isCircular=false
            if (FORMAT == Format.Jpeg) throw new ArgumentException($"{FORMAT} is not supported for this request");

            return
                JsonSerializer.Deserialize<Page<Thumbnail>>(
                    await Get_RequestAsync(
                        $"https://thumbnails.roblox.com/v1/users/avatar-bust?userIds={string.Join(",", userIds)}" +
                        $"&size={EnumExtensions.ToString(SIZE)}" +
                        $"&format={FORMAT}" +
                        $"&isCircular={isCircular}")
                )!.Data;
        }

        /// <summary>
        /// Get Avatar Full body shots for the given array of <paramref name="userIds"/> 
        /// <br></br><b><seealso href="https://thumbnails.roblox.com//docs/index.html">Thumbnails API Documentation v1</seealso></b>
        /// </summary>
        /// <param name="userIds"></param>
        /// <param name="SIZE"></param>
        /// <param name="FORMAT"></param>
        /// <param name="isCircular"></param>
        /// <returns>Avatar[]</returns>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="SIZE"/> is x50 or x48</exception>
        public static async Task<IReadOnlyList<Thumbnail>> Get_AvatarsAsync(ulong[] userIds, Size SIZE = Size.x48, Format FORMAT = Format.Png, bool isCircular = false)
        {
            if (SIZE == Size.x50) throw new ArgumentException($"{SIZE} is not supported for this request.");
            //url example https://thumbnails.roblox.com/v1/users/avatar?userIds=1,156&size=30x30&format=Png&isCircular=false

            return
                JsonSerializer.Deserialize<Page<Thumbnail>>(
                    await Get_RequestAsync(
                        $"https://thumbnails.roblox.com/v1/users/avatar?userIds={string.Join(",", userIds)}" +
                        $"&size={EnumExtensions.ToString(SIZE)}" +
                        $"&format={FORMAT.ToString()}" +
                        $"&isCircular={isCircular}")
                )!.Data;
        }

    }
}
