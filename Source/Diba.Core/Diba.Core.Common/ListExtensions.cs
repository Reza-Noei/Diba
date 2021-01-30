using System.Collections.Generic;
using System.Linq;

namespace Diba.Core.Common
{
    public static class ListExtensions
    {
        public static void Update<T>(this IList<T> currentList, IList<T> list)
        {
            var added = list.Except(currentList).ToList();
            var removed = currentList.Except(list).ToList(); ;

            added.ForEach(currentList.Add);
            removed.ForEach(a => currentList.Remove(a));

        }
    }
}