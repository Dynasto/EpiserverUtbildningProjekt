using AlloyTraining.Business.ExtensionMethods;
using AlloyTraining.Models.Pages;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlloyTraining.Models.ViewModels
{
    public class DefaultPageViewModel<T> : IPageViewModel<T> where T : SitePageData
    {
        public T CurrentPage { get; set; }

        public StartPage StartPage { get; set; }

        public IEnumerable<SitePageData> MenuPAges { get; set; }

        public IContent Section { get; set; }

        public string FooterText { get; set; }

        public DefaultPageViewModel()
        {

        }

        public DefaultPageViewModel(T page)
        {
            var loader = ServiceLocator.Current.GetInstance<EPiServer.IContentLoader>();
            var startPage = loader.Get<SitePageData>(ContentReference.StartPage);

            CurrentPage = page;
            StartPage = loader.Get<StartPage>(ContentReference.StartPage);
            MenuPAges = FilterForVisitor.Filter(loader.GetChildren<SitePageData>(ContentReference.StartPage))
                                        .Cast<SitePageData>()
                                        .Where(x => x.VisibleInMenu);
            Section = page.ContentLink.GetSection();
            FooterText = page.ContentLink.GetFooter();
        }

        public static DefaultPageViewModel<T> Create<T>(T page) where T : SitePageData
        {
            return new DefaultPageViewModel<T>();
        }
    }
}