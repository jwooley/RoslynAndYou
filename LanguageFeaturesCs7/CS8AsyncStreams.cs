using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LanguageFeaturesCs8
{
    class CS8AsyncStreams
    {
        public async Task DoSomethingAsync()
        {
            var test = new TestAsyncList();
            await foreach (var person in test)
            {
                Console.WriteLine(person.Name);
            }
        }
    }


    public class TestAsyncList : IAsyncEnumerable<Person>, IAsyncEnumerator<Person>
    {
        public Person Current => new Person();

        public ValueTask DisposeAsync()
        {
            // Nothing to dispose
            return new ValueTask();
        }

        public IAsyncEnumerator<Person> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return this;
        }

        public ValueTask<bool> MoveNextAsync()
        {
            return new ValueTask<bool>(false);
        }
    }
	public class Person
    {
		public string Name { get; set; }
    }
}
