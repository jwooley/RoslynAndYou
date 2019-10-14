using LanguageFeaturesCs7;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TestProject
{
    public class LanguageImprovement
    {
        public async Task LanguageImprovementTests()
        {
            int x;

            if (int.TryParse("123", out x))
                DoSomething();
                throw new NotImplementedException();
                await DoSomethingElse();

            var p = new Person();
            p.firstName = "VS";
            p.lastName = "Live";
            Console.WriteLine(p.FullName());
        }
        
        public static IEnumerable<Person> DoSomething()
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
        public async Task DoSomethingElse()
        {
            var people = new List<Person>();
            using (var persons = new AsyncList<Person>(people))
            {
                await foreach (var person in persons)
                {
                    Console.WriteLine(person);
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

        public void PatternMatch()
        {
            object x = new Address("","","", "");
            var p = x as Person;
            if (p != null)
            {
                Console.WriteLine(p.firstName);
            }
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

    public class AsyncList<T> : IAsyncEnumerable<T>, IAsyncEnumerator<T>, IDisposable
    {
        List<T> innerList;
        IEnumerator<T> innerEnum;

        public AsyncList(List<T> input)
        {
            innerList = input ?? new List<T>();
            innerEnum = innerList.GetEnumerator();
        }

        public T Current => innerEnum.Current;

        public void Dispose()
        {

        }
        public ValueTask DisposeAsync()
        {
            return new ValueTask();
        }

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            innerEnum = innerList.GetEnumerator();
            return this;
        }

        public ValueTask<bool> MoveNextAsync()
        {
            return new ValueTask<bool>(innerEnum.MoveNext());
        }
    }
}
