using AlloyTraining.Models.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlloyTraining.Models.ViewModels
{
    public class TeaserBlockViewModel
    {
        public TeaserBlock CurrentBlock  { get; set; }
        public int TodaysVisitorCount { get; set; }
    }
}