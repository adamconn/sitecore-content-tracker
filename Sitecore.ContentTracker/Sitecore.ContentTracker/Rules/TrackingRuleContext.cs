using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Analytics.Data.DataAccess.DataSets;
using Sitecore.Data.Items;
using Sitecore.Rules;

namespace Sitecore.ContentTracker.Rules
{
    public class TrackingRuleContext : RuleContext
    {
        public TrackingRuleContext(Item item, VisitorDataSet.VisitsRow visit)
        {
            this.Item = item;
            this.Visit = visit;
        }
        public VisitorDataSet.VisitsRow Visit { get; private set; }
    }
}
