using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LanguageFeaturesCs7
{
    [TestClass]
    public class CS7Tests
    {
        [TestMethod]
        public void CS7Test()
        {
            object[] numbers = { 0b1, 0b10, new object[] { 0b10, 0b100, 0b1000 }, 0b1000_0, 0b1000_00 };
            (int sum, int count) Tally(IEnumerable<object> list)
            {
                var r = (sum: 0, count: 0);
                foreach (var v in list)
                {
                    switch (v)
                    {
                        case int i:
                            r.sum += i;
                            r.count++;
                            break;
                        case IEnumerable<object> l when l.Any():
                            var t1 = Tally(l);
                            r.sum += t1.sum;
                            r.count += t1.count;
                            break;
                        case null:
                            break;
                    }
                }
                return r;
            }
            var result = Tally(numbers);
            Trace.WriteLine($"Sum: {result.sum} Count: {result.count}");

        }
    }
}
