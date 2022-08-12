using AlloyAdvanced.Business.ExtensionMethods;
using AlloyAdvanced.Models.Blocks;
using AlloyAdvanced.Models.Pages;
using EPiServer.Cms.TinyMce.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Framework.Localization;
using EPiServer.ServiceLocation;

namespace AlloyAdvanced.Business.Initialization
{
    [ModuleDependency(typeof(TinyMceInitialization))]
    public class ExtendedTinyMceInitialization : IConfigurableModule
    {
        public void Initialize(InitializationEngine context)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Services.Configure<TinyMceConfiguration>(config =>
            {
                config.Default().OutputToDebug("default before");

                //   ServiceLocator.Current.GetInstance<LocalizationService>().GetString("");
                // Add content CSS to the default settings.
                config.Default()
                    .ContentCss("/static/css/editor.css", "/static/css/site.css");


                // This will clone the default settings object and extend it by
                // limiting the block formats for the MainBody property of an ArticlePage.
                config.For<ArticlePage>(t => t.MainBody)
                    .BlockFormats("Paragraph=p;Header 1=h1;Header 2=h2;Header 3=h3");

                // Passing a second argument to For<> will clone the given settings object
                // instead of the default one and extend it with some basic toolbar commands.

                config.For<EditorialBlock>(t => t.MainBody, config.Empty())
                    .AddEpiserverSupport()
                    .DisableMenubar()
                    .Toolbar("bold italic underline strikethrough");

                /*  var defaultSettings = config.Default();
                  defaultSettings.Toolbar("bold italic underline");
                  var settings = config.For<ProductPage>(x=>x.MainBody);
                  settings.Toolbar("bold underline");*/
            });
        }
    }
}
