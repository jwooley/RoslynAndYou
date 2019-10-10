using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeaturesCs7
{
    [TestClass]
    public class CS7Tests
    {
        [TestMethod]
        public void CS7Test()
        {
            object[] numbers = {0b1, 0b10, new object[] { 122_345.6, 0b10, 0b100, 0b_1000 }, 0b1_00_00, 0b1000_00, "123", null }; // Binary literals with digit separators
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
                            (int s, int c) = Tally(l);               // Tuple Deconstruction
                            r.sum += s;
                            r.count += c;
                            break;
                        case string iStr:
                            if (int.TryParse(iStr, out var parsed))     // out var
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
            int y;
            if (int.TryParse(value, out y))
            {
                Assert.AreEqual(1, y);                                  // Old way
            }

            if (int.TryParse(value, out int x))                         // Ref local
            {
                Assert.AreEqual(1, x);
            }

            Assert.AreEqual(1, x);                                      // Ref local scope
        }

        [TestMethod]
        [ExpectedException(typeof (NullReferenceException))]
        public void CS7ThrowExpressions()
        {
            string s = null;
            if (s == null)
            {
                throw new NullReferenceException("s is null");
            }

            var t = s ?? throw new NullReferenceException("s is null");
            Assert.IsNull(t);
        }

        [TestMethod]
        public async Task GeneralizedAsyncReturnTypes()
        {
            Assert.AreEqual(0, loadCount);
            Assert.AreEqual("Jim", await GetUserName());
            Assert.AreEqual(1, loadCount);
            Assert.AreEqual("Jim", await GetUserName());
            Assert.AreEqual(1, loadCount);
        }

        public ValueTask<string> GetUserName()
        {
            return loadCount == 0 ? new ValueTask<string>(Load()) : new ValueTask<string>(cachedName);
        }

        int loadCount = 0;
        string cachedName = null;
        private async Task<string> Load()
        {
            // Simulated delay
            await Task.Delay(100);
            cachedName = "Jim";
            loadCount += 1;
            return cachedName;
        }
    }
}
