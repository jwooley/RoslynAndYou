using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeaturesCs7
{
    class Program
    {
        // Async Main
        static async Task Main(string[] args)
        {
            await Task.FromResult(0);
        }
    }

    [TestClass]
    public class CS71
    {
        [TestMethod]
        public void CS71_DefaultLiteralExpresions()
        {
            Func<string, bool> whereOld = default(Func<string, bool>);
            Assert.IsNull(whereOld);

            Func<string, bool> whereClause = default;
            Assert.IsNull(whereClause);

            int? i = default;
            Assert.IsFalse(i.HasValue);

            int j = default;
            Assert.AreEqual(0, j);
        }

        [TestMethod]
        public void CS71_InferredTupleElementNames()
        {
            int theAnswer = 42;
            var q1 = (theAnswer: theAnswer, PI: Math.PI);
            Assert.AreEqual(42, q1.theAnswer);

            var q2 = (theAnswer, Math.PI);
            Assert.AreEqual(42, q2.theAnswer);
        }
    }
}
