using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using Sitecore.Pipelines;

namespace Sitecore.ContentTracker.Pipelines.GetSourceItems
{
    public class GetSourceItemsArgs : PipelineArgs
    {
        public GetSourceItemsArgs(Item targetItem)
        {
            this.TargetItem = targetItem;
            this.SourceItems = new List<Item>();
        }
        public Item TargetItem { get; private set; }
        public List<Item> SourceItems { get; private set; }
    }
}
