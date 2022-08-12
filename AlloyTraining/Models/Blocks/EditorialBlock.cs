using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Blocks
{
    //[SitePageIcon]
    [ContentType(DisplayName = "Editorial", 
        GUID = "c342cc66-2eb4-45ce-9ddb-5226828db64f", Description = "Editorial Block Description")]
    public class EditorialBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Name",
            Description = "Name field's description",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString MainBody { get; set; }
    }
}