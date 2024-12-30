namespace Roblox_Sharp.Models.Internal
{
    /// <summary>
    /// used to serialize the responses with a count field 
    /// </summary>
    internal readonly struct Count_Response
    {
        required internal ulong count { get; init; }
    }
}
