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
        public Person Current => throw new NotImplementedException();

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerator<Person> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> MoveNextAsync()
        {
            throw new NotImplementedException();
        }
    }
	public class Person
    {
		public string Name { get; set; }
    }
}
