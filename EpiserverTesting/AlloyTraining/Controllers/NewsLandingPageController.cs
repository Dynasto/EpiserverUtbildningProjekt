using AlloyTraining.Models.Pages;
using AlloyTraining.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AlloyTraining.Controllers
{
    public class NewsLandingPageController : PageController<NewsLandingPage>
    {
        public ActionResult Index(NewsLandingPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            var vm = new DefaultPageViewModel<NewsLandingPage>(currentPage);
            return View(vm);
        }
    }
}