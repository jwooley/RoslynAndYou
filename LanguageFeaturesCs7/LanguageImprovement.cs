using System;
using System.Collections.Generic;

namespace TestProject
{
    public class LanguageImprovement
    {
        public static void LanguageImprovementTests()
        {
            int x;

            if (int.TryParse("123", out x))
                DoSomething();
                DoSomethingElse();

            var p = new Person();
            p.firstName = "VS";
            p.lastName = "Live";
            Console.WriteLine(p.FullName());
        }


        public static void DoSomething() { }
        public static IEnumerable<Person> DoSomethingElse()
        {
            var people = new List<Person>();
            foreach (var person in people)
            {
                if (person.Age > 21 && person.Age < 70)
                {
                    yield return person;
                }
            }
        }
    }

    public class Person : IDisposable
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string FullName()
        {
            return String.Format("{0} {1}", lastName, firstName);
        }
        public int Age { get; set; }
        public bool IsOld()
        {
            var result = false;
            if (Age == 0)
            {
                throw new ArgumentNullException("Age");
            }
            if (Age > 70)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool v)
        {
            // nothing to see here
        }
    }
}
