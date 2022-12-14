using System.Web.Mvc;
using EpiserverTesting.Models.Pages;
using EpiserverTesting.Models.ViewModels;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using Castle.Core.Logging;
using EPiServer.Core;

namespace EpiserverTesting.Controllers
{
    public class StartPageController : PageControllerBase<StartPage>
    {
        private readonly ILogger logger;
        /*
        public StartPageController(ILogger logger)
        {
            this.logger = logger;
        }*/

        public ActionResult Index(StartPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);

            var name = Server.MachineName;

            if (SiteDefinition.Current.StartPage.CompareToIgnoreWorkID(currentPage.ContentLink)) // Check if it is the StartPage or just a page of the StartPage type.
            {
                //Connect the view models logotype property to the start page's to make it editable
                var editHints = ViewData.GetEditHints<PageViewModel<StartPage>, StartPage>();
                editHints.AddConnection(m => m.Layout.Logotype, p => p.SiteLogotype);
                editHints.AddConnection(m => m.Layout.ProductPages, p => p.ProductPageLinks);
                editHints.AddConnection(m => m.Layout.CompanyInformationPages, p => p.CompanyInformationPageLinks);
                editHints.AddConnection(m => m.Layout.NewsPages, p => p.NewsPageLinks);
                editHints.AddConnection(m => m.Layout.CustomerZonePages, p => p.CustomerZonePageLinks);
            }

            if (PageReference.IsNullOrEmpty(currentPage.SearchPageLink))
            {
          //      logger.Error("There is an error");
            }

            return View(model);
        }

    }
}
