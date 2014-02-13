using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Analytics;
using Sitecore.Analytics.Pipelines.StartTracking;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Rules;
using Sitecore.ContentTracker.Rules;

namespace Sitecore.ContentTracker.Pipelines.StartTracking
{
    public class ApplyTrackingFromRules : StartTrackingProcessor
    {
        public override void Process(StartTrackingArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            var item = Sitecore.Context.Item;
            if (item == null)
            {
                return;
            }
            var rules = GetProfilingRules(item);
            if (rules == null || rules.Count == 0)
            {
                return;
            }
            var visit = Tracker.Visitor.GetOrCreateCurrentVisit();
            var context = new TrackingRuleContext(item, visit);
            context.Item = item;
            rules.Run(context);
        }

        protected static readonly ID DefaultRulesFolderID = ID.Parse("{171602C1-0EFC-458A-8D09-42BF84E69D98}");
        protected virtual RuleList<TrackingRuleContext> GetProfilingRules(Item item)
        {
            Assert.ArgumentNotNull(item, "item");
            using (var context = ContentSearchManager.CreateSearchContext(new SitecoreIndexableItem(item)))
            {
                var results = context.GetQueryable<ConfigItem>()
                    .Where(i => i.Paths.Contains(DefaultRulesFolderID))
                    .Where(i => ! i.Disabled)
                    .Select(i => i.GetItem())
                    .ToArray();
                var rules = RuleFactory.GetRules<TrackingRuleContext>(results, "Rules");
                return rules;
            }
        }
    }

    public class ConfigItem : SearchResultItem
    {
        public bool Disabled { get; set; }
    }
}
