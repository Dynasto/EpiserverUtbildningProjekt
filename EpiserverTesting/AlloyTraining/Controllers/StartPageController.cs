using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AlloyTraining.Models.Pages;
using EPiServer.Logging;
using EPiServer.ServiceLocation;

namespace AlloyTraining.Controllers
{
    public class StartPageController : PageControllerBase<StartPage>
    {

        //public StartPageController() : base() { }

        public StartPageController(IContentLoader pagefetcher) : base(pagefetcher)
        {
        }

        [ContentOutputCache(Duration = 1200)]
        public ActionResult Index(StartPage currentPage)
        {

            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            //Response.Cache.SetCacheability(System.Web.HttpCacheability.Public);
            //Response.Cache.SetExpires(System.DateTime.Now.AddHours(1));
            //Response.Cache.SetSlidingExpiration(true);

       

            return View(CreatePageViewModel(currentPage));
        }
    }
}