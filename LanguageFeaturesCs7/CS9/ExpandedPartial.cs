using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LanguageFeaturesCs7.CS9
{

    partial class ExpandedPartial
    {
        //[RegexGenerated("(dog|cat|fish)")]
        public partial bool IsPetMatch(string input);
    }

    partial class ExpandedPartial
    {
        // Previously partials needed to be
        // private, parameterless, return void, no out parameters
        public partial bool IsPetMatch(string input)
            => Regex.IsMatch(input, "(dog|cat|fish)");
    }
}
