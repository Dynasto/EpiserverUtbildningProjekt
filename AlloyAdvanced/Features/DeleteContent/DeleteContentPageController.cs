using AlloyAdvanced.Controllers;
using AlloyAdvanced.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using System.Web.Mvc;

namespace AlloyAdvanced.Features.DeleteContent
{
    public class DeleteContentPageController : PageControllerBase<DeleteContentPage>
    {
        private readonly IContentRepository repo = null;

        public DeleteContentPageController(IContentRepository repo)
        {
            this.repo = repo;
        }
        public DeleteContentPageController()
        {
            this.repo = ServiceLocator.Current.GetInstance<IContentRepository>();
        }
        public ActionResult Index(DeleteContentPage currentPage)
        {
            var viewmodel = PageViewModel.Create(currentPage);
            return View("~/Features/DeleteContent/DeleteContentPage.cshtml", viewmodel);
        }

        [HttpPost]
        public ActionResult Delete(DeleteContentPage currentPage, 
            ContentReference contentReference, string hardDelete)
        {
            string name = repo.Get<IContent>(contentReference).Name;

            if (hardDelete == "on")
            {
                repo.Delete(contentReference, forceDelete: true, 
                    access: AccessLevel.NoAccess);

                ViewData["message"] = $"'{name}' was deleted permanently.";
            }
            else
            {
                repo.Move(contentReference, destination: ContentReference.WasteBasket,
                    requiredSourceAccess: AccessLevel.NoAccess,
                    requiredDestinationAccess: AccessLevel.NoAccess);

                ViewData["message"] = $"'{name}' was moved to trash.";
            }
            var viewmodel = PageViewModel.Create(currentPage);
            return View("~/Features/DeleteContent/DeleteContentPage.cshtml", viewmodel);
        }
    }
}