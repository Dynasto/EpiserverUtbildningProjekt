using EPiServer.ChangeLog;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Filters;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static AlloyAdvanced.Global;

namespace AlloyAdvanced.Business.EditorDescriptors
{
    [EditorDescriptorRegistration(TargetType = typeof(PageReference))]
    [EditorDescriptorRegistration(TargetType = typeof(CategoryList))]
    [EditorDescriptorRegistration(TargetType = typeof(int))]
    [EditorDescriptorRegistration(TargetType = typeof(int?))]
    [EditorDescriptorRegistration(TargetType = typeof(FilterSortOrder))]
    [EditorDescriptorRegistration(TargetType = typeof(object))]
    [EditorDescriptorRegistration(TargetType = typeof(ISelectionFactory))]
    public class ChangeTabsEditorDescriptor : EditorDescriptor
    {
        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            if (metadata.PropertyName == SystemPropertyNames.SortIndex || 
                metadata.PropertyName == "SortIndex" ||
                metadata.PropertyName == "ChildSortOrder" ||
                metadata.PropertyName == "PageChildOrderRule")
            {
                metadata.GroupName = SystemTabNames.Content;
            }

            base.ModifyMetadata(metadata, attributes);
        }
    }
}