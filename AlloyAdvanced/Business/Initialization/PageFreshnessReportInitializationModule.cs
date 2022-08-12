using EPiServer.Data.Cache;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AlloyAdvanced.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class PageFreshnessReportInitializationModule : IInitializableModule
    {
        bool initialized = false;
        public void Initialize(InitializationEngine context)
        {
            if (initialized == false)
            {
                RouteTable.Routes.MapRoute(
                    name: "PageFreshnessReportHejsan",
                    url: "pagefreshnessreport/{action}",
                    defaults: new { controller = "PageFreshnessReport", action = "Index" }
                    );

                initialized = true;
            }
        }

        public void Uninitialize(InitializationEngine context)
        {

        }
    }
}