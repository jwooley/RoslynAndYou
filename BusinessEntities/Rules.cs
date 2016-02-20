using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public static class Rules
    {
        public static bool Required(string value)
        {
            return !String.IsNullOrWhiteSpace(value);
        }
    }
}
