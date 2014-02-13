using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;

namespace Sitecore.ContentTracker.Rules.Actions
{
    public class ApplyTrackingFromParent<T> : BaseApplyTrackingAction<T> where T : TrackingRuleContext
    {
        protected override IEnumerable<Item> GetSourceItems(T ruleContext)
        {
            Assert.ArgumentNotNull(ruleContext, "ruleContext");
            Assert.ArgumentNotNull(ruleContext.Item, "ruleContext.Item");
            Assert.ArgumentNotNull(ruleContext.Item.Parent, "ruleContext.Item.Parent");
            var parent = ruleContext.Item.Parent;
            if (parent == null)
            {
                return null;
            }
            return new Item[] {ruleContext.Item.Parent};
        }
    }
}
