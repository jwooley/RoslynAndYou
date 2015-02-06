using System;
using static System.Math;       // Imports static
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Tracing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace LanguageFeaturesCS
{

    [TestClass]
    public class Class1
    {
        public int X { get; set; } = 1;  // Auto property Initializer
        public int Y { get;  } = 2;      // Getter-Only Auto Props
        public int Z { get; } 

        public Class1()
        {
            Z = 3;          // Constructor assignment to getter only;
        }

        [TestMethod]
        public void CanImportStatic()
        {
            WriteLine("Test");      // Imports static
            var radius = 3;
            Assert.AreEqual(
                2 * Math.PI * radius, 
                2 * PI * radius);   // Imports static

        }

        [TestMethod]
        public async void CanAwaitInCatchAndFinally()
        {
            try
            {
                throw new Exception("Oops");
            }
            catch (Exception ex)
            {
                await LogAsync(ex);
            }
        }

        [TestMethod]
        public void NullPropagatingOperator()
        {
            var parent = new Person();
            Trace.WriteLine(parent?.Age);
            Trace.WriteLine(parent?.Children.FirstOrDefault()?.Age);
        }

        [TestMethod]
        public void StringInterpolation()
        {
            var parent = new Person
            {
                Age = 42
            };
            Trace.WriteLine($"{parent.Name} is {parent.Age} years old");    // String interpolation.
        }

        public void CanGetNameof(string fieldName)
        {
            var parent = new Person();
            Assert.AreEqual("Age", nameof(parent.Age));
            throw new ArgumentException("Field not set", nameof(fieldName));
        }

        [TestMethod]
        public void CanInitializeIndexes()
        {
            var numbers = new Dictionary<int, string>
            {
                [7] = "seven",
                [9] = "nine",
                [13] = "thirteen"
            };
        }

        #region Helper Methods
        public Task LogAsync(object value)
        {
            Trace.WriteLine(value);
            return Task.Delay(5);
        }
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<Person> Children { get; } = new List<Person>(); // Getter only auto prop initializer
        }
        
        #endregion
    }
}
