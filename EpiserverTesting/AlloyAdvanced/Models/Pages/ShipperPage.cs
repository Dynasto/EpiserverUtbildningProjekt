using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;

namespace AlloyAdvanced.Models.Pages
{
    [SiteContentType(DisplayName = "ShippersPage",
        AvailableInEditMode = false,
        GUID = "edb24cf5-de85-4447-9d84-9e5a084d5493",
        Description = "Visar shipper")]
    public class ShipperPage : PageData
    {

        public virtual int ShipperId { get; set; }

        [StringLength(24)]
        public virtual string CompanyName { get; set; }

        [StringLength(24)]
        public virtual string Phone { get; set; }

        public virtual string CostPerUnit { get; set; }

    }
}