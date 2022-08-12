using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Core;

namespace AlloyTraining.Models.ViewModels
{
    public class ContentFolderViewModel
    {
        public ContentFolder CurrentFolderViewModel { get; set; }
        public int ItemsCountViewModel{ get; set; }
    }
}