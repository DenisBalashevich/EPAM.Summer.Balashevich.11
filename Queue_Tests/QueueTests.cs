using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using QueueTask;

namespace Queue_Tests
{
    [TestFixture]
    public class QueueTests
    {
        [TestCaseSource("GetTestData")]
        public string Fibonacci_Tests(List<int> arr)
        {
            Queue<int> a = new Queue<int>(arr);
            StringBuilder s = new StringBuilder();
            foreach (var c in a)
                s.AppendFormat("{0}, ", a.Dequeue());
            return s.ToString();
        }

        public IEnumerable<TestCaseData> GetTestData()
        {
            yield return new TestCaseData(new List<int>() { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 }).Returns(
                "1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89");
        }
    }
}
