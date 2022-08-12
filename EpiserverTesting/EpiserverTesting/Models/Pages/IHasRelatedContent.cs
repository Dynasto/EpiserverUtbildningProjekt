using EPiServer.Core;

namespace EpiserverTesting.Models.Pages
{
    public interface IHasRelatedContent
    {
        ContentArea RelatedContentArea { get; }
    }
}
