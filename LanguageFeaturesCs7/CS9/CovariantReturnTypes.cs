using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeaturesCs7.CS9
{
    class consumer
    {
        void Test()
        {
            var c1 = new C1();
            Console.WriteLine(c1.Emp.Title);
            C1 c2 = new C2();
            Console.WriteLine(c2.Emp.Title);
        }
    }
    class C1
    {
        public EmployeePoco Emp => new Principal("f", "l", "t", 1);
    }
    class C2 : C1
    {
        // Overload with derived type return
        public new SrPrincipal Emp => new SrPrincipal("f", "l", "t", 10);
    }
}
