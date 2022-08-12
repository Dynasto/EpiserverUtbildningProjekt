using AlloyAdvanced.Controllers;
using EPiServer.Data.Dynamic;
using System.Linq;
using System.Web.Mvc;

namespace AlloyAdvanced.Features.SecurityLog
{
    public class SecurityLogPageController : PageControllerBase<SecurityLogPage>
    {
        private DynamicDataStore store = DynamicDataStoreFactory.Instance
               .CreateStore("SecurityLogEntry", typeof(SecurityLogEntry));

        public ActionResult Index(SecurityLogPage currentPage)
        {
            var model = new SecurityLogPageViewModel
            {
                CurrentPage = currentPage,
            };

            var logEntries = store.Items<SecurityLogEntry>()
                .OrderByDescending(log => log.Modified);

            model.Entries = logEntries.Take(50).ToArray();

            return View("~/Features/SecurityLog/SecurityLog.cshtml", model);
        }
    }
}