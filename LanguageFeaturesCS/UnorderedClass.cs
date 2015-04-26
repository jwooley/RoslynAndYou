using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeaturesCS
{
    public class UnorderedClass
    {
        public void SampleMethod() { }
        public string SomeProperty { get; set; }
        private string aRandomField = "sgiosg";
        private void AnotherMethod() { }
        public string FirstName { get; set; } = "Jim";
        public string LastName { get; set; } = "Wooley";
        public UnorderedClass() { }
        public string FullName() { return $"{FirstName} {LastName}"; }
        public event EventHandler PropertyChanged;
        public UnorderedClass(string first, string last)
        {
            FirstName = first;
            LastName = last;
        }
    }
}
