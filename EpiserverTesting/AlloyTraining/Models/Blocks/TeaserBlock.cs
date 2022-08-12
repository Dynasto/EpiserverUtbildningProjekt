using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Blocks
{
    [ContentType(DisplayName = "Teaser", GUID = "2831d444-ca0a-4212-9469-7d0f6e185108", Description = "I am a teaser. Tease me")]
    public class TeaserBlock : BlockData
    {

        [CultureSpecific]
        [Display(Name = "Heading", Order = 10, GroupName = SystemTabNames.PageHeader)]
        public virtual string TeaserHeading { get; set; }

        [CultureSpecific]
        [Display(Name = "Text", Order = 20, GroupName = SystemTabNames.PageHeader)]
        public virtual XhtmlString TeaserText { get; set; }

        [CultureSpecific]
        [Display(Name = "Image", Order = 30)]
        public virtual ContentReference TeaserImage { get; set; }

        [CultureSpecific]
        [Display(Name = "Link", Order = 40)]
        public virtual PageReference TeaserLink { get; set; }

    }
}