using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task4.GenericBinarySearch;

namespace Task4.GenericBinarySearchTests
{
    [TestFixture]
    public class BinarySearcherClassTests
    {
        private int[] intPositiveArray = {1, 2, 3, 4, 5, 6, 7, 8, 9, 11};
        private int[] intNullArray = {0, 0, 0, 0};
        private double[] doubleNegativeArray = {-6.6666D, -5.5D, -4D, -3.3333D, -2.22D, -1.111111D};
        private string[] stringArray = {"apple", "bell", "cinnamon", "direction", "eagle"};

        public IEnumerable<TestCaseData> TestDataWithDefaultComparers
        {
            get
            {
                yield return new TestCaseData(intPositiveArray, 7).Returns(6);
                yield return new TestCaseData(intPositiveArray, 1).Returns(0);
                yield return new TestCaseData(intPositiveArray, 10).Returns(null);
                yield return new TestCaseData(intPositiveArray, -10).Throws(typeof(ArgumentException));
                yield return new TestCaseData(intPositiveArray, 1000).Throws(typeof(ArgumentException));
                yield return new TestCaseData(intNullArray, 0).Returns(0);
                yield return new TestCaseData(doubleNegativeArray, -4D).Returns(2);
                yield return new TestCaseData(doubleNegativeArray, -4.55D).Returns(null);
                yield return new TestCaseData(stringArray, "bells").Returns(null);
                yield return new TestCaseData(stringArray, "direction").Returns(3);
                yield return new TestCaseData(stringArray, "a").Throws(typeof (ArgumentException));
                yield return new TestCaseData(stringArray, "fairy").Throws(typeof(ArgumentException));
            }
        }

        [Test, TestCaseSource(nameof(TestDataWithDefaultComparers))]
        public int? SearchWithDefaultComparer<T>(T[] sortedSource, T toBeFound)
        {
            return BinarySearcher.Search(sortedSource, toBeFound);
        }

    }
}
