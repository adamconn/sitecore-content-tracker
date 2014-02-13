using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;

namespace Sitecore.ContentTracker.Pipelines.GetSourceItems
{
    public class GetSourceItemsExample
    {
        public virtual void Process(GetSourceItemsArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            Assert.ArgumentNotNull(args.TargetItem, "args.TargetItem");
            Assert.ArgumentNotNull(args.SourceItems, "args.SourceItems");
            args.SourceItems.AddRange(DummyProvider.GetCategories(args.TargetItem));
        }
    }
    public class DummyProvider
    {
        public static List<Item> GetCategories(Item item)
        {
            if (!Categories.ContainsKey(item.Name))
            {
                return null;
            }
            return Categories[item.Name];
        }
        private static Dictionary<string, List<Item>> Categories { get; set; }
        static DummyProvider()
        {
            var database = Sitecore.Data.Database.GetDatabase("web");
            Categories = new Dictionary<string, List<Item>>();
            var categoryDaily = database.GetItem(new ID("{2EAB19AC-1BB9-49C5-AA1D-4BCAB1307566}"));
            var categoryMedia = database.GetItem(new ID("{14FD5752-2469-4418-A57C-8BB110CD7D0C}"));
            var categoryPrinted = database.GetItem(new ID("{15F8FFA3-4E6F-4EB0-A90D-03FDD8330776}"));

            var bookCategories = new List<Item>();
            bookCategories.Add(categoryMedia);
            bookCategories.Add(categoryPrinted);
            Categories.Add("Book", bookCategories);

            var magazineCategories = new List<Item>();
            magazineCategories.Add(categoryMedia);
            magazineCategories.Add(categoryPrinted);
            Categories.Add("Magazine", magazineCategories);

            var dvdCategories = new List<Item>();
            dvdCategories.Add(categoryMedia);
            Categories.Add("DVD", dvdCategories);

            var newspaperCategories = new List<Item>();
            newspaperCategories.Add(categoryMedia);
            newspaperCategories.Add(categoryPrinted);
            newspaperCategories.Add(categoryDaily);
            Categories.Add("Newspaper", newspaperCategories);
        }
    }

}
