using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace ControllerDiagnostics
{
    // TODO: Consider implementing other interfaces that implement IDiagnosticAnalyzer instead of or in addition to ISymbolAnalyzer

    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class WebApiControllerNamingConventionAnalyzer : DiagnosticAnalyzer
    {
        internal const string DiagnosticId = "WebApiControllerNamingConvention";
        internal const string Description = "Controller type name should end in 'Controller'";
        internal const string MessageFormat = "Type name '{0}' does not end in Controller";
        internal const string Category = "Naming";

        private static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Description, MessageFormat, Category, DiagnosticSeverity.Warning, true);

        public ImmutableArray<SymbolKind> SymbolKindsOfInterest { get { return ImmutableArray.Create(SymbolKind.NamedType); } }

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        {
            get
            {
                return ImmutableArray.Create(Rule);
            }
        }

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSymbolAction(Analyzer, SymbolKind.NamedType);
            throw new NotImplementedException();
        }

        private void Analyzer(SymbolAnalysisContext context)
        {
            var symbol = (INamedTypeSymbol)context.Symbol;
            if (symbol.BaseType == null) return;

            if ((symbol.BaseType.Name == "Controller" || symbol.BaseType.Name == "ApiController") &&
                !symbol.Name.EndsWith("Controller"))
            {
                var diagnostic = Diagnostic.Create(Rule, symbol.Locations[0], symbol.Name);
                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}
