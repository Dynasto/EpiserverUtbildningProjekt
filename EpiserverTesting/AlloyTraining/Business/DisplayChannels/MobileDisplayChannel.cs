using EPiServer.Framework.Web;
using EPiServer.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlloyTraining.Business.DisplayChannels
{
    public class MobileDisplayChannel : DisplayChannel
    {
        public override string ChannelName => RenderingTags.Mobile;

        public override bool IsActive(HttpContextBase context)
        {
            return context.Request.Browser.IsMobileDevice;
        }

        public override string ResolutionId => "iPhone5";
    }

    public class IphoneFiveResolution : IDisplayResolution
    {
        public string Id => "iPhone5";

        public string Name => "iPhone 5";

        public int Width => 320;

        public int Height => 568;
    }

    public class IphoneFourResolution : IDisplayResolution
    {
        public string Id => "iPhone4";

        public string Name => "iPhone 4";

        public int Width => 320;

        public int Height => 480;
    }
}