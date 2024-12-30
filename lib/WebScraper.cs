
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

using System.Text.Json;

using Roblox_Sharp.Models;
using Roblox_Sharp.Models.Internal;
using Roblox_Sharp.Exceptions;
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
            Profile_Response scraped_profile = new();
            // Load HTML content
            string htmlContent = await client.GetStringAsync($"https://www.roblox.com/users/{userId}/profile");

            XmlDocument doc = new();
                

            
            // Past Usernames
            Match pastUsernames = Regex.Match(htmlContent, @"(?<=<span>Past Usernames:<\/span>\s*<p>).*?(?=<\/p>)");
            Debug.WriteLine($"Past Usernames: {pastUsernames.Value}");


            var match = Regex.Match(htmlContent, @"\{""profileusername"":"".*"",""previoususernames"":"".*""}");


            Profile_Response.Parse(match, ref scraped_profile);


            // Join Date
            var joinDate = Regex.Match(htmlContent, @"(?<=<span>Join Date:<\/span>\s*<p>).*?(?=<\/p>)");

            

            // Counts (Friends, Followers, Following)
            var counts = Regex.Matches(htmlContent, @"(?<=<span class=""font-caption-header"">)(\d+)(?=<\/span>)");
            
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
