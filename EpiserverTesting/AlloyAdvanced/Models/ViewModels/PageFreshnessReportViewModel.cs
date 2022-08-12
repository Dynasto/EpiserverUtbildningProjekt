using EPiServer.DataAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlloyAdvanced.Models.ViewModels
{
    public class PageFreshnessReportViewModel
    {
        public string[] Administrators { get; set; }
        public string[] Editors{ get; set; }
        public string SelectedUser { get; set; }
        public bool ShowReport{ get; set; }
        public IEnumerable<ContentVersion> Top10FreshestPages{ get; set; }
        public IEnumerable<ContentVersion> Top10LeastFreshPages{ get; set; }
        public string HeroOfTheWeek { get; set; }
        public string HeroOfTheMonth{ get; set; }
        public string HeroOfTheYear { get; set; }
    }
}