using AlloyTraining.Models.Pages;
using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlloyTraining.Models.ViewModels
{
    public class PreviewPageViewModel : DefaultPageViewModel<SitePageData>
    {
        public ContentArea PreviewArea { get; set; }
        public PreviewPageViewModel(SitePageData currentPage, IContent content) : base(currentPage)
        {
            this.PreviewArea = new ContentArea();
            this.PreviewArea.Items.Add(new ContentAreaItem
            {
                ContentLink = content.ContentLink
            });
        }
    }
}