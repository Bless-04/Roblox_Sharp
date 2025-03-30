using System;
using System.Collections.Generic;

namespace Roblox_Sharp.Models
{
    /// <inheritdoc cref="Page{T}"/>
    public class Page<T>() : Abstractions.Page<T> 
    {
        /// <inheritdoc/>
        public void go_Previous(List<T>? data = null)
        {
            if (NextPageCursor == null) throw new IndexOutOfRangeException("There is no next Page");
            PreviousPageCursor = NextPageCursor;
            NextPageCursor = null;
            Data = (IReadOnlyList<T>?)data ?? [];
        }

        


        /// <inheritdoc/>
        public void go_Next(List<T>? data = null)
        {
            if (PreviousPageCursor == null) throw new IndexOutOfRangeException("There is no previous Page");
            NextPageCursor = PreviousPageCursor;
            PreviousPageCursor = null;
            Data = (IReadOnlyList<T>?)data ?? [];
        }

    }
}
