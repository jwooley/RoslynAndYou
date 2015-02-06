using ControllerDiagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestHelper;
using WebApiDiagnostics;

namespace WebApiDiagnostics.Test
{
    [TestClass]
    public class UnitTest : CodeFixVerifier
    {

        //No diagnostics expected to show up
        [TestMethod]
        public void TestMethod1()
        {
            var test = @"class foo {}";

            VerifyCSharpDiagnostic(test);
        }

        //Diagnostic and CodeFix both triggered and checked for
        [TestMethod]
        public void TestMethod2()
        {
            var test = @"
    namespace ConsoleApplication1
    {
        class TestControllerError : Controller
        {   
        }
    }";
            var expected = new DiagnosticResult
            {
                Id = WebApiControllerNamingConventionAnalyzer.DiagnosticId,
                Message = String.Format("Type name '{0}' does not end in Controller", "TestControllerError"),
                Severity = DiagnosticSeverity.Warning,
                Locations =
                    new[] {
                            new DiagnosticResultLocation("Test0.cs", 4, 15)
                        }
            };

            VerifyCSharpDiagnostic(test, expected);

            var fixtest = @"
    namespace ConsoleApplication1
    {
        class TestErrorController : Controller
        {   
        }
    }";
            VerifyCSharpFix(test, fixtest);
        }

        [TestMethod]
        public void CanCreateVariable()
        {
            var provider = new Creators();
            var variable = provider.CreateVariable();
            Console.WriteLine(variable.ToString());
            Assert.AreEqual("var foo = 1 + 2;", variable.ToString());
        }
        protected override CodeFixProvider GetCSharpCodeFixProvider()
        {
            return new ControllerNameCodeFixProvider();
        }

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
        {
            return new WebApiControllerNamingConventionAnalyzer();
        }
    }
}