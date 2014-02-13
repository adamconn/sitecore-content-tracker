using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;

namespace Sitecore.ContentTracker.Rules.Actions
{
    public class ApplyTrackingFromField<T> : BaseApplyTrackingAction<T> where T : TrackingRuleContext
    {
        public string FieldName { get; set; }
        protected override IEnumerable<Item> GetSourceItems(T ruleContext)
        {
            Assert.ArgumentNotNullOrEmpty(this.FieldName, "FieldName");
            Assert.ArgumentNotNull(ruleContext, "ruleContext");
            Assert.ArgumentNotNull(ruleContext.Item, "ruleContext.Item");
            var item = ruleContext.Item;
            var field = item.Fields[this.FieldName];
            if (field == null)
            {
                return null;
            }
            var sourceItems = new List<Item>();
            var customField = FieldTypeManager.GetField(field);
            if (customField is LookupField)
            {
                var f2 = customField as LookupField;
                sourceItems.Add(f2.TargetItem);
            }
            else if (customField is ReferenceField)
            {
                var f2 = customField as ReferenceField;
                sourceItems.Add(f2.TargetItem);
            }
            else if (customField is MultilistField)
            {
                var f2 = customField as MultilistField;
                sourceItems.AddRange(f2.GetItems());
            }
            return sourceItems;
        }
    }
}
