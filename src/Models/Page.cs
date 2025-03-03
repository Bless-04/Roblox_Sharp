using Roblox_Sharp.Framework;
using System;
using System.Collections.Generic;

namespace Roblox_Sharp.Models
{
    /// <inheritdoc cref="IPage{T}"/>
    public class Page<T>() : IPage<T>
    {
        /// <inheritdoc cref="IPage.previousPageCursor"/>
        public string? previousPageCursor { get; set; }

        /// <inheritdoc cref="IPage.nextPageCursor"/>
        public string? nextPageCursor { get; set; }

        /// <summary>
        /// <inheritdoc cref="IPage{T}.data"/>
        /// </summary>
        public IReadOnlyList<T> data { get; set; } = [];

        /// <inheritdoc cref="Previous(List{T}?)"/>
        public static Page<T> operator --(Page<T> page) => (Page<T>)page.Previous();

        /// <inheritdoc/>
        public IPage<T> Previous(List<T>? data = null)
        {
            if (this.nextPageCursor == null) throw new IndexOutOfRangeException("There is no next Page");
            this.previousPageCursor = this.nextPageCursor;
            this.nextPageCursor = null;
            this.data = (IReadOnlyList<T>?)data ?? [];

            return this;
        }

        /// <inheritdoc/>
        public IPage<T> Next(List<T>? data = null)
        {
            if (this.previousPageCursor == null) throw new IndexOutOfRangeException("There is no previous Page");
            this.nextPageCursor = this.previousPageCursor;
            this.previousPageCursor = null;
            this.data = (IReadOnlyList<T>?)data ?? [];
            return this;
        }

        /// <inheritdoc cref="Next(List{T}?)"/>
        public static Page<T> operator ++(Page<T> page) => (Page<T>)page.Next();
    }
}
