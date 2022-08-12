using EPiServer.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlloyTraining
{
    public class SiteImageUrlAttribute : ImageUrlAttribute
    {
        public SiteImageUrlAttribute() : base("~/Static/contenticons/epi-edu-icon.jpg")
        {

        }

        public SiteImageUrlAttribute(string path) : base(path)
        {

        }
    }

    public class SitePageIconAttribute : ImageUrlAttribute
    {
        public SitePageIconAttribute() : base("~/Static/contenticons/epi-edu-icon-page.jpg")
        {

        }

        public SitePageIconAttribute(string path) : base(path)
        {

        }
    }
}