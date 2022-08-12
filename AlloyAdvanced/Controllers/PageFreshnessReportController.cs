using AlloyAdvanced.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Core.Internal;
using EPiServer.DataAbstraction;
using EPiServer.Framework.DataAnnotations;
using EPiServer.PlugIn;
using EPiServer.ServiceLocation;
using EPiServer.Shell.Security;
using EPiServer.Web.Mvc;
using EPiServer.Web.Mvc.Html;
using Microsoft.AspNet.Identity;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlloyAdvanced.Controllers
{
    [Authorize(Roles = "CmsAdmins,CmsEditors")]
    [GuiPlugIn(
        Area = PlugInArea.ReportMenu,
        Url ="~pagefreshnessreport",
        Category = "Training Reports tjosan",
        DisplayName = "Page Freshness Oscar"
        )]
    public class PageFreshnessReportController : Controller
    {
        public ActionResult Index(string changedBy, string showReport, string exportReport)
        {
            var roles = ServiceLocator.Current.GetInstance<UIRoleProvider>();
            var vm = new PageFreshnessReportViewModel {
                Administrators = roles.GetUsersInRole("WebAdmins").ToArray(),
                Editors = roles.GetUsersInRole("ContentEditors").ToArray(),
                SelectedUser = changedBy,
                ShowReport = !string.IsNullOrWhiteSpace(showReport)
            };

            if (vm.ShowReport || string.IsNullOrWhiteSpace(exportReport) == false)
            {
                var loader = ServiceLocator.Current.GetInstance<IContentLoader>();
                var versionRepo = ServiceLocator.Current.GetInstance<IContentVersionRepository>();

                var childRefs = loader.GetDescendents(ContentReference.StartPage).Union(new ContentReference[] { ContentReference.StartPage });

                var children = childRefs.Select(x=>versionRepo.LoadPublished(x));

                if (string.IsNullOrWhiteSpace(vm.SelectedUser) || vm.SelectedUser == "Anyone")
                {
                    vm.Top10FreshestPages = children.OrderByDescending(x => x.Saved).Take(10);
                    vm.Top10LeastFreshPages = children.OrderBy(x => x.Saved).Take(10);
                }
                else
                {
                    vm.Top10FreshestPages = children.Where(x => x.SavedBy == vm.SelectedUser).OrderByDescending(x => x.Saved).Take(10);
                    vm.Top10LeastFreshPages = children.Where(x => x.SavedBy == vm.SelectedUser).OrderBy(x => x.Saved).Take(10);
                }

                vm.HeroOfTheWeek = children
                    .Where(x => x.Saved.AddDays(7) >= System.DateTime.Now)
                    .OrderByDescending(x=>x.Saved)
                    .FirstOrDefault()?.SavedBy;

                vm.HeroOfTheWeek = children
                    .Where(x => x.Saved.AddMonths(1) >= System.DateTime.Now)
                    .OrderByDescending(x=>x.Saved)
                    .FirstOrDefault()?.SavedBy;

                vm.HeroOfTheWeek = children
                    .Where(x => x.Saved.AddYears(1) >= System.DateTime.Now)
                    .OrderByDescending(x=>x.Saved)
                    .FirstOrDefault()?.SavedBy;

                if (!string.IsNullOrWhiteSpace(exportReport))
                {
                    Export(vm, HttpContext.Response);
                }
            }

            return View(vm);
        }

        private void Export(PageFreshnessReportViewModel vm, HttpResponseBase response)
        {
            using (var package = new ExcelPackage())
            {
                AddWorksheet(package, "Top10FreshestPages", vm.Top10FreshestPages);
                AddWorksheet(package, "Top10LeastFreshPages", vm.Top10LeastFreshPages);

                response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                response.AddHeader("content-disposition", $"attachment: filename=pages{DateTime.Now.ToString("yyyyMMdd")}.xslx");

                response.BinaryWrite(package.GetAsByteArray());
                response.Flush();
                response.End();
            }
        }

        private void AddWorksheet(ExcelPackage package, string name, IEnumerable<ContentVersion> pages)
        {
            var ws = package.Workbook.Worksheets.Add(name);

            ws.Cells[1, 1].Value = "PageId";
            ws.Cells[1, 2].Value = "PageName";
            ws.Cells[1, 3].Value = "PageUrl";
            ws.Cells[1, 4].Value = "Published Date";

            ws.Row(1).Style.Font.Bold = true;
            ws.Row(1).Style.Locked = true;

            var row = 2;

            foreach (var page in pages)
            {
                ws.Cells[row, 1].Value = page.ContentLink.ID;
                ws.Cells[row, 2].Value = page.Name;
                ws.Cells[row, 3].Value = Url.ContentUrl(page.ContentLink);
                ws.Cells[row, 4].Value = page.Saved.ToString("yyyy-MM-dd HH:mm");
                row++;
            }
        }
    }
}