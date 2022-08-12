using AlloyAdvanced.Models.NorthwindEntities;
using AlloyAdvanced.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.PlugIn;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using System;
using System.Linq;
using System.Web.WebPages;
using StartPage = AlloyAdvanced.Models.Pages.StartPage;

namespace AlloyAdvanced.Business.ScheduledJobs
{
    [ScheduledPlugIn(DisplayName = "Import Shippers")]
    public class ImportShippers : ScheduledJobBase
    {
        private bool _stopSignaled;
        private readonly IContentRepository conRepo;

        public ImportShippers(IContentRepository conload) : this()
        {
            conRepo = conload;
        }

        public ImportShippers()
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
            int shippersImported = 0;

            //Call OnStatusChanged to periodically notify progress of job for manually started jobs
            OnStatusChanged(String.Format("Starting execution of Import Shippers"));

            var startpage = conRepo.Get<StartPage>(ContentReference.StartPage);
            var existingShippers = conRepo.GetChildren<ShipperPage>(startpage.Shippers);
            var existingIDs = existingShippers.Select(x => x.ShipperId).ToArray();

            var db = new Northwind();
            var shipperds = db.Shippers.Where(x => !existingIDs.Contains(x.ShipperID) || x.Updated);

            foreach (var shipper in shipperds)
            {
                ShipperPage newShipper = null;
                var temp = existingShippers.FirstOrDefault(x => x.ShipperId == shipper.ShipperID);

                if (shipper.Updated && temp != null)
                {
                    shipper.Updated = false;
                    //ServiceLocator.Current.GetInstance<IContentLoader>().Get<IContent>(new ContentReference(114));
                    newShipper = temp.CreateWritableClone() as ShipperPage;//<ShipperPage>();
                }
                else
                {
                    newShipper = conRepo.GetDefault<ShipperPage>(startpage.Shippers);
                }

                newShipper.Name = shipper.CompanyName;
                newShipper.ShipperId = shipper.ShipperID;
                newShipper.CompanyName = shipper.CompanyName;
                newShipper.Phone = shipper.Phone;

                conRepo.Save(newShipper, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.NoAccess);

                shippersImported++;

                //For long running jobs periodically check if stop is signaled and if so stop execution
                if (_stopSignaled)
                {
                    return "Stop of job was called";
                }
            }
            db.SaveChanges();

            if (shippersImported == 0)
            {
                return "No shippers imported";
            }

            return shippersImported + " imported";
        }
    }
}
