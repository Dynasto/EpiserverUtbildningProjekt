using AlloyAdvanced.Models.Pages;
using AlloyAdvanced.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Core.Internal;
using EPiServer.Framework.DataAnnotations;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AlloyAdvanced.Controllers
{
    public class ShippersPageController : PageController<ShippersPage>
    {
        private readonly IContentLoader conLoader;

        public ShippersPageController(IContentLoader conloadmini)
        {
            conLoader = conloadmini;
        }
        public ShippersPageController()
        {
            conLoader= ServiceLocator.Current.GetInstance<IContentLoader>();
        }
        public ActionResult Index(ShippersPage currentPage)
        {
            var vm = new ShippersPageViewModel(currentPage);
            vm.Shippers = conLoader.GetChildren<ShipperPage>(currentPage.ContentLink);
            return View(vm);
        }
    }
}