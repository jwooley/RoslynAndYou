using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestHelper;

namespace ControllerDiagnostics.Test
{
    [TestClass]
    public class UnitTest : CodeFixVerifier
    {

        //Diagnostic and CodeFix both triggered and checked for
        [TestMethod]
        public void MvcClassNotEndingInControllerCreatesDiagnostics()
        {
            var test = @"
using System.Web.Mvc;

namespace WebApplicationCS.Controllers
{
    public class HomeControllerTest : Controller
    {
		public HomeControllerTest()
		{

		}
        public ActionResult Index()
        {
            return View();
        }
    }
}";
            var expected = new DiagnosticResult
            {
                Id = ControllerNamingConventionAnalyzer.DiagnosticId,
                Message = String.Format("Type name '{0}' does not end in Controller", "HomeControllerTest"),
                Severity = DiagnosticSeverity.Warning,
                Locations =
                    new[] {
                            new DiagnosticResultLocation("Test0.cs", 6, 18)
                        }
            };

            VerifyCSharpDiagnostic(test, expected);

            var fixtest = @"
using System.Web.Mvc;

namespace WebApplicationCS.Controllers
{
    public class HomeTestController : Controller
    {
		public HomeTestController()
		{

		}
        public ActionResult Index()
        {
            return View();
        }
    }
}";
            VerifyCSharpFix(test, fixtest);
        }

        // Diagnostic and CodeFix both triggered and checked for
        [TestMethod]
        public void MvcClassEndingInControllerDoesNotCreateDiagnostic()
        {
            var test = @"
using System.Web.Mvc;

namespace WebApplicationCS.Controllers
{
    public class HomeTestController : Controller
    {
		public HomeConTest()
		{

		}
        public ActionResult Index()
        {
            return View();
        }
    }
}";

            VerifyCSharpDiagnostic(test);
        }

        //Diagnostic and CodeFix both triggered and checked for
        [TestMethod]
        public void WebApiClassNotEndingInControllerCreatesDiagnostics()
        {
            var test = @"
using System.Web.Http;

namespace WebApplicationCS.Controllers
{
    public class HomeConTest : ApiController
    {
		public HomeConTest()
		{

		}
    }
}";

            var expected = new DiagnosticResult
            {
                Id = ControllerNamingConventionAnalyzer.DiagnosticId,
                Message = String.Format("Type name '{0}' does not end in Controller", "HomeConTest"),
                Severity = DiagnosticSeverity.Warning,
                Locations =
        new[] {
                            new DiagnosticResultLocation("Test0.cs", 6, 18)
                        }
            };


            VerifyCSharpDiagnostic(test, expected);

            var fixtest = @"
using System.Web.Http;

namespace WebApplicationCS.Controllers
{
    public class HomeConTestController : ApiController
    {
		public HomeConTestController()
		{

		}
    }
}";
            VerifyCSharpFix(test, fixtest);
        }

        protected override CodeFixProvider GetCSharpCodeFixProvider()
        {
            return new ControllerNamingConventionCodeFixProvider();
        }

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
        {
            return new ControllerNamingConventionAnalyzer();
        }
    }
}