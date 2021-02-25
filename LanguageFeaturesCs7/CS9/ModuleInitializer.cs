using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeaturesCs7.CS9
{
    class ModuleInitializer
    {
        static string? somethingThatNeedsToBeInitializedFirst;

        [ModuleInitializer]
        internal static void Initializer()
        {
            somethingThatNeedsToBeInitializedFirst = "Must be important";
        }
    }
}
