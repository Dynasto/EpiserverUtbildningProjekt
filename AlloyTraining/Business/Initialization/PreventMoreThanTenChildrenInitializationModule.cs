using AlloyTraining.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlloyTraining.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class PreventMoreThanTenChildrenInitializationModule : IInitializableModule
    {
        bool initialized = false;
        IContentEvents events;
        IContentLoader loader;
        const int maxChildren = 10;

        public void Initialize(InitializationEngine context)
        {
            if (!initialized)
            {
                loader = context.Locate.ContentLoader();
                events = context.Locate.ContentEvents();
                events.CreatingContent += Events_CreatingContent;
                initialized = true;
            }
        }

        void Events_CreatingContent(object sender, ContentEventArgs e)
        {
            var sitePAge = e.Content as SitePageData;
            if (sitePAge != null)
            {
                var children = loader.GetChildren<IContent>(sitePAge.ParentLink);
                if (children.Count() > maxChildren)
                {
                    e.CancelAction = true;
                    e.CancelReason = "There are too many children.";
                }
            }
        }

        public void Uninitialize(InitializationEngine context)
        {
            if (initialized)
            {
                events.CreatingContent -= Events_CreatingContent;
            }
        }
    }
}