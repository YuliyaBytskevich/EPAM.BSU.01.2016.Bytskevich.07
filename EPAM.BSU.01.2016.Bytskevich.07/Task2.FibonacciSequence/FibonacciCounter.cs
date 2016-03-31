using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.FibonacciSequence
{
    public static class FibonacciCounter 
    {
        public static IEnumerable<int> GetSequence(int length)
        {
            if (length < 0)
                throw new ArgumentException("Sequence lenght must be only positive integer value");
            int penultimateNumber = 0;
            int lastNumber = 1;
            if (length >= 0)
                yield return 0;       
            if (length >= 1)
                yield return 1;
            if (length >= 2)
                for (int i = 2; i <= length; i++)
                {
                    int currentNumber;
                    yield return currentNumber = penultimateNumber + lastNumber;
                    penultimateNumber = lastNumber;
                    lastNumber = currentNumber;
                }
        } 
    }
}
