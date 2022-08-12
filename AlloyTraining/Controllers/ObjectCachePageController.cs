using AlloyTraining.Models.Pages;
using AlloyTraining.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AlloyTraining.Controllers
{
    public class ObjectCachePageController : PageControllerBase<ObjectCachePage>
    {
        public ActionResult Index(ObjectCachePage currentPage, string filterBy)
        {
            var vm = new ObjectCachePageViewModel(currentPage);

            var cachedEntries = HttpContext.Cache.Cast<DictionaryEntry>();

            switch (filterBy)
            {
                case "pages": vm.CachedItems = cachedEntries.Where(x => x.Value is PageData); break;
                case "content": vm.CachedItems = cachedEntries.Where(x => x.Value is IContent); break;
                default: vm.CachedItems = cachedEntries; break;
            }

            vm.FilteredBy = filterBy;

            return View(vm);
        }
    }
}