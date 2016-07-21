using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FibonaciTask;

namespace Fibonaci_Tests
{
    [TestFixture]
    public class FibonacciTests
    {
        [TestCaseSource("GetTestData")]
        public void Fibonacci_Tests(int x, List<int> arr)
        {
            var collect = FibonaciTask.Fibonacci.Fibonaci(x);
            CollectionAssert.AreEqual(collect, arr);
        }

        public IEnumerable<TestCaseData> GetTestData()
        {
            yield return new TestCaseData(11, new List<int>() { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 });
        }
    }
}
