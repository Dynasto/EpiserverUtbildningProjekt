using AlloyTraining.Models.Blocks;
using AlloyTraining.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlloyTraining.Controllers
{
    public class ListingBlockController : BlockController<ListingBlock>
    {
        public IContentLoader loader { get; set; }
        
        public ListingBlockController(IContentLoader contentLoader)
        {
            loader = contentLoader;
        }

        public override ActionResult Index(ListingBlock currentBlock)
        {
            var vm = new ListingBlockViewModel
            {
                Heading = currentBlock.Heading
            };

            if (!PageReference.IsNullOrEmpty(currentBlock.Parent))
            {
                //var loader = ServiceLocator.Current.GetInstance<IContentLoader>();

                var children = loader.GetChildren<PageData>(currentBlock.Parent);
                var filteredChildren = FilterForVisitor.Filter(children);

                vm.pAGES = filteredChildren.Cast<PageData>();
            }
            else
            {
                vm.pAGES = null;
            }

            return PartialView(vm);
        }
    }
}
