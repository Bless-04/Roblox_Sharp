using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Http;
using System;

using Roblox_Sharp.Exceptions;

namespace Tests
{
    /// <summary>
    /// abstract class for all endpoints that may be prone to being rate limited <br></br>
    /// Default delay is 61000ms
    /// </summary>
    public abstract class IRateLimited
    {
        /// <summary>
        /// Delay before each tests runs
        /// </summary>
        public int TestDelay { get; init; } = 0;

        /// <summary>
        /// template for all endpoint tests
        /// </summary>
        /// <param name="testdelay">Delay for tests that are rate limited</param>
        public IRateLimited(int testdelay = 61000)
        {
            Roblox_Sharp.WebAPI.OnSuccessfulRequest += OnSuccessfulRequest;
            Roblox_Sharp.WebAPI.OnFailedRequest += OnFailedRequest;

            this.TestDelay = testdelay;
        }

        public void OnSuccessfulRequest(object? sender, EventArgs e) => Debug.WriteLine("SUCCESS " + (sender as HttpResponseMessage)?.RequestMessage);
        public void OnFailedRequest(object? sender, EventArgs e) => Debug.WriteLine("HANDLED " + (sender as HttpResponseMessage)?.RequestMessage);

        /// <summary>
        /// Skip if a test is rate limitted
        /// </summary>
        /// <param name="testCode">code to test</param>
        /// <param name="MethodName">Methodname for console</param>
        /// <param name="delay">delay in ms, <br></br>default is 61000</param>
        public void Test(Func<Task> testCode, string? MethodName = "Test",int? delay = null)
        {
            try
            {
                Task.Delay(delay ?? TestDelay).Wait();


                testCode();
                Skip.If(false);
            }
            catch (RateLimitException)
            {
                string message = MethodName + " was rate limited >>skipped";

                Skip.If(true, message);

                Debug.WriteLine(message);
            }
        }

       
    }
}
