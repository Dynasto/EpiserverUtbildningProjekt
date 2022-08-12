using AlloyTraining.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.PlugIn;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using System;

namespace AlloyTraining.Business.ScheduledJobs
{
    [ScheduledPlugIn(DisplayName = "Remove Bad Words", Description = "blabla")]
    public class RemoveBadWordsScheduledJob : ScheduledJobBase
    {
        private bool _stopSignaled;

        string[] badWords = new[] { "stupid" };

        public RemoveBadWordsScheduledJob()
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
            var repo = ServiceLocator.Current.GetInstance<IContentRepository>();
            var finder = ServiceLocator.Current.GetInstance<IPageCriteriaQueryService>();
            int pageCount = 0;

            foreach (string word in badWords)
            {
                var criteria = new PropertyCriteriaCollection();
                criteria.Add(new PropertyCriteria
                {
                    Type = PropertyDataType.LongString,
                    Name = "PageName",
                    Condition = EPiServer.Filters.CompareCondition.Contained,
                    Value = word
                });

                PageDataCollection results = finder.FindPagesWithCriteria(ContentReference.RootPage as PageReference, criteria);
                foreach (var page in results)
                {
                    var clone = page.CreateWritableClone() as SitePageData;
                    clone.Name = page.Name.Replace(word, "[fult]");
                    repo.Save(clone, EPiServer.DataAccess.SaveAction.CheckIn, EPiServer.Security.AccessLevel.NoAccess);
                    pageCount++;
                }
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
