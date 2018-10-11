using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageFeaturesCs7
{
    public class C : IAddress
    {
        public string Address1 { get; set; }
        public string? Address2 { get; set; } // Compiler error because value is not set
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public C(string addr1, string city, string state, string zip)
        {
            Address1 = addr1 ?? "";
            City = city ?? "";
            State = state ?? "";
            Zip = zip ?? "";
        }

        public string Formatted()
        {
            return $@"{Address1}
{Address2 ?? ""}
{City}, {State} {Zip}";
        }
    }
}
