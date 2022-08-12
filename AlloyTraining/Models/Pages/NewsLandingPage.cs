using AlloyTraining.Models.Blocks;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Pages
{
    [ContentType(DisplayName = "News", GUID = "036d8ac9-82e0-4be8-86e7-ace42554aa2e", Description = "Landningssida")]
    public class NewsLandingPage : StandardPage
    {

        [Display(
            Name = "News",
            Description = "News desc.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual ListingBlock NewsListing { get; set; }

    }
}