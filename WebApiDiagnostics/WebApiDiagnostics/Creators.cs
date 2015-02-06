using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiDiagnostics
{
    public class Creators
    {
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
                .WithInitializer(equalsValue)))
                .NormalizeWhitespace(" ")
                .WithAdditionalAnnotations(Formatter.Annotation);

            var declaration = SyntaxFactory.LocalDeclarationStatement(typeSyntax);
            return declaration;
        }

    }
}
