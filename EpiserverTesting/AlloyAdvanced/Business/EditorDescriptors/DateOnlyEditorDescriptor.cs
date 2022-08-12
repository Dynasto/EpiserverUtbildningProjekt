using System;
using System.Collections.Generic;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using EPiServer.Shell.ObjectEditing;

namespace AlloyAdvanced.Business.EditorDescriptors
{
    /// <summary>
    /// Register an editor for StringList properties
    /// </summary>
    [EditorDescriptorRegistration(TargetType = typeof(DateTime?),
        UIHint = Global.SiteUIHints.DateOnly)]
    [EditorDescriptorRegistration(TargetType = typeof(DateTime),
        UIHint = Global.SiteUIHints.DateOnly)]
    public class DateOnlyEditorDescriptor : EditorDescriptor
    {
        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            ClientEditingClass = "dijit/form/DateTextBox";

            base.ModifyMetadata(metadata, attributes);
        }
    }
}
