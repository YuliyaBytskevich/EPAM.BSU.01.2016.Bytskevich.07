using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.GenericSort
{
    public static class Sorting
    {
        public static void Sort<T>(IEnumerable<T> source, IComparer<T> comparer)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (comparer == null)
                comparer = Comparer<T>.Default;
            try
            {
                var enumerable = source as T[] ?? source.ToArray();
                for (int i = 0; i < enumerable.Count() - 1; i++)
                    for (int j = 0; j < enumerable.Count() - i - 1; j++)
                    {
                        if (comparer.Compare(enumerable.ElementAt(j), enumerable.ElementAt(j + 1)) > 0)
                            Swap(ref enumerable[j], ref enumerable[j + 1]);
                    }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Try of sorting source collection failed");
            }
        }

        private static void Swap<T>(ref T left, ref T right)
        {
            var temp = left;
            left = right;
            right = temp;
        }
    }
}
