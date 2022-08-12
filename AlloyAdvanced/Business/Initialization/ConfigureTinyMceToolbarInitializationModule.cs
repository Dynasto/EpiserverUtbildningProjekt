using AlloyAdvanced.Models.Pages;
using EPiServer.Cms.TinyMce.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using System;
using System.Linq;

namespace AlloyAdvanced.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(TinyMceInitialization))]
    public class ConfigureTinyMceToolbarInitializationModule : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
                return;
            context.Services.Configure<TinyMceConfiguration>(config =>
            {
                //config.Default().ContentCss("/static/css/editor.css");

                var settings = config.For<ProductPage>(page => page.MainBody, config.Empty());
                settings.DisableMenubar()
                    .AddPlugin("image charmap emoticons paste epi-link epi-image-editor epi-personalized-content fullscreen")
                    .Toolbar("formatselect | bold italic | epi-link image epi-image-editor epi-personalized-content | outdent indent | charmap emoticons paste removeformat | fullscreen")
                    .AddSetting("charmap_append",
                    new[] {
                        new object[] { 9861, "Dice Member 6" },
                        new object[] { 9925, "Sun behind cloud" }
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