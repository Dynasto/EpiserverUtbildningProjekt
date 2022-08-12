using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using System;
using System.Linq;

namespace AlloyTraining.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class DisplayOptionsInitializationsModule : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            var options = context.Locate.Advanced.GetInstance<DisplayOptions>();

            options.Add(id: SiteTagsHejsan.Full, name: SiteTagsHejsan.Full, tag: SiteTagsHejsan.Full);
            options.Add(id: SiteTagsHejsan.Wide, name: SiteTagsHejsan.Wide, tag: SiteTagsHejsan.Wide);
            options.Add(id: SiteTagsHejsan.Narrow, name: SiteTagsHejsan.Narrow, tag: SiteTagsHejsan.Narrow);
        }

        public void Uninitialize(InitializationEngine context)
        {
            //Add uninitialization logic
        }
    }
}