using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanguageFeaturesCs7
{
    [TestClass]
    public class CS8Range
    {
        [TestMethod]
        public void TestRangeNums()
        {
            var arr = Enumerable.Range(1, 10).ToArray();
            var num12 = arr[..2];
            Assert.AreEqual(2, num12.Length);
            Assert.AreEqual(1, num12[0]);
            Assert.AreEqual(2, num12[1]);

            var num234 = arr[2..4];
            var num789 = arr[^4..^1];
            Assert.AreEqual(7, num789[0]);
        }

        [TestMethod]
        public void TestStringRange()
        {

            var input = "This is a test of string ranges";
            var test = input[10..14];
            var ranges = input[^6..];
            Assert.AreEqual("testranges", $"{test}{ranges}");
        }
    }
}
