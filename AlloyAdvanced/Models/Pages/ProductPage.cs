using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AlloyAdvanced.Models.Blocks;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using AlloyAdvanced.Models.Properties;
using System;

namespace AlloyAdvanced.Models.Pages
{
    /// <summary>
    /// Used to present a single product
    /// </summary>
    [SiteContentType(
        GUID = "17583DCD-3C11-49DD-A66D-0DEF0DD601FC",
        GroupName = Global.GroupNames.Products)]
    [SiteImageUrl(Global.StaticGraphicsFolderPath + "page-type-thumbnail-product.png")]
    [AvailableContentTypes(
        Availability = Availability.Specific,
        IncludeOn = new[] { typeof(StartPage) })]
    public class ProductPage : StandardPage, IHasRelatedContent
    {
        [Required]
        [Display(Order = 305)]
        [UIHint(Global.SiteUIHints.StringsCollection)]
        [CultureSpecific]
        public virtual IList<string> UniqueSellingPoints { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 330)]
        [CultureSpecific]
        [AllowedTypes(new[] { typeof(IContentData) },new[] { typeof(JumbotronBlock) })]
        public virtual ContentArea RelatedContentArea { get; set; }

        [Display(GroupName = SystemTabNames.Content, Order = 340, Name = "Last updated")]
        [UIHint(Global.SiteUIHints.DateOnly)]
        public virtual DateTime? LastUpdated { get; set; }
    }
}
