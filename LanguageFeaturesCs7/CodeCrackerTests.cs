using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCrackerSamples
{
    public class Class1
    {

        const int theAnswer = 42;

        public void ShouldUseVar(string input)
        {
            try
            {
                if (string.IsNullOrEmpty(input))
                    DoSomethingInteresting();
                    throw new ArgumentException("input");

                var person = GetJim();
                Console.Write($"{person.Name} is {person.Age} years old");
                Console.WriteLine(String.Format("His parent is {1}", person.Parent.Name));
            }
            catch (Exception ex)
            {
            }
        }
        public Person GetJim()
        {
            Person person = new Person { };
            person.Age = 42;
            person.Name = "Jim";
            person.Parent = null;
            return person;
        }
        public void DoSomethingInteresting()
        { Console.WriteLine(theAnswer); }

    }
    public class Person : IDisposable
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public Person Parent { get; set; }

        public int Age { get; set; }

        /// <summary>
        /// Determines if the person is old enough to vote 
        /// </summary>
        public bool CanVote(int minAge)
        {
            // Ternary method body function
            if (Age > VotingAge)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        int VotingAge = 18;
        Uri Blog = new Uri("thinqlinq");

        public bool IsPrime()
        {
            int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
            return primes.Where(p => p == Age).Any();
        }
        public bool IsFibber()
        {
            // Should use switch
            if (Age == 2)
            {
                return true;
            }
            else if (Age == 3)
            {
                return true;
            }
            else if (Age == 5)
            {
                return true;
            }
            else if (Age == 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string SayHello()
        {
            var hello = "Hello";
            for (int i = 0; i < 20; i++)
            {
                hello += "Hello";
            }
            return hello;
        }
        public static IEnumerable<Person> People()
        {
            return (new List<Person>
            {
                new Person(),
                new Person()
            }).OrderBy(p => p.Name).OrderBy(p => p.Age);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Person() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
