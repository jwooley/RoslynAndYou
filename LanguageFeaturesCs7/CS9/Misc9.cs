using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeaturesCs7.CS9
{
    class Misc9
    {
        public void NewExpression()
        {
            Employee e = new Employee();

            var e3 = new Employee();

            Employee e9 = new();

            Employee e9a = new() { FirstName = "Jim" };

            var valid = ValidEmployee(new());
        }

        public bool ValidEmployee(Employee emp) => emp is not null;

        void ConditionalExpressionConversions()
        {
            var e1 = new Principal("First", "Middle", "Principal", 3);
            var e2 = new SrPrincipal("First", "Middle", "Sr Principal", 10);
            var multipler = 15;

            EmployeePoco emp = multipler >= 10 ? e2 : e1;
        }
        void StaticModifiers()
        {
            var name = "Jim";
            Action printIt = () => Console.WriteLine(name);
            printIt();

            // This is not allowed
            //Action printStatic = static () => Console.WriteLine(name);
            Action<string> printStaticOk = static (n) => Console.WriteLine(n);
        }

        public void LambdaDiscardParameters()
        {
            Func<EventArgs, object, bool> validate = (_, _) => true;
        }

        public void AttributesOnLocalFunctions()
        {
            [Conditional("DEBUG")]
            static void DoAction()
            {
                Console.WriteLine("Performing action");
            }

            DoAction();
        }

        public void NativeSizedIntegers()
        {
            // System.IntPtr
            nint x = 3;
            // System.UIntPtr
            nuint y = 4;
        }
        void GetEnumeratorExtension()
        {
            var emp = new Employee
            {
                FirstName = "Jim",
                LastName = "Wooley",
                Title = "Sr Delivery Principal"
            };
            foreach (var attrib in emp)
            {
                Console.WriteLine($"{attrib.Key}: {attrib.Value}");
            }
        }
    }
    public static class Extensions
    {
        public static IEnumerator<KeyValuePair<string, object>> GetEnumerator(this Employee emp)
        {
            yield return new KeyValuePair<string, object>(nameof(emp.FirstName), emp.FirstName);
            yield return new KeyValuePair<string, object>(nameof(emp.LastName), emp.LastName);
            yield return new KeyValuePair<string, object>(nameof(emp.Title), emp.Title);
        }
    }

}
