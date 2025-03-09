using Roblox_Sharp.Framework;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models
{
    /// <inheritdoc cref="IPage{T}"/>
    public class Page<T>() : IPage<T>
    {
        /// <inheritdoc cref="IPage.PreviousPageCursor"/>
        [JsonPropertyName("previousPageCursor")]
        public string? PreviousPageCursor { get; set; }

        /// <inheritdoc cref="IPage.NextPageCursor"/>
        [JsonPropertyName("nextPageCursor")]
        public string? NextPageCursor { get; set; }

        /// <summary>
        /// <inheritdoc cref="IPage{T}.Data"/>
        /// </summary>
        [JsonPropertyName("data")]
        public IReadOnlyList<T> Data { get; set; } = [];

        /// <inheritdoc cref="go_Previous(List{T}?)"/>
        public static Page<T> operator --(Page<T> page) => (Page<T>)page.go_Previous();

        /// <inheritdoc/>
        public IPage<T> go_Previous(List<T>? data = null)
        {
            if (this.NextPageCursor == null) throw new IndexOutOfRangeException("There is no next Page");
            this.PreviousPageCursor = this.NextPageCursor;
            this.NextPageCursor = null;
            this.Data = (IReadOnlyList<T>?)data ?? [];

            return this;
        }

        /// <inheritdoc/>
        public IPage<T> go_Next(List<T>? data = null)
        {
            if (this.PreviousPageCursor == null) throw new IndexOutOfRangeException("There is no previous Page");
            this.NextPageCursor = this.PreviousPageCursor;
            this.PreviousPageCursor = null;
            this.Data = (IReadOnlyList<T>?)data ?? [];
            return this;
        }

        /// <inheritdoc cref="IPage{T}.go_Next(List{T}?)"/>
        public static Page<T> operator ++(Page<T> page) => (Page<T>)page.go_Next();
    }
}
