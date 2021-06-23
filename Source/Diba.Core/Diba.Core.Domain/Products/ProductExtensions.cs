using System.Collections.Generic;
using System.Linq;
using Diba.Core.Common;

namespace Diba.Core.Domain.Products
{
    public static class ProductExtensions
    {
        public static void Modify(this List<Product> source, List<Product> newList)
        {
            var removed = new List<Product>();
            var added = new List<Product>();

            newList.ForEach(x => added.AddRange(source.Where(y => x.Name != y.Name)));
            source.ForEach(x => removed.AddRange(newList.Where(y => x.Name != y.Name)));

            added.ForEach(source.Add);
            removed.ForEach(a => source.Remove(a));
        }
    }
}