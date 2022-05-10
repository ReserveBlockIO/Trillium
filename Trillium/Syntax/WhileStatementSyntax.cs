using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trillium.Syntax
{
    public sealed class WhileStatementSyntax : StatementSyntax
    {
        public WhileStatementSyntax(SyntaxToken whileKeyword, ExpressionSyntax condition, StatementSyntax body)
        {
            WhileKeyword = whileKeyword;
            Condition = condition;
            Body = body;
        }

        public override SyntaxKind Kind => SyntaxKind.WhileStatement;
        public SyntaxToken WhileKeyword { get; }
        public ExpressionSyntax Condition { get; }
        public StatementSyntax Body { get; }
    }
}
