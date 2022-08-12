using EPiServer.Cms.TinyMce.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverTesting.Business.ExtensionMethods
{
    public static class TinyMceExtensionMethods
    {
        public static TinyMceSettings InsertToolAfter(this TinyMceSettings tms, string tool, string after)
        {
            var toolbar = tms.GetNamedSetting("toolbar");

            toolbar = toolbar.Insert(toolbar.IndexOf(after) + after.Length, $"{tool}");

            return tms.Toolbar(toolbar);
        }

        public static string GetNamedSetting(this TinyMceSettings tms, string settingName)
        {
            var settingsPair = tms.SingleOrDefault(x => x.Key == settingName);

            var settingsArray = settingsPair.Value as string[];

            if (settingsArray == null || settingsArray.Length == 0) return "";
            return "";
        }
    }
}