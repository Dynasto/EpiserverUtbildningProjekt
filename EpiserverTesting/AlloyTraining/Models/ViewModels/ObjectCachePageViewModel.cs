using AlloyTraining.Models.Pages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlloyTraining.Models.ViewModels
{
    public class ObjectCachePageViewModel : PageViewModel<ObjectCachePage>
    {
        public IEnumerable<DictionaryEntry> CachedItems { get; set; }

        public string FilteredBy { get; set; }

        public ObjectCachePageViewModel(ObjectCachePage cpage) : base(cpage)
        {

        }
    }
}