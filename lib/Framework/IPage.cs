namespace Roblox_Sharp.Framework
{
    /// <summary>
    /// template for all the page based requests that have a previous and next cursor
    /// </summary>
    public abstract class IPage
    {
        /// <summary>
        /// previous page cursor of the request . if <b>null</b> there are no previous pages / is the first page
        /// </summary>
        public string? previousPageCursor { get; init; }

        /// <summary>
        /// next page cursor of the request. if <b>null</b> there are no more pages / is the last page
        /// </summary>
        public string? nextPageCursor { get; init; }

        public IPage() { }

        public IPage(string? previousPageCursor, string? nextPageCursor)
        {
            this.previousPageCursor = previousPageCursor;
            this.nextPageCursor = nextPageCursor;
        }
    }
}
