using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeaturesCs7.CS9
{
    public class PatternMatching
    {
        public static bool IsAlphaNumeric(char c) =>
            c is (>= 'a' and <= 'z')
            or (>= 'A' and <= 'Z')
            or (>= '0' and <= '9');

        public static bool HasAlwaysBeenSomething(object x) =>
            x != null;

        public static bool IsNewerSomething(object x) =>
            x is object;

        public static bool IsSomething9(object x) =>
            x is not null;
    }
}
