using AlloyAdvanced.Models.Pages;
using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlloyAdvanced.Models.ViewModels
{
    public class ShippersPageViewModel : IPageViewModel<ShippersPage>
    {
        public ShippersPageViewModel(ShippersPage cpage)
        {
            CurrentPage = cpage;
        }

        public ShippersPage CurrentPage { get; set; }

        public LayoutModel Layout { get; set; }
        public IContent Section { get; set; }

        public IEnumerable<ShipperPage> Shippers { get; set; }
    }
}