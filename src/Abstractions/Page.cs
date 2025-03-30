using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Abstractions
{
    /// <summary>
    /// template for all the page based requests that have a previous and next cursor
    /// </summary>
    public interface IPage
    {
        /// <summary>
        /// previous page cursor of the request .<br/> <see langword="null"/> if there are no previous pages or object is the first page
        /// </summary>
        public string? PreviousPageCursor { get; }

        /// <summary>
        /// next page cursor of the request.<br/> <see langword="null"/> if there are no more pages or instance is the last page
        /// </summary>
        public string? NextPageCursor { get; }

        IPage go_Previous();

        IPage go_Next();
    }

    /// <summary>
    /// used for all the page based requests ; requests that can return multiple pages or have a data[] field
    /// </summary>
    /// <typeparam name="T">The data type</typeparam>
    /// <remarks>indirectly implements <seealso cref="IReadOnlyList{T}"/> </remarks>
    public abstract class Page<T> : IPage
    {
        /// <inheritdoc/>
        [JsonPropertyName("previousPageCursor")]
        public string? PreviousPageCursor { get; protected set; }

        /// <inheritdoc/>
        [JsonPropertyName("nextPageCursor")]
        public string? NextPageCursor { get; protected set; }

        /// <summary>
        /// List of <typeparamref name="T"/> returned by the request
        /// </summary>
        [JsonPropertyName("data")]
        public IReadOnlyList<T> Data { get; protected set; } = [];

        /// <inheritdoc cref="IReadOnlyCollection{T}.Count"/>
        public int Count => Data.Count;

        /// <inheritdoc cref="IReadOnlyList{T}.this[int]"/>
        public T this[int index] => Data[index];

        /// <summary>
        /// Goes back 1 page <br></br>
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static Page<T> operator --(Page<T> page) => page.go_Previous();

        /// <inheritdoc/>
        public void go_Previous(List<T>? data = null)
        {
            if (NextPageCursor == null) throw new IndexOutOfRangeException("There is no next Page");
            PreviousPageCursor = NextPageCursor;
            NextPageCursor = null;
            Data = (IReadOnlyList<T>?)data ?? [];
        }

        public void go_Next(List<T>? data = null)
        {
            if (PreviousPageCursor == null) throw new IndexOutOfRangeException("There is no previous Page");
            NextPageCursor = PreviousPageCursor;
            PreviousPageCursor = null;
            Data = (IReadOnlyList<T>?)data ?? [];
        }

       
        
        /// <summary>
        /// Goes forward 1 page
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException">if there is no next page</exception>
        public static Page<T> operator ++(Page<T> page) => page.go_Next();

        public abstract Page<T> go_Next();

        /// <summary>
        /// <inheritdoc cref="IEnumerable.GetEnumerator"/>
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator() => Data.GetEnumerator();
    }
}
