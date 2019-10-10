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

namespace Demo
{

    [TestClass]
    public class CS6
    {
        public int X { get; set; } = 1;  // Auto property Initializer
        public int Y { get;  } = 2;      // Getter-Only Auto Props
        public int Z { get; }

        public CS6()
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
        public async Task CanAwaitInCatchAndFinally()
        {
            try
            {
                throw new Exception("Oops");
            }
            catch (Exception ex) when (ex.InnerException == null)   // Exception filters
            {
                await LogAsync(ex);                                 // Await in catch block
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
            Trace.WriteLine(string.Format("{1} is {2} years old", child.Name, child.Age));

            Trace.WriteLine($"{child.Name} is {child.Age} years old on {child.BirthDate:mm/dd/yyyy}");    // String interpolation.
        }

        public void CanGetNameof(string name)
        {
            var parent = new Person();
            parent.Name = name;

            OnNotifyPropertyChanged("name");           // Without nameof
            OnNotifyPropertyChanged(nameof(name));     // With nameof

            Assert.AreEqual("Age", nameof(parent.Age));

            if (1 == 2)
            {
                throw new ArgumentException("Field not set", nameof(name));
            }
        }

        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }
        public string FullName1() => $"{FirstName} {LastName}";     // Expression Bodied Members

        public void TestCode()
        {
            var x = 1 + 2;
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

        }

        #region Helper Methods
        public Task LogAsync(object value)
        {
            Trace.WriteLine(value);
            return Task.FromResult(0);
        }

        public void OnNotifyPropertyChanged(string propertyName)
        {
            Trace.WriteLine(propertyName);
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        #endregion
    }

    public class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public List<Person> Children { get; } = new List<Person>(); // Getter only auto prop initializer
    }
}
