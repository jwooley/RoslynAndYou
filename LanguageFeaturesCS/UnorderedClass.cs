using System;

namespace LanguageFeaturesCS
{
    public class UnorderedClass
    {
        public void SampleMethod() { AnotherMethod(); }
        public string SomeProperty { get; set; }
        private readonly string aRandomField = "sgiosg";
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
