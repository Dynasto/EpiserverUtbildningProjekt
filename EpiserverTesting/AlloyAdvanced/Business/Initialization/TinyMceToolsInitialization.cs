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
    public class TinyMceToolsInitialization : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
                return;
            context.Services.Configure<TinyMceConfiguration>(config =>
            {
                var defaultSettings = config.Default();
                defaultSettings
                    .AddSetting("code_dialog_height", 400)
                    .AddSetting("code_dialog_width", 600);

                defaultSettings.AddSetting("entity_encoding", "numeric");

                defaultSettings
                    .AddPlugin("charmap emoticons")
                    .AppendToolbar("charmap emoticons | removeformat")
                    .AddSetting("charmap_append", new[]
                    {
                        new object[] { 9861, "Dice number 6" },
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