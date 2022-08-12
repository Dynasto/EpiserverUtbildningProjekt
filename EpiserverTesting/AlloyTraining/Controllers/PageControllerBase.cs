using AlloyTraining.Business.ExtensionMethods;
using AlloyTraining.Models.Pages;
using AlloyTraining.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AlloyTraining.Controllers
{
    public abstract class PageControllerBase<T> : PageController<T> where T : SitePageData
    {
        protected readonly IContentLoader loader;

        public PageControllerBase()
        {
        }
        public PageControllerBase(IContentLoader loader)
        {
            this.loader = loader;
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        protected IPageViewModel<TPage> CreatePageViewModel<TPage>(TPage currentpage) where TPage : SitePageData
        {
            return new DefaultPageViewModel<TPage>
            {
                CurrentPage = currentpage,
                StartPage = loader.Get<StartPage>(ContentReference.StartPage),
                MenuPAges = FilterForVisitor.Filter(loader.GetChildren<SitePageData>(ContentReference.StartPage))
                                            .Cast<SitePageData>()
                                            .Where(x=>x.VisibleInMenu),
                Section = currentpage.ContentLink.GetSection(),
                FooterText = currentpage.ContentLink.GetFooter(),
            };
        }
    }
}