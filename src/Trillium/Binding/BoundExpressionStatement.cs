using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trillium.Binding
{
    internal sealed class BoundExpressionStatement : BoundStatement
    {
        public BoundExpressionStatement(BoundExpression expression)
        {
            Expression = expression;
        }

        public override BoundNodeKind Kind => BoundNodeKind.ExpressionStatement;
        public BoundExpression Expression { get; }
    }
}
