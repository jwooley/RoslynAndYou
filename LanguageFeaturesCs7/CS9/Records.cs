using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageFeaturesCs7.CS9
{
    [TestClass]
    public class Records
    {
        [TestMethod]
        public void RecordEquality()
        {
            var e1 = new Employee { FirstName = "Jim", LastName = "Wooley" };
            var e2 = new Employee { FirstName = "Jim", LastName = "Wooley" };
            Console.WriteLine($"Classes equal: {e1 == e2}");

            var r1 = new EmployeePoco("Jim", "Wooley", "SA");
            // e1.Title = "Sr Delivery Principal";
            var r2 = r1 with { Title = "Sr Delivery Principal" };
            var r3 = new EmployeePoco("Jim", "Wooley", "SA");

            Console.WriteLine($"r1 equals r2: {r1 == r2}");
            Console.WriteLine($"r1 equals r3: {r1.Equals(r3)}");
            Console.WriteLine($"r1 == r3: {r1 == r3}");

            var (first, last, title) = r1;
            Console.WriteLine(first);
            Console.WriteLine(last);

            var r4 = r1 with { Title = "Sr Delivery Principal" };
        }
    }

    public class Employee
    {
        string _fName;
        string _lName;
        public string FirstName
        {
            get
            {
                return _fName;
            }
            set
            {
                _fName = value;
            }
        }
        public string LastName
        {
            get => _lName;
            set => _lName = value;
        }
        public string Title { get; set; }
    }

    public record EmployeePoco(string First, string Last, string Title);
    public record Principal : EmployeePoco
    {
        public int ForceMultiplier { get; }

        public Principal(string first, string last, string title, int forceMultiplier)
            : base(first, last, title)
        {
            ForceMultiplier = forceMultiplier;
        }
    }
    public record SrPrincipal(string First, string Last, string Title, int Multiplier)
        : EmployeePoco(First, Last, Title);
}
