using EPiServer.Core;
using EPiServer.Data;
using EPiServer.Data.Dynamic;
using EPiServer.Security;
using System;

namespace AlloyAdvanced.Features.SecurityLog
{
    public class SecurityLogEntry : IDynamicData
    {
        public Identity Id { get; set; }
        public ContentReference ContentLink { get; set; }
        public string ContentName { get; set; }
        public bool IsInherited { get; set; }
        public DateTime Modified { get; set; }
        public string ModifiedBy { get; set; }
        public ACE[] Entries { get; set; }
        public SecuritySaveType SecuritySaveType { get; set; }
    }

    public class ACE
    {
        public string Name { get; set; }
        public AccessLevel Access { get; set; }
        public SecurityEntityType EntityType { get; set; }

        public static ACE ConvertFrom(AccessControlEntry ace)
        {
            return new ACE
            {
                Name = ace.Name,
                Access = ace.Access,
                EntityType = ace.EntityType
            };
        }
    }
}