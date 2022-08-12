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
    [TemplateDescriptor(
        Default = true, 
        Inherited = true, 
        Tags = new[] { SiteTagsHejsan.Full }, 
        AvailableWithoutTag = true)]
    public class AllPagesFullPartialController : PartialContentController<SitePageData>
    {
        public override ActionResult Index(SitePageData currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            var vm = new DefaultPageViewModel<SitePageData>(currentPage);
            return PartialView(SiteTagsHejsan.Full, vm);
        }
    }
    [TemplateDescriptor(
        Inherited = true, 
        Tags = new[] { SiteTagsHejsan.Wide }, 
        AvailableWithoutTag = false)]
    public class AllPagesWidePartialController : PartialContentController<SitePageData>
    {
        public override ActionResult Index(SitePageData currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            var vm = new DefaultPageViewModel<SitePageData>(currentPage);
            return PartialView(SiteTagsHejsan.Wide, vm);
        }
    }
    [TemplateDescriptor(
        Inherited = true, 
        Tags = new[] { SiteTagsHejsan.Narrow }, 
        AvailableWithoutTag = false)]
    public class AllPagesNarrowPartialController : PartialContentController<SitePageData>
    {
        public override ActionResult Index(SitePageData currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            var vm = new DefaultPageViewModel<SitePageData>(currentPage);
            return PartialView(SiteTagsHejsan.Narrow, vm);
        }
    }
}