using EPiServer.Shell.ObjectEditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlloyAdvanced.Business.Selectors
{
    public class SelectOneEnumAttribute : SelectOneAttribute, IMetadataAware
    {
        public SelectOneEnumAttribute(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("enum");
            }
            this.EnumType = enumType;
                

        }

        public Type EnumType { get; set; }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            this.SelectionFactoryType = typeof(EnumSelectionFactory<>)
                .MakeGenericType(this.EnumType);
            base.OnMetadataCreated(metadata);
        }
    }
}