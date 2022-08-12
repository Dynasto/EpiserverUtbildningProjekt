using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace AlloyAdvanced.Models.Blocks
{
    [ContentType(DisplayName = "PersonBlock", GUID = "fe426ab3-7991-4af7-9bae-6e062215fa89", Description = "")]
    public class PersonBlock : BlockData
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string BirthDate { get; set; }
        public virtual string Summary { get; set; }
    }
}