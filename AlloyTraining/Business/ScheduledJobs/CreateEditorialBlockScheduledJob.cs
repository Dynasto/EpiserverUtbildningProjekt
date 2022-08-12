using AlloyTraining.Models.Blocks;
using EPiServer;
using EPiServer.Core;
using EPiServer.PlugIn;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using System;

namespace AlloyTraining.Business.ScheduledJobs
{
    [ScheduledPlugIn(DisplayName = JobName, GUID = "5F08E8EB-2A79-406E-952B-54AF3196BCD0",
        SortIndex = -1)]
    public class CreateEditorialBlockScheduledJob : ScheduledJobBase
    {
        private bool _stopSignaled;
        public const string JobName = "Create Editorial Block Scheduled Job";

        public CreateEditorialBlockScheduledJob()
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

            var forAllSites = ContentReference.GlobalBlockFolder;

            var editorial = repo.GetDefault<EditorialBlock>(forAllSites);

            editorial.MainBody = new XhtmlString("<p>hejsan</p>");

            var content = editorial as IContent;

            content.Name = "content NaMe";

            var newBlockRef = repo.Save(content,EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.NoAccess);

            return "Change to message that describes outcome of execution";
        }
    }
}
