using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Analytics.Data;
using Sitecore.Analytics.Data.DataAccess.DataSets;
using Sitecore.Configuration;
using Sitecore.Data.Items;

namespace Sitecore.ContentTracker.Providers
{
    public static class ContentTrackingManager
    {
        private static ProviderHelper<ContentTrackingProvider, ContentTrackingProviderCollection> _providerHelper;
        static ContentTrackingManager()
        {
            _providerHelper = new ProviderHelper<ContentTrackingProvider, ContentTrackingProviderCollection>("contentTrackingManager");
        }
        public static ContentTrackingProvider Provider
        {
            get
            {
                return _providerHelper.Provider;
            }
        }
        public static ContentTrackingProviderCollection Providers
        {
            get
            {
                return _providerHelper.Providers;
            }
        }

        public static void ApplyTracking(Item item)
        {
            Provider.ApplyTracking(item);
        }
    }
}
