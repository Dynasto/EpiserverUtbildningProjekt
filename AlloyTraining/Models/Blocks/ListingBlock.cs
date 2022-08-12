using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Blocks
{
    [ContentType(DisplayName = "Listing", GUID = "f56e9232-4fac-4eef-83f7-ccba4c62c62a", Description = "Listing block")]
    [SitePageIcon]
    public class ListingBlock : BlockData
    {

        [Display(
            Name = "Heading",
            Description = "Heading field's description",
            Order = 10)]
        public virtual string Heading{ get; set; }

        [Display(Name ="Parent", Order =20)]
        public virtual PageReference Parent { get; set; }

    }
}