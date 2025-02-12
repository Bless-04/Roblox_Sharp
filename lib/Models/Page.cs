using Roblox_Sharp.Framework;
using System;
using System.Collections.Generic;

namespace Roblox_Sharp.Models
{

    ///<remarks>
    ///<see langword="new"/> <see cref="Page{T}"/>() will throw an error  if <br/>
    ///<see cref="Page{T}.previousPageCursor"/> and <see cref="Page{T}.nextPageCursor"/> are both not set
    ///</remarks>
    /// <inheritdoc cref="IPage{T}"/>
    /// <exception cref="InvalidOperationException">if both cursors are null</exception>

    public class Page<T>(string? previousPage, string? nextPage = null) : IPage<T>
    {
        public Page() : this(null, null) { }
        /// <inheritdoc cref="previousPageCursor"/>
        private string? _previousPageCursor = previousPage;

        private InvalidOperationException pageCursorError => new($"{nameof(previousPageCursor)} and {nameof(nextPageCursor)} are null");

        /// <inheritdoc/>
        public string? previousPageCursor
        {
            get => _previousPageCursor;
            init => _previousPageCursor = (value == null && nextPageCursor == null) 
                ? throw pageCursorError 
                : value;        
        }

        /// <summary>
        /// <inheritdoc cref="nextPageCursor"/>
        /// </summary>
        private string? _nextPageCursor = nextPage;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string? nextPageCursor
        {
            get => _nextPageCursor;
            init => _nextPageCursor = (value == null && previousPageCursor == null)
                ? throw pageCursorError 
                : value;
        }

        /// <inheritdoc cref="data"/>
        private IReadOnlyList<T> _data = [];

        /// <inheritdoc/>
        public IReadOnlyList<T> data
        {
            get => _data;
            init => _data = value;
        }

        /// <inheritdoc cref="Previous(List{T}?)"/>
        public static Page<T> operator --(Page<T> page) => (Page<T>)page.Previous();

        /// <inheritdoc/>
        public IPage<T> Previous(List<T>? data = null)
        {
            if (this._nextPageCursor == null) throw new IndexOutOfRangeException("There is no next Page");
            this._previousPageCursor = this._nextPageCursor;
            this._nextPageCursor = null;
            this._data = (IReadOnlyList<T>?)data ?? [];

            return this;
        }

        /// <inheritdoc/>
        public IPage<T> Next(List<T>? data = null)
        {
            if (this._previousPageCursor == null) throw new IndexOutOfRangeException("There is no previous Page");
            this._nextPageCursor = this._previousPageCursor;
            this._previousPageCursor = null;
            this._data = (IReadOnlyList<T>?)data ?? [];
            return this;
        }

        /// <inheritdoc cref="Next(List{T}?)"/>
        public static Page<T> operator ++(Page<T> page) => (Page<T>)page.Next();
    }
}
