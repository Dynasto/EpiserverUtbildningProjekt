using EPiServer.Personalization.VisitorGroups;
using EPiServer.Shell.ObjectEditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlloyAdvanced.Business.Selectors
{
    public class EnumSelectionFactory<TEnum> : EPiServer.Shell.ObjectEditing.ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metaData)
        {
            var values = Enum.GetValues(typeof(TEnum));

            foreach (var value in values)
            {
                yield return new SelectItem
                {
                    Text = Enum.GetName(typeof(TEnum), value),
                    Value = value
                };
            }
        }
    }
}