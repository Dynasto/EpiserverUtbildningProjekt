using System.Web;
using System.Web.Mvc;
using EPiServer.Core;
using AlloyAdvanced.Helpers;
using AlloyAdvanced.Models.Blocks;
using AlloyAdvanced.Models.Pages;
using AlloyAdvanced.Models.ViewModels;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EPiServer;
using EPiServer.ServiceLocation;
using EPiServer.PlugIn;
using System.Web.Configuration;
using System.Configuration;

namespace AlloyAdvanced.Controllers
{
    [Authorize(Roles = "CmsAdmins")]
    [GuiPlugIn(Area = PlugInArea.AdminMenu, Url = "~/appsettings", DisplayName = "App Setting Hejsan")]
    public class AppSettingsController : Controller
    {
        private const string dvKey = "EPi.DebugView.Enabled";
        private const string wsKey = "EPi.WebSockets.Enabled";


        public ActionResult Index(string save, string webSockets, string debugView)
        {
            if (string.IsNullOrWhiteSpace(save) == false)
            {
                var config = WebConfigurationManager.OpenWebConfiguration("/");

                AddOrUpdateSetting(config.AppSettings.Settings, dvKey, debugView);
                AddOrUpdateSetting(config.AppSettings.Settings, wsKey, webSockets);
            }

                var model = new AppSettingsViewModel
                {
                    Choices = new[] {
                        new SelectListItem { Text = "true", Value = "true" },
                        new SelectListItem { Text = "false", Value = "false" },
                    },
                    DebugView = WebConfigurationManager.AppSettings.Get(dvKey) ?? "false",
                    Websockets = WebConfigurationManager.AppSettings.Get(wsKey) ?? "true"
                };

                return View(model);
        }

        void AddOrUpdateSetting(KeyValueConfigurationCollection settings, string key, string value)
        {
            var existing = settings[key];
            if (existing == null)
            {
                settings.Add(key, value);
            }
            else
            {
                existing.Value = value;
            }
        }
    }
}
