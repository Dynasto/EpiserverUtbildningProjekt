using AlloyAdvanced.Models;
using AlloyAdvanced.Models.Pages;
using EPiServer.DataAnnotations;

namespace AlloyAdvanced.Features.SecurityLog
{
    [SiteContentType(DisplayName = "Security Log", 
        GroupName = Global.GroupNames.Specialized,
        Description = "View a log of access right changes.")]
    [SiteImageUrl]
    [AvailableContentTypes(IncludeOn = new[] { typeof(StartPage) })]
    public class SecurityLogPage : SitePageData
    {
    }
}