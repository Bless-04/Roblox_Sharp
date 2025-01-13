using Roblox_Sharp.Exceptions;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace xUnitTests
{
    /// <summary>
    /// abstract class for all endpoints that may be prone to being rate limited <br></br>
    /// Default delay is 61000ms
    /// </summary>
    public abstract class IDelayedTest
    {
        /// <summary>
        /// Delay before each tests runs
        /// </summary>
        protected int DefaultDelay { get; init; } = 61000;

        /// <summary>
        /// template for all endpoint tests
        /// </summary>
        /// <param name="testdelay">Delay for tests that are rate limited</param>
        public IDelayedTest(int? testdelay = null)
        {
            Roblox_Sharp.WebAPI.OnSuccessfulRequest += OnSuccessfulRequest;
            Roblox_Sharp.WebAPI.OnFailedRequest += OnFailedRequest;

            DefaultDelay = testdelay ?? DefaultDelay;
        }

        public void OnSuccessfulRequest(object? sender, EventArgs e) => Debug.WriteLine("SUCCESS " + (sender as HttpResponseMessage)?.RequestMessage);
        public void OnFailedRequest(object? sender, EventArgs e) => Debug.WriteLine("HANDLED " + (sender as HttpResponseMessage)?.RequestMessage);


        
        /// <summary>
        /// Delays tests
        /// important for test that rate limit easily
        /// </summary>
        /// <param name="testCode"></param>
        public static void DelayedTest(int customDelay,Func<Task> testCode)
        {   
            Task.Delay(customDelay).Wait();
            try
            {
                testCode().Wait();
            }
            catch (AggregateException e)
            {
                throw e.InnerException!;
            }
        }

        /// <summary>
        /// <inheritdoc cref="DelayedTest(int, Func{Task})"/>
        /// </summary>
        /// <param name="testCode"></param>
        public void DelayedTest(Func<Task> testCode) => DelayedTest(DefaultDelay, testCode);
        

        


    }
}
