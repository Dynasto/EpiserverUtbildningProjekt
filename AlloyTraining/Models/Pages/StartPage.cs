using AlloyTraining.Models.Properties;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.SpecializedProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Pages
{
    [ContentType(DisplayName = "StartPage",
        GUID = "77bd650e-d6a9-402b-b34e-17bd4a7ecd21",
        Description = "Startsidan",
        GroupName = SiteGroupNames.Specialized,
        Order = 10)]
    [SitePageIcon()]
    public class StartPage : SitePageData
    {
        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "The Heading",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual XhtmlString MainBody { get; set; }

        [CultureSpecific]
        [Display(
            Name = "FooterText",
            GroupName = SiteTabNames.SiteSettings,
            Order = 30)]
        public virtual string FooterText { get; set; }

        [ListItems(3)]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<PersonClass>))]
        public virtual IList<PersonClass> PeopleProperty { get; set; }
        /*
        [CultureSpecific]
        [Display(Name = "Main Content Area",
            Order = 40,
            Description = "Huvudarean",
            GroupName = SystemTabNames.Content)]
        [AllowedTypes(AllowedTypes = new[] { typeof(StandardPage), typeof(BlockData), typeof(ImageData) })]
        public virtual ContentArea MainContentArea { get; set; }*/

        [CultureSpecific]
        [Display(Name = "Main Content Area",
            Order = 40,
            Description = "Huvudarean",
            GroupName = SystemTabNames.Content)]
        [AllowedTypes(AllowedTypes = new[] { typeof(StandardPage), typeof(BlockData), typeof(ImageData),typeof(ContentFolder) })]
        public virtual ContentArea MainContentArea2 { get; set; }
    }
}