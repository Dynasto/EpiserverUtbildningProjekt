using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace AlloyAdvanced.Models.Blocks
{
    [ContentType(DisplayName = "EventBlock", GUID = "f03bac9a-81c3-490b-a67e-8e11e27c53fd", Description = "")]
    public class EventBlock : BlockData
    {
        public virtual string Title { get; set; }
        public virtual string When { get; set; }
        public virtual string Where { get; set; }
        public virtual string Description { get; set; }
    }
}