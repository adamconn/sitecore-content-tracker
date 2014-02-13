using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Analytics;
using Sitecore.Analytics.Pipelines.StartTracking;
using Sitecore.Pipelines;
using Sitecore.ContentTracker.Pipelines.GetSourceItems;
using Sitecore.ContentTracker.Providers;

namespace Sitecore.ContentTracker.Pipelines.StartTracking
{
    public class ApplyTrackingFromPipeline : StartTrackingProcessor
    {
        public override void Process(StartTrackingArgs args)
        {
            var item = Sitecore.Context.Item;
            var args2 = new GetSourceItemsArgs(item);
            CorePipeline.Run("contentTracker.getSourceItems", args2);
            var sourceItems = args2.SourceItems;
            if (sourceItems == null)
            {
                return;
            }
            var visit = Tracker.Visitor.GetOrCreateCurrentVisit();
            foreach (var sourceItem in sourceItems)
            {
                ContentTrackingManager.ApplyTracking(sourceItem);
            }
        }
    }
}
