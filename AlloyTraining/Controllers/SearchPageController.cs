using AlloyTraining.Business.ExtensionMethods;
using AlloyTraining.Models.Pages;
using AlloyTraining.Models.ViewModels;
using EPiServer.Web.Mvc;
using System.Web.Mvc;

namespace AlloyTraining.Controllers
{
    public class SearchPageController : PageController<SearchPage>
    {
        public ActionResult Index(SearchPage currentPage, string searchText)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            var vm = new SearchPageViewModel(currentPage);

            if (string.IsNullOrEmpty(searchText) == false)
            {
                vm.SearchText = searchText;
                vm.Results = searchText.Search();
            }

            return View(vm);
        }
    }
}