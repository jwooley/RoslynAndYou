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
            var e1 = new EmployeePoco("Jim", "Wooley", "SA");
            // e1.Title = "Sr Delivery Principal";
            var e2 = e1 with { Title = "Sr Delivery Principal" };
            var e3 = new EmployeePoco("Jim", "Wooley", "SA");

            Console.WriteLine($"e1 equals e2: {e1 == e2}");
            Console.WriteLine($"e1 equals e3: {e1.Equals(e3)}");
            Console.WriteLine($"e1 == e3: {e1 == e3}");

            var (first, last, title) = e1;
            Console.WriteLine(first);
            Console.WriteLine(last);
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
