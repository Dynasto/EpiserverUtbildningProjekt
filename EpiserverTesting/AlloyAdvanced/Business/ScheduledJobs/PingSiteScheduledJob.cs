using EPiServer.Core;
using EPiServer.PlugIn;
using EPiServer.Scheduler;
using EPiServer.Web;
using System;
using System.Net.Http;

namespace AlloyAdvanced.Business.ScheduledJobs
{
    [ScheduledPlugIn(DisplayName = "Ping Site",
               GUID = "88E83CA0-93ED-46FD-A338-7938C8D0FDF9", SortIndex = -1)]
    public class PingSiteScheduledJob : ScheduledJobBase
    {
        private bool _stopSignaled;

        public PingSiteScheduledJob()
        {
            IsStoppable = false;
        }

        /// <summary>
        /// Called when a user clicks on Stop for a manually started job, or when ASP.NET shuts down.
        /// </summary>
        public override void Stop()
        {
            _stopSignaled = true;
        }

        /// <summary>
        /// Called when a scheduled job executes
        /// </summary>
        /// <returns>A status message to be stored in the database log and visible from admin mode</returns>

        public override string Execute()
        {
            var client = new HttpClient();
            client.BaseAddress = SiteDefinition.Current.SiteUrl;
            HttpResponseMessage response = client.GetAsync("").Result;
            return $"Pinged {client.BaseAddress} at {DateTime.Now} => {(int)response.StatusCode} {response.ReasonPhrase}";
        }
    }
}
