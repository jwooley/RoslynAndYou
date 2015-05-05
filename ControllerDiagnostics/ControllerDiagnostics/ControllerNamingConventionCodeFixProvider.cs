using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Rename;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;

namespace ControllerDiagnostics
{
    [ExportCodeFixProvider(nameof(ControllerNamingConventionCodeFixProvider), LanguageNames.CSharp), Shared]
    public class ControllerNamingConventionCodeFixProvider : CodeFixProvider
    {
        public sealed override ImmutableArray<string> FixableDiagnosticIds { get; } = ImmutableArray.Create(ControllerNamingConventionAnalyzer.DiagnosticId);

        public sealed override FixAllProvider GetFixAllProvider()
        {
            return WellKnownFixAllProviders.BatchFixer;
        }
        public override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);

            var diagnostic = context.Diagnostics.First();
            var diagnosticSpan = diagnostic.Location.SourceSpan;
            var declaration = root.FindToken(diagnosticSpan.Start).Parent.AncestorsAndSelf().OfType<TypeDeclarationSyntax>().First();

            context.RegisterCodeFix(CodeAction.Create("Ensure type ends in 'Controller'", c => MakeEndInControllerAsync(context.Document, declaration, c)), diagnostic);
        }

        private async Task<Solution> MakeEndInControllerAsync(Document document, TypeDeclarationSyntax typeDecl, CancellationToken cancellationToken)
        {
            var identifierToken = typeDecl.Identifier;
            var originalName = identifierToken.Text;
            var nameWithoutController = Regex.Replace(originalName, "controller", String.Empty, RegexOptions.IgnoreCase);
            var newName = nameWithoutController + "Controller";

            var semanticModel = await document.GetSemanticModelAsync(cancellationToken);
            var typeSymbol = semanticModel.GetDeclaredSymbol(typeDecl, cancellationToken);
            //var newSymbol = SyntaxFactory.ClassDeclaration(newName)
            //    .WithMembers(typeDecl.Members)
            //    .WithLeadingTrivia(typeDecl.GetLeadingTrivia())
            //    .WithTrailingTrivia(typeDecl.GetTrailingTrivia())
            //    .WithAdditionalAnnotations(Formatter.Annotation);

            var originalSolution = document.Project.Solution;
            var optionSet = originalSolution.Workspace.Options;
            var newSolution = await Renamer.RenameSymbolAsync(originalSolution, typeSymbol, newName, optionSet, cancellationToken).ConfigureAwait(false);

            return newSolution;
        }
    }
}
