using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.ContentTracker.Providers
{
    public class ContentTrackingProviderCollection : ProviderCollection
    {
        public ContentTrackingProvider this[string name]
        {
            get
            {
                return (base[name] as ContentTrackingProvider);
            }
        }
    }
}
