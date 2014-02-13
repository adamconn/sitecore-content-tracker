using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Analytics.Data;
using Sitecore.Data.Items;

namespace Sitecore.ContentTracker.Providers
{
    public class ContentTrackingProvider : ProviderBase
    {
        public virtual void ApplyTracking(Item item)
        {
            if (item == null)
            {
                return;
            }
            var processor = new TrackingFieldProcessor();
            processor.Process(item);
        }
    }
}
