using Roblox_Sharp.Framework;
using System;
using System.Collections.Generic;

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
        public IReadOnlyList<T> data { get; protected set; }

        /// <summary>
        /// Goes back 1 page <br></br>
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"> if there is no previous page</exception>
        public static Page<T> operator --(Page<T> page)
        {

            if (page.nextPageCursor == null) throw new IndexOutOfRangeException("There is no next Page");
            page.previousPageCursor = page.nextPageCursor;
            page.nextPageCursor = null;
            page.data = Array.Empty<T>();
            
            return page;
        }

        /// <summary>
        /// Goes forward 1 page
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException">if there is no next page</exception>
        public static Page<T> operator ++(Page<T> page)
        {
            if (page.previousPageCursor == null) throw new IndexOutOfRangeException("There is no previous Page");

            page.nextPageCursor = page.previousPageCursor;
            page.previousPageCursor = null;
            page.data = Array.Empty<T>();

            return page;
        }
        public Page(string? previousPageCursor = null, string? nextPageCursor = null, IReadOnlyList<T>? data = null)
        {
            base.previousPageCursor = previousPageCursor;
            base.nextPageCursor = nextPageCursor;
            this.data = data ?? Array.Empty<T>();
        }
    }
}
