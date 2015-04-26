using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;

namespace LanguageFeaturesCS
{
    public class ValueCreator
    {
        public LocalDeclarationStatementSyntax CreateVariable()
        {
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
