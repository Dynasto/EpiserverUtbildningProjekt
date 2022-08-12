using AlloyTraining.Models;
using AlloyTraining.Models.Pages;
using AlloyTraining.Models.Pages;
using EPiServer;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace AlloyTraining.Features.DeleteContent
{
    [ContentType(DisplayName = "Delete Content",
        GUID = "0f01522d-fa66-4dff-92f3-e395f2ed4f36",
        Description = "Use this to soft or hard delete content.")]
    [AvailableContentTypes(IncludeOn = new[] { typeof(StartPage) })]
    public class DeleteContentPage : SitePageData
    {
    }
}