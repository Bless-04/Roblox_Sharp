using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Roblox_Sharp.Templates;

namespace Roblox_Sharp.JSON_Models
{
    /// <summary>
    /// used for all the page based requests ; requests that can return multiple pages or have a data[] field
    /// </summary>
    /// <typeparam name="T[]"></typeparam> 
    public class Page<T> : IPage<T>
    {   
        public Page() : base(null,null,Array.Empty<T>()) { }

        [JsonConstructor]
        public Page(string? previousPageCursor, string? nextPageCursor, IReadOnlyList<T> data) 
            : base (previousPageCursor, nextPageCursor, data) { }
    }
}
