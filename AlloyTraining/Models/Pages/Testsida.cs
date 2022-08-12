using AlloyTraining.Models.Validation;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Pages
{
    [ContentType]
    [ImageUrl("~/Static/gfx/contact.jpg")]
    public class Testsida : SitePageData
    {
        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual XhtmlString MainBody { get; set; }

        [CultureSpecific]
        [Display(
            Name = "PageHeaderProperty",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.PageHeader,
            Order = 20)]
        public virtual string PageHeaderProperty{ get; set; }

        [CultureSpecific]
        [Display(
            Name = "rProperty",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.PageHeader,
            Order = 30)]
        public virtual XhtmlString rProperty{ get; set; }

        [UIHint(UIHint.Textarea)]
        public virtual string MyString{ get; set; }

        [Range(0,10)]
        //[errormessage]
        public virtual double MyProperty { get; set; }

        public virtual DateTime MyDate { get; set; }

        [CustomNumberValidation]
        public virtual int MyProperty2 { get; set; }

        public virtual ContentReference MyContentReference { get; set; }

        [AllowedTypes(AllowedTypes = new[] { typeof(Testsida) })]
        public virtual IList<ContentReference> MyContentReferenceList{ get; set; }
    }
}