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
    public class TinyMceTablesInitialization : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Services.Configure<TinyMceConfiguration>(config =>
            {
                TinyMceSettings defaultSettings = config.Default();

                // Add table plugin and insert tool after link tool.
                defaultSettings
                    .AddPlugin("table")
                    .InsertTool("table", after: "epi-link");

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