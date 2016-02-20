using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeaturesCS
{
    [TestClass]
    public class ScriptingTests
    {
        [TestMethod]
        public async Task Scripting_CanAddValues()
        {
            var result = await CSharpScript.EvaluateAsync<int>("1 + 2");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public async Task Scripting_CanGetErrors()
        {
            try
            {
                Console.WriteLine(await CSharpScript.EvaluateAsync("throw new System.Exception()"));
                throw new InvalidOperationException("Should have thrown");
            }
            catch (CompilationErrorException e)
            {
                Console.WriteLine(string.Join(Environment.NewLine, e.Diagnostics));
            }
        }

        [TestMethod]
        public async Task Scripting_CanAddReferences()
        {
            var result = await CSharpScript.EvaluateAsync("System.Net.Dns.GetHostName()",
                ScriptOptions.Default.WithReferences(typeof(System.Net.Dns).Assembly));


        }

        [TestMethod]
        public async Task Scripting_Imports()
        {
            var result = await CSharpScript.EvaluateAsync<Double>("Sqrt(4)",
                ScriptOptions.Default.WithImports("System.Math"));
            Assert.AreEqual(2.0, result);
        }

        public class ParamaterGlobals
        {
            public int X;
            public int Y;
        }
        [TestMethod]
        public async Task Scripting_PassingParameters()
        {
            var parameters = new ParamaterGlobals { X = 1, Y = 2 };
            Assert.AreEqual(3, await CSharpScript.EvaluateAsync<int>("X+Y", globals: parameters));
        }

        [TestMethod]
        public async Task Scripting_ReusePrecompiledScript()
        {
            var script = CSharpScript.Create<int>("int z = X - Y;", globalsType: typeof(ParamaterGlobals));
            script.Compile();
            for(int i = 0; i<10; i++)
            {
                var result = await script.RunAsync(new ParamaterGlobals { X = i, Y = i - 1 });
                Assert.AreEqual(1, (int)result.Variables[0].Value);
            }
        }

        [TestMethod]
        public async Task Scripting_ChainValues()
        {
            var script = CSharpScript.Create<int>("int x = 1;")
                .ContinueWith("int y = 2;")
                .ContinueWith("x + y");
            Assert.AreEqual(3, (int)(await script.RunAsync()).ReturnValue);
        }
    }
}
