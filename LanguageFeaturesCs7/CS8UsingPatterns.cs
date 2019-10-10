using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LanguageFeaturesCs7
{
    class CS8UsingPatterns
    {
        public void OldUsing()
        {
            using (var tw = new StringWriter())
            {
                tw.Write("Test");
            }
        }
        public void TestSimpleUsing()
        {
            using var tw = new StringWriter();
            tw.Write("Test");
        }
    }
}
