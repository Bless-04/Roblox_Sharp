using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using static Roblox_Sharp.Framework.WebHost;

namespace Roblox_Sharp
{
    /// <summary>
    /// static class that holds the functions and logic used for scraping data from the roblox website
    /// </summary> 
    [Obsolete("WebScrape Methods are unstable and subject to change. Use WebAPI if possible")]
    public static class WebScraper
    {
        public static async Task Scrape_ProfileAsync(ulong userId)
        {
            // Load HTML content
            string htmlContent = await client.GetStringAsync($"https://www.roblox.com/users/{userId}/profile");

            // Past Usernames
            Match pastUsernames = Regex.Match(htmlContent, @"(?<=<span>Past Usernames:<\/span>\s*<p>).*?(?=<\/p>)");
            Debug.WriteLine($"Past Usernames: {pastUsernames.Value}");

            // Join Date
            var joinDate = Regex.Match(htmlContent, @"(?<=<span>Join Date:<\/span>\s*<p>).*?(?=<\/p>)");

            Debug.WriteLine($"Join Date: {joinDate.Value}");

            // Counts (Friends, Followers, Following)
            var counts = Regex.Matches(htmlContent, @"(?<=<span class=""font-caption-header"">)(\d+)(?=<\/span>)");
            Debug.WriteLine($"Friends: {counts[0].Value}, Followers: {counts[1].Value}, Following: {counts[2].Value}");

            // Place Visits
            var placeVisits = Regex.Match(htmlContent, @"(?<=<span>Place Visits:<\/span>\s*<p>).*?(?=<\/p>)");
            Debug.WriteLine($"Place Visits: {placeVisits.Value}");

            // Roblox Badges
            var robloxBadges = Regex.Matches(htmlContent, @"(?<=<span class=""text-lead"">).*?(?=<\/span>)");
            Debug.WriteLine("Roblox Badges:");
            foreach (Match badge in robloxBadges)
            {
                Debug.WriteLine($"- {badge.Value}");
            }

            // Custom Badges
            var customBadges = Regex.Matches(htmlContent, @"(?<=<div class=""badge-name"">).*?(?=<\/div>)");

            Console.WriteLine("Custom Badges:");
            foreach (Match badge in customBadges)
            {
                Debug.WriteLine($"- {badge.Value}");
            }
        }
    }
}
