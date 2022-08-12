using AlloyAdvanced.Business.ExtensionMethods;
using EPiServer.Cms.TinyMce.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using System;
using System.Linq;

namespace AlloyAdvanced.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(ExtendedTinyMceInitialization))]
    public class TinyMceStylesInitialization : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Services.Configure<TinyMceConfiguration>(config =>
            {
                var settings = config.Default();

                settings.InsertTool("styleselect", "formatselect");

                settings.StyleFormats(new
                {
                    title = "Red text",
                    inline = "span",
                    styles = new { color = "#ff0000" }
                },
                new
                {
                    title = "Awesome numbering",
                    selector = "ol",
                    classes = "awesome-numbering"
                },
                new
                {
                    title = "Roman numbering",
                    selector = "ol",
                    classes = "roman-numbering"
                });
            });
        }

        public void Initialize(InitializationEngine context)
        {
            //Add initialization logic, this method is called once after CMS has been initialized
        }

        public void Uninitialize(InitializationEngine context)
        {
            //Add uninitialization logic
        }
    }
}