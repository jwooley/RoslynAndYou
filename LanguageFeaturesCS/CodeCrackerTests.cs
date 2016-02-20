using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeaturesCS
{
    [TestClass]
    public class CodeCrackerTests
    {

        public void SampleCodeCrackerTest()
        {
            try
            {
                int shouldSuggestChange = 0;
                if ((shouldSuggestChange > 0))
                    Console.WriteLine(@"Too Manay Parens");
            }
            catch (Exception ex)
            {
            }
        }
        [TestMethod]
        public void UseNameofTest()
        {
            Assert.AreEqual("SampleCodeCrackerTest", nameof(SampleCodeCrackerTest));
        }

        [TestMethod]
        public void UseAnyInsteadOfWhere()
        {
            var items = Enumerable.Range(1, 10);
            var one = items.Where(num => num == 1).Any();
        }

        public int ShouldUseTernary(int value)
        {
            if (1 == value)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public void ShouldUseObjectInitializer()
        {
            var person = new Class1.Person();
            person.BirthDate = DateTime.Today.AddYears(-24);
            person.Name = "Daniel D";

        }
    }
}
