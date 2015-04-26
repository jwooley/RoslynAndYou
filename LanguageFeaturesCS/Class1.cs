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

            Console.WriteLine("Test");  // Without import
            WriteLine("Test");          // Imports static

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

            Trace.WriteLine((parent == null) ? 0  : parent.Age);

            var age = parent?.Age;

            Trace.WriteLine(parent?.Age);
            var nullPropigatedAge = parent?.Age;
            Trace.WriteLine(parent?.Children.FirstOrDefault()?.Age);
        }

        [TestMethod]
        public void StringInterpolation()
        {
            var child = new Person
            {
                Age = 42
            };
            Trace.WriteLine(string.Format("{0} is {1} years old", child.Name, child.Age));

            Trace.WriteLine($"{child.Name} is {child.Age} years old");    // String interpolation.
        }

        public void CanGetNameof(string fieldName)
        {
            var parent = new Person();

            Assert.AreEqual("Age", nameof(parent.Age));

            OnNotifyPropertyChanged("fieldName");           // Without nameof
            OnNotifyPropertyChanged(nameof(fieldName));     // With nameof

            throw new ArgumentException("Field not set", nameof(fieldName));
        }

        [TestMethod]
        public void CanInitializeIndexes()
        {
            var numsBefore = new Dictionary<int, string>();
            numsBefore.Add(7, "seven");
            numsBefore.Add(9, "nine");

            var numbers = new Dictionary<int, string>
            {
                [7] = "seven",
                [9] = "nine",
                [13] = "thirteen"
            };

            var x = 1;
        }

        #region Helper Methods
        public Task LogAsync(object value)
        {
            Trace.WriteLine(value);
            return Task.Delay(5);
        }

        public void OnNotifyPropertyChanged(string propertyName)
        {
            Trace.WriteLine(propertyName);
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
