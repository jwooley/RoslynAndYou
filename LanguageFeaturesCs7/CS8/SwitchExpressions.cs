using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageFeaturesCs7
{
    class SwitchExpressions
    {
        public void TestSwitchExpression()
        {
            var (a, b, option) = (10, 5, "+");

            var example1 = option switch
            {
                "+" => a + b,
                "-" => a - b,
                _ => a * b
            };

            Assert.AreEqual(15, example1);
        }
    }
}
