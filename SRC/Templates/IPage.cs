
namespace Roblox_Sharp.Templates
{
    /// <summary>
    /// template for all the page based requests that have a <typeparamref name="data"/> field
    /// </summary>
    /// <typeparam name="T[]"></typeparam> 
    public abstract class IPage<T>
    {
        /// <summary>
        /// previous page cursor of the request . if <b>null</b> there are no previous pages / is the first page
        /// </summary>
        public string? previousPageCursor { get; init; }

        /// <summary>
        /// next page cursor of the request. if <b>null</b> there are no more pages / is the last page
        /// </summary>
        public string? nextPageCursor { get; init; }

        required public T[] data { get; init; }

        public IPage() { }

        public IPage(string? previousPageCursor, string? nextPageCursor, T[] data)
        {
            this.previousPageCursor = previousPageCursor;
            this.nextPageCursor = nextPageCursor;
            this.data = data;
        }

        
    }

   
}
