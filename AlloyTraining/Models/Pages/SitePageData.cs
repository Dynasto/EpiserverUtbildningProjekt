using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace AlloyTraining.Models.Pages
{
    public abstract class SitePageData : PageData
    {
        public SitePageData()
        {

        }

        [CultureSpecific]
        [Display(Name = "MetaTitleHejsan",
            GroupName = SiteTabNames.SEO,
            Order = 10)]
        [StringLength(60, MinimumLength = 5)]
        public virtual string MetaTitleHejsan { get; set; }

        [CultureSpecific]
        [Display(Name = "MetaKeywordsTjosan",
            GroupName = SiteTabNames.SEO,
            Order = 20)]
        public virtual string MetaKeywordsTjosan { get; set; }

        [UIHint(UIHint.Textarea)]
        [CultureSpecific]
        [Display(Name = "MetaDescriptionMojs",
            GroupName = SiteTabNames.SEO,
            Order = 30)]
        public virtual string MetaDescriptionMojs { get; set; }

        [AllowedTypes(AllowedTypes = new[] { typeof(ImageData) })]
        [UIHint(UIHint.Image)]
        [Display(Name = "PageImageBild",
            GroupName = "Content",
            Order = 40)]
        public virtual ContentReference PageImageBild { get; set; }

        [UIHint(UIHint.Textarea)]
        [CultureSpecific]
        [Display(Name = "TeaserTextBlaBla",
            GroupName = "Content",
            Order = 50)]
        public virtual string TeaserTextBlaBla { get; set; }
    }
}