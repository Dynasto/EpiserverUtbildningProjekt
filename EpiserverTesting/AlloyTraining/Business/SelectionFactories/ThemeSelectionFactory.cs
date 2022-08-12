using EPiServer.Shell.ObjectEditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlloyTraining.Business.SelectionFactories
{
    public class ThemeSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new List<SelectItem>() {
                new SelectItem(){ Text="theme1", Value="theme1"},
                new SelectItem(){ Text="theme2", Value="theme2"},
                new SelectItem(){ Text="theme3", Value="theme3"},
            };
        }
    }
}