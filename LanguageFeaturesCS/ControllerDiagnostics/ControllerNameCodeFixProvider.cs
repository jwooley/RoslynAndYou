using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis.CodeFixes;
using System;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.Formatting;

namespace ControllerDiagnostics
{
    [ExportCodeFixProvider("ControllerNameCodeFixProvider", LanguageNames.CSharp)]
    public class ControllerNameCodeFixProvider : CodeFixProvider
    {
        public override ImmutableArray<string> GetFixableDiagnosticIds()
        {
            return ImmutableArray.Create(WebApiControllerNamingConventionAnalyzer.DiagnosticId);
        }

        public override async Task ComputeFixesAsync(CodeFixContext context)
        {
            var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);

            var diagnostic = context.Diagnostics.First();
            var diagnosticSpan = context.Diagnostics.First().Location.SourceSpan;
            var declaration = root.FindToken(diagnosticSpan.Start).Parent.AncestorsAndSelf().OfType<TypeDeclarationSyntax>().First();

            context.RegisterFix(CodeAction.Create("Ensure type ends in 'Controller'", c => MakeEndInControllerAsync(context.Document, declaration, c)), diagnostic );
        }

        private async Task<Document> MakeEndInControllerAsync(Document document, TypeDeclarationSyntax typeDecl, CancellationToken cancellationToken)
        {
            var identifierToken = typeDecl.Identifier;
            var originalName = identifierToken.Text;

            var nameWithoutController = Regex.Replace(originalName, "controller", String.Empty, RegexOptions.IgnoreCase);
            var newName = nameWithoutController + "Controller";

            var newIdentifier = SyntaxFactory.Identifier(newName)
                .WithAdditionalAnnotations(Formatter.Annotation);

            var newDeclaration = typeDecl.ReplaceToken(identifierToken, newIdentifier);

            var root = await document.GetSyntaxRootAsync();
            var newRoot = root.ReplaceNode(typeDecl, newDeclaration);
            var newDocument = document.WithSyntaxRoot(newRoot);
            return newDocument;
        }

        public LocalDeclarationStatementSyntax CreateVariable()
        {
            var foo = 1 + 2;

            var equalsValue = SyntaxFactory.EqualsValueClause(
                SyntaxFactory.BinaryExpression(SyntaxKind.AddExpression,
                    SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(1)),
                    SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(2))));

            var typeSyntax = SyntaxFactory.VariableDeclaration(SyntaxFactory.ParseTypeName("var"),
                new SeparatedSyntaxList<VariableDeclaratorSyntax>().Add(
                    SyntaxFactory.VariableDeclarator("foo")
                .WithInitializer(equalsValue)
                .WithAdditionalAnnotations(Formatter.Annotation)));

            var declaration = SyntaxFactory.LocalDeclarationStatement(typeSyntax);
            return declaration;   
        }
    }
}