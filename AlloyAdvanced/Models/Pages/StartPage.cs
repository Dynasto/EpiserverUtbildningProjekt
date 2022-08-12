using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using AlloyAdvanced.Models.Blocks;
using System;
using AlloyAdvanced.Business.Validation;
using System.Collections.Generic;
using EPiServer;
using EPiServer.Web;

namespace AlloyAdvanced.Models.Pages
{
    /// <summary>
    /// Used for the site's start page and also acts as a container for site settings
    /// </summary>
    [ContentType(
        GUID = "19671657-B684-4D95-A61F-8DD4FE60D559",
        GroupName = Global.GroupNames.Specialized)]
    [SiteImageUrl]
    [AvailableContentTypes(
        Availability.Specific,
        Include = new[] { typeof(ContainerPage), typeof(ProductPage), typeof(StandardPage), typeof(ISearchPage), typeof(LandingPage), typeof(ContentFolder) }, // Pages we can create under the start page...
        ExcludeOn = new[] { typeof(ContainerPage), typeof(ProductPage), typeof(StandardPage), typeof(ISearchPage), typeof(LandingPage) })] // ...and underneath those we can't create additional start pages
    public class StartPage : SitePageData
    {
        [AllowedTypes(typeof(ShippersPage))]
        public virtual ContentReference Shippers { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 320)]
        [CultureSpecific]
        public virtual ContentArea MainContentArea { get; set; }

        [Display(GroupName = Global.GroupNames.SiteSettings, Order = 300)]
        public virtual LinkItemCollection ProductPageLinks { get; set; }

        [Display(GroupName = Global.GroupNames.SiteSettings, Order = 350)]
        public virtual LinkItemCollection CompanyInformationPageLinks { get; set; }

        [Display(GroupName = Global.GroupNames.SiteSettings, Order = 400)]
        public virtual LinkItemCollection NewsPageLinks { get; set; }

        [Display(GroupName = Global.GroupNames.SiteSettings, Order = 450)]
        public virtual LinkItemCollection CustomerZonePageLinks { get; set; }

        [Display(GroupName = Global.GroupNames.SiteSettings)]
        public virtual PageReference GlobalNewsPageLink { get; set; }

        [Display(GroupName = Global.GroupNames.SiteSettings)]
        public virtual PageReference ContactsPageLink { get; set; }

        [Display(GroupName = Global.GroupNames.SiteSettings)]
        public virtual PageReference SearchPageLink { get; set; }

        [Display(GroupName = Global.GroupNames.SiteSettings)]
        public virtual SiteLogotypeBlock SiteLogotype { get; set; }

        [StrongPassword(MinimumTotalCharacters = 2, MinimumDigitCharacters = 1, MinimumUppercaseCharacters = 0, MinimumLowercaseCharacters = 0)]
        public virtual string Password { get; set; }

        public virtual DateTime? StartDate { get; set; }

        public virtual DateTime? EndDate { get; set; }

        [Display(GroupName = "Events")]
        [AllowedTypes(new[] { typeof(EventBlock) })]
        public virtual ContentArea EventListAsContentArea { get; set; }

        [Display(GroupName = "Events")]
        [AllowedTypes(new[] { typeof(EventBlock) })]
        public virtual IEnumerable<ContentReference> EventListAsListOfContentReferences { get; set; }

        [Display(GroupName = "Events")]
        [AllowedTypes(new[] { typeof(ContentFolder) })]
        public virtual ContentReference EventListAsReferenceToAssetsFolder { get; set; }

        [Display(Name ="Normal text box")]
        public virtual string NormalTextBox { get; set; }

        [Display(Name = "Bigger text box")]
        [UIHint(Global.SiteUIHints.Embiggen)]
        public virtual string BiggerTextBox { get; set; }

        public virtual XhtmlString MyBody{ get; set; }

        //public virtual IContentLoader contentLoader { get; set; }

        //public StartPage(IContentLoader cload)
        //{
        //    //var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
        //    //var item = contentLoader.Get<EventBlock>(tempEvent);
        //    contentLoader = cload;
        //}
        //ContentAssetFolder
    }
}
