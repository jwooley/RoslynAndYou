using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeaturesCs7.CS9
{
    unsafe class FunctionPointers
    {
        void Example(Action<int> a, delegate*<int, void> f)
        {
            a(42);
            f(42);
        }
    }
}
