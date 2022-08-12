using AlloyTraining.Models.Pages;
using EPiServer.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlloyTraining.Models.ViewModels
{
    public class SearchPageViewModel : DefaultPageViewModel<SearchPage>
    {
        public string SearchText { get; set; }
        public SearchResults Results { get; set; }

        public SearchPageViewModel(SearchPage spage) : base(spage)
        {

        }
    }
}