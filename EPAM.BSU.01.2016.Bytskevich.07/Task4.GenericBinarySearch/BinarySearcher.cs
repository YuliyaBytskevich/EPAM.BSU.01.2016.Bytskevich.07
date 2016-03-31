using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.GenericBinarySearch
{
    public static class BinarySearcher
    {
        public static int? Search<T>(T[] sortedSource, T toBeFound, Comparer<T> comparer = null)
        {
            int? result = null;
            if (sortedSource == null)
                throw new ArgumentNullException(nameof(sortedSource));
            if (sortedSource.Length == 0)
                throw new ArgumentException("Source collection must not be empty");
            int lowerIndex = 0;
            int higherIndex = sortedSource.Length;
            int middleIndex;
            if (comparer == null)
                comparer = Comparer<T>.Default;
            if (comparer.Compare(toBeFound, sortedSource[lowerIndex]) < 0)
                throw new ArgumentException("Search parameter is out of source collection range (it is less than min element)");
            if (comparer.Compare(sortedSource[higherIndex-1], toBeFound) < 0)
                throw new ArgumentException("Search parameter is out of source collection range (it is greater than max element)");
            if (toBeFound.Equals(sortedSource[lowerIndex]))
                return lowerIndex;
            if (toBeFound.Equals(higherIndex-1))
                return higherIndex-1;
            while (lowerIndex < higherIndex)
            {
                middleIndex = (higherIndex - lowerIndex) / 2 + lowerIndex;
                if (comparer.Compare(toBeFound, sortedSource[middleIndex]) <= 0)
                    higherIndex = middleIndex;
                else
                    lowerIndex =middleIndex + 1;
            }
            if (comparer.Compare(sortedSource[lowerIndex], toBeFound) == 0)
                return lowerIndex;
            return null;
        }
    }
}
