using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;

namespace AlloyAdvanced.Models.Pages
{
    [SiteContentType(DisplayName = "ShippersPage", GUID = "edb24cf5-de85-4447-9c84-9e5a084d5493", Description = "Visar shippers")]
    [AvailableContentTypes(Include = new[] { typeof(ShipperPage) },
        IncludeOn = new[] { typeof(StartPage) })]
    public class ShippersPage : SitePageData
    {
        public ShippersPage():base()
        {

        }

        [CultureSpecific]
        [Display(
            Name = "Main DefaultShipperId",
            Description = "DefaultShipperId",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual int DefaultShipperId { get; set; }

        //public  ShipperPage DefaultShipper{ get; set; }
    }
}