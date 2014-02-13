using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Analytics.Data;
using Sitecore.Data.Items;
using Sitecore.Rules.Actions;
using Sitecore.ContentTracker.Providers;

namespace Sitecore.ContentTracker.Rules.Actions
{
    public abstract class BaseApplyTrackingAction<T> : RuleAction<T> where T : TrackingRuleContext
    {
        protected abstract IEnumerable<Item> GetSourceItems(T ruleContext);

        public override void Apply(T ruleContext)
        {
            var sourceItems = GetSourceItems(ruleContext);
            if (sourceItems == null || ! sourceItems.Any())
            {
                return;
            }
            //var allProfiles = new List<ContentProfile>();
            foreach (var sourceItem in sourceItems)
            {
                ContentTrackingManager.ApplyTracking(sourceItem);
                //var profiles = ContentProfilingManager.GetProfiles(sourceItem);
                //if (profiles == null)
                //{
                //    continue;
                //}
                //allProfiles.AddRange(profiles);
            }
            //ContentProfilingManager.ApplyProfiles(allProfiles, ruleContext.Visit);
        }
    }
}
