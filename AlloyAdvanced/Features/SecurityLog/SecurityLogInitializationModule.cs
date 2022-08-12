using EPiServer;
using EPiServer.Core;
using EPiServer.Data;
using EPiServer.Data.Dynamic;
using EPiServer.DataAbstraction;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using System;
using System.Linq;
using System.Web;

namespace AlloyAdvanced.Features.SecurityLog
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class SecurityLogInitializationModule : IInitializableModule
    {
        private bool initialized = false;
        private IContentSecurityRepository contentSecurityRepository;
        private IContentLoader contentLoader;

        public void Initialize(InitializationEngine context)
        {
            if (!initialized)
            {
                contentLoader = context.Locate.Advanced.GetInstance<IContentLoader>();
                contentSecurityRepository = context.Locate.Advanced.GetInstance<IContentSecurityRepository>();
                contentSecurityRepository.ContentSecuritySaving += ContentSecurityRepository_ContentSecuritySaving;
                initialized = true;
            }
        }

        private void ContentSecurityRepository_ContentSecuritySaving(object sender, ContentSecurityCancellableEventArgs e)
        {
            var entry = new SecurityLogEntry
            {
                Id = Identity.NewIdentity(Guid.NewGuid()),
                ContentLink = e.ContentLink,
                ContentName = contentLoader.Get<IContent>(e.ContentLink).Name,
                SecuritySaveType = e.SecuritySaveType,
                Entries = e.ContentSecurityDescriptor.Entries.Select(ace => ACE.ConvertFrom(ace)).ToArray(),
                IsInherited = e.ContentSecurityDescriptor.IsInherited,
                ModifiedBy = HttpContext.Current.User.Identity.Name,
                Modified = DateTime.Now
            };

            DynamicDataStore store = DynamicDataStoreFactory.Instance
                .CreateStore("SecurityLogEntry", typeof(SecurityLogEntry));

            store.Save(entry);
        }

        public void Uninitialize(InitializationEngine context)
        {
            contentSecurityRepository.ContentSecuritySaving -= ContentSecurityRepository_ContentSecuritySaving;
        }
    }
}