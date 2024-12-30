using System.Collections.Generic;
using Roblox_Sharp.Framework;

namespace Roblox_Sharp.Models
{
    /// <summary>
    /// used for all the page based requests ; requests that can return multiple pages or have a data[] field
    /// </summary>
    /// <typeparam name="T[]"></typeparam> 
    public class Page<T> : IPage
    {
        /// <summary>
        /// data of the request
        /// </summary>
        required public IReadOnlyList<T> data { get; init; }

        public Page() { }
        public Page(string? previousPageCursor, string? nextPageCursor, IReadOnlyList<T> data) : base(previousPageCursor, nextPageCursor) =>
            this.data = data;
    }
}
