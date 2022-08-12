using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EpiserverTesting.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Pages
{
    [SiteContentType(DisplayName = "Object caceh", Description = "visa object cachce")]
    [ContentType(DisplayName = "ObjectCachePage", GUID = "55fc533c-4542-4d54-9b14-329c68fa47e8", Description = "")]
    [AvailableContentTypes(IncludeOn = new[] { typeof(StartPage) })]
    public class ObjectCachePage : SitePageData
    {

    }
}