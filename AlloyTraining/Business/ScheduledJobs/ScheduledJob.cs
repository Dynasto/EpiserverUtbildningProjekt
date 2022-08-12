using EPiServer.Core;
using EPiServer.PlugIn;
using EPiServer.Scheduler;
using System;

namespace AlloyTraining.Business.ScheduledJobs
{
    [ScheduledPlugIn(DisplayName = JobName, GUID = "5F08E8EB-2A79-406E-952B-54AF3196BCD9",
        SortIndex = -1)]
    public class ScheduledJob : ScheduledJobBase
    {
        private bool _stopSignaled;
        public const string JobName = "simulated Job";

        public ScheduledJob()
        {
            IsStoppable = true;
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
            //Call OnStatusChanged to periodically notify progress of job for manually started jobs
            OnStatusChanged(String.Format("Starting execution of {0}", JobName));

            int hejsan = 0;
            var r = new Random();
            while (hejsan < 100)
            {
                hejsan += r.Next(5, 15);
                System.Threading.Thread.Sleep(1500);

                OnStatusChanged($"{hejsan} is at this number, wait please");
            }

            //For long running jobs periodically check if stop is signaled and if so stop execution
            if (_stopSignaled)
            {
                return "Stop of job was called";
            }

            return "Change to message that describes outcome of execution";
        }
    }
}
