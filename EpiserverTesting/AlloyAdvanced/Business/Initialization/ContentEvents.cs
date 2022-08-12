using AlloyAdvanced.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using System;
using System.Linq;

namespace AlloyAdvanced.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class ContentEvents : IInitializableModule
    {
        private bool isRunning { get; set; }

        public void Initialize(InitializationEngine context)
        {
            if (isRunning == false)
            {
                //var contentEvents = ServiceLocator.Current.GetInstance<IContentEvents>();
                var contentEvents = context.Locate.ContentEvents();
                var loader = context.Locate.ContentLoader();

                contentEvents.PublishingContent += Events_PublishedContent;
                contentEvents.CreatingContent += Events_CreatingContent;
                isRunning = true;
            }
        }

        private void Events_CreatingContent(object sender, EPiServer.ContentEventArgs e)
        {
            var cLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var page = e.Content as SitePageData;
return;

            if (page == null) return;

            if (cLoader.GetChildren<IContent>(page.ParentLink).Count() > 5)
            {
                e.CancelAction = true;
                e.CancelReason = "Max children";
            }
        }

        private void Events_PublishedContent(object sender, EPiServer.ContentEventArgs e)
        {
            var cLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            cLoader.TryGet<ProductPage>(e.ContentLink, out var productPage);
            cLoader.TryGet<StartPage>(e.ContentLink, out var startPage);

            if (productPage == null && startPage == null)
            {
                return;
            }

            if (productPage != null)
            {
                if (DateTime.Now > new DateTime(2017, 11, 9))
                {
                    if (productPage.Name.Contains("rolle"))
                    {
                        e.CancelAction = true;
                        e.CancelReason = "Rolle";
                    }
                }
            }
            else if (startPage != null)
            {
                /*  if (cLoader.GetChildren<SitePageData>(startPage.ContentLink).Count() > 5)
                  {
                      e.CancelAction = true;
                      e.CancelReason = "Rolle";
                  }*/
            }
        }

        public void Uninitialize(InitializationEngine context)
        {
            //Add uninitialization logic
        }
    }
}