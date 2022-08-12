using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiserverTesting.Models.Pages
{
    [ContentType(DisplayName = "FAQ", AvailableInEditMode = false, GUID = "a47741f4-1ffd-4120-a200-7a28ad618c9e", Description = "FAQ ItemPage (Cannot be created by editors)")]
    public class FAQItemPage : PageData
    {

        [Display(Name = "Question", Order = 1)]
        public virtual XhtmlString Question { get; set; }

        [Display(Name = "Answer", Order = 2)]
        public virtual XhtmlString Answer { get; set; }

    }
}