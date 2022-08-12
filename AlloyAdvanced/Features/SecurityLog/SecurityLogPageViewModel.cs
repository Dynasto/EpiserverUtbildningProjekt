using AlloyAdvanced.Models.ViewModels;
using EPiServer.Core;

namespace AlloyAdvanced.Features.SecurityLog
{
    public class SecurityLogPageViewModel : IPageViewModel<SecurityLogPage>
    {
        public SecurityLogEntry[] Entries { get; set; }

        public SecurityLogPage CurrentPage { get; set; }
        public LayoutModel Layout { get; set; }
        public IContent Section { get; set; }
    }
}