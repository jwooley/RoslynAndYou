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
            object[] numbers = {0b1, 0b10, new object[] { 0b10, 0b100, 0b1000 }, 0b1000_0, 0b1000_00, "123", null }; // Binary literals with digit separators
            (int sum, int count) Tally(IEnumerable<object> list)        // Local Functions with tuple value types
            {
                var r = (sum: 0, count: 0);
                foreach (var v in list)
                {
                    switch (v)
                    {
                        case int i:                                     // Pattern matching Type Switch
                            r.sum += i;
                            r.count++;
                            break;
                        case IEnumerable<object> l when l.Any():
                            (int s, int c) t1 = Tally(l);               // Tuple Deconstruction
                            r.sum += t1.s;
                            r.count += t1.c;
                            break;
                        case string iStr:
                            if (int.TryParse(iStr, out int parsed))     // out var
                            {
                                r.sum += parsed;
                                r.count++;
                            }
                            Assert.AreEqual(parsed, 123);
                            break;
                        case null:
                            break;
                    }
                }
                return r;
            }
            var result = Tally(numbers);
            Trace.WriteLine($"Sum: {result.sum} Count: {result.count}");
            Assert.AreEqual(8, result.count);
        }
        [TestMethod]
        public void CS7RefLocal()
        {
            var value = "1";
            if (int.TryParse(value, out int x))                         // Ref local
            {
                Assert.AreEqual(1, x);
            }
            Assert.AreEqual(1, x);                                      // Ref local scope
        }
    }
}
