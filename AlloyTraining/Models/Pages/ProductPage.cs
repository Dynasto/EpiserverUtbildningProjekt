using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;
using AlloyTraining.Business.SelectionFactories;
using System.Collections.Generic;
using EPiServer.Shell.ObjectEditing;

namespace AlloyTraining.Models.Pages
{
    [ContentType(DisplayName = "Product", GUID = "21e84aef-6a57-4bd1-b77a-efa54c51c75f", Description = "Pick a product", GroupName =SiteGroupNames.Specialized)]
    [SiteImageUrl]
    public class ProductPage : StandardPage
    {
        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            Theme = "tjosan";
        }

        [SelectOne(SelectionFactoryType =typeof(ThemeSelectionFactory))]
        [Display(
            Name = "UniqueSellingPointsDinMamma",
            GroupName = SystemTabNames.Content,
            Order = 310)]
        public virtual string Theme { get; set; }

        [CultureSpecific]
        [Display(
            Name = "UniqueSellingPointsDinMamma",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 320)]
        [Required]
        public virtual IList<string> UniqueSellingPointsDinMamma { get; set; }

        [Display(
            Name = "Main Content Area",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 330)]
        public virtual ContentArea MainContentAreaProduct { get; set; }

        [Display(
            Name = "Related Main Content Area",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 340)]
        public virtual ContentArea RelatedMainContentAreaProduct { get; set; }
    }
}