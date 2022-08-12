using AlloyAdvanced.Controllers;
using AlloyAdvanced.Models.ViewModels;
using EPiServer.Framework.Configuration;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using EPiServer.Shell.Security;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.Security;

namespace AlloyAdvanced.Features.SecurityViewer
{
    public class SecurityPageController : PageControllerBase<SecurityPage>
    {
        private  UIRoleProvider roles;

        public SecurityPageController(UIRoleProvider roles)
        {
            this.roles = roles;
        }
        public SecurityPageController()
        {

        }

        public ActionResult Index(SecurityPage currentPage)
        {
            if(roles == null)
            {

            roles = ServiceLocator.Current.GetInstance<UIRoleProvider>();
            }

            currentPage.SecuritySystem = new SecurityPage.System();
            currentPage.SecurityUser = new SecurityPage.User();

            // get current user security information

            var principal = PrincipalInfo.CurrentPrincipal;

            if (principal is RolePrincipal) // ASP.NET Membership
            {
                currentPage.SecuritySystem.Provider = "ASP.NET Membership";
            }
            else if (principal is ClaimsPrincipal) // ASP.NET Identity
            {
                currentPage.SecuritySystem.Provider = "ASP.NET Identity";
            }

            currentPage.SecurityUser.Claims = (principal.Identity as ClaimsIdentity).Claims.ToArray();

            currentPage.SecurityUser.Roles = currentPage.SecurityUser.Claims.Where(
                c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")
                .Select(c => c.Value).ToArray();

            currentPage.SecurityUser.Name = principal.Identity.Name;
            currentPage.SecurityUser.IsAnonymous = !principal.Identity.IsAuthenticated;
            currentPage.SecurityUser.HasAccessToPlugins = PrincipalInfo.Current.HasPathAccess("Views/Plugins");
            currentPage.SecurityUser.IsAdministrator = principal.IsInRole("CmsAdmins");
            currentPage.SecurityUser.IsEditor = principal.IsInRole("CmsEditors");

            // or use following that check access to paths /admins /edit
            currentPage.SecurityUser.IsAdministrator = PrincipalInfo.HasAdminAccess;
            currentPage.SecurityUser.IsEditor = PrincipalInfo.HasEditAccess;

            // get system security information
            currentPage.SecuritySystem.StoredRoles = roles.GetAllRoles().Select(r => r.Name).ToArray();
            ProviderSettingsCollection virtualRoles = EPiServerFrameworkSection.Instance.VirtualRoles.Providers;
            var list = new List<string>();
            foreach (var setting in virtualRoles.Cast<ProviderSettings>())
            {
                string item = setting.Name;
                if (setting.ElementInformation.Properties.Cast<PropertyInformation>().Any(pi => pi.Name == "roles"))
                {
                    item += " <-- " + setting.ElementInformation.Properties["roles"].DefaultValue;
                }
                list.Add(item);
            }
            currentPage.SecuritySystem.VirtualRoles = list.ToArray();

            // create view model
            var viewmodel = PageViewModel.Create(currentPage);
            return View("~/Features/SecurityViewer/SecurityPage.cshtml", viewmodel);
        }
    }
}