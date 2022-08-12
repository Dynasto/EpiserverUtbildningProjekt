using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EpiserverTesting.Models.Pages
{
    [ContentType(DisplayName = "FAQ List Page", GUID = "0cf24c5e-62ad-4344-800e-587ef049b438", Description = "FAQ List Page")]
    [AvailableContentTypes(Availability = Availability.Specific
        /* ,Include = new[] { typeof(FAQItemPage) }
       ,

        IncludeOn = new[] { typeof(StartPage) }
        */
        )]
    public class FAQListPage : SitePageData
    {
        [Ignore]
        public IEnumerable<FAQItemPage> FAQItems{ get; set; }
    }
}