using AlloyTraining.Models.Blocks;
using AlloyTraining.Models.ViewModels;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using System;
using System.Web.Mvc;

namespace AlloyTraining.Controllers
{
    [TemplateDescriptor(Inherited = true, Default = true, Tags = new[] { SiteTagsHejsan.Full }, AvailableWithoutTag = true)]
    public class TeaserBlockController : BlockController<TeaserBlock>
    {
        public override ActionResult Index(TeaserBlock currentBlock)
        {
            var vm = new TeaserBlockViewModel
            {
                CurrentBlock = currentBlock,
                TodaysVisitorCount = new Random().Next(0, 100)
            };

            return PartialView(vm);
        }
    }
    [TemplateDescriptor(Inherited = true, Default = true, Tags = new[] { SiteTagsHejsan.Wide }, AvailableWithoutTag = false)]
    public class TeaserBlockWideController : BlockController<TeaserBlock>
    {
        public override ActionResult Index(TeaserBlock currentBlock)
        {
            var vm = new TeaserBlockViewModel
            {
                CurrentBlock = currentBlock,
                TodaysVisitorCount = new Random().Next(0, 100)
            };

            return PartialView(vm);
        }
    }
    [TemplateDescriptor(Inherited = true, Default = true, Tags = new[] { SiteTagsHejsan.Narrow }, AvailableWithoutTag = false)]
    public class TeaserBlockNarrowController : BlockController<TeaserBlock>
    {
        public override ActionResult Index(TeaserBlock currentBlock)
        {
            var vm = new TeaserBlockViewModel
            {
                CurrentBlock = currentBlock,
                TodaysVisitorCount = new Random().Next(0, 100)
            };

            return PartialView(vm);
        }
    }
}
