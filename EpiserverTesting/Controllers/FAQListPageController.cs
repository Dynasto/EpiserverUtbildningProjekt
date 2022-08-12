using EPiServer;
using EPiServer.Core.Internal;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EpiserverTesting.Models.Pages;
using EpiserverTesting.Models.ViewModels;
using System.Web.Mvc;

namespace EpiserverTesting.Controllers
{
    public class FAQListPageController : PageController<FAQListPage>
    {
        public ActionResult Index(FAQListPage currentPage)
        {
            var loader = ServiceLocator.Current.GetInstance<ContentLoader>();
            var vm = PageViewModel.Create(currentPage);
            var faqs = loader.GetChildren<FAQItemPage>(currentPage.ContentLink);

            vm.CurrentPage.FAQItems = faqs;

            return View(vm);
        }

        public ActionResult CreateFAQItem(FAQListPage page, string question)
        {
            var repo = ServiceLocator.Current.GetInstance<IContentRepository>();
            var faqItem = repo.GetDefault<FAQItemPage>(page.ContentLink);
            faqItem.Question = new EPiServer.Core.XhtmlString(question);
            faqItem.Name = "Q. " + question;
            repo.Save(faqItem, EPiServer.DataAccess.SaveAction.CheckOut, EPiServer.Security.AccessLevel.Read);
            return RedirectToAction("Index");
        }
    }
}