using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trillium.Binding
{
    internal sealed class BoundReturnStatement : BoundStatement
    {
        public BoundReturnStatement(BoundExpression expression)
        {
            Expression = expression;
        }

        public override BoundNodeKind Kind => BoundNodeKind.ReturnStatement;
        public BoundExpression Expression { get; }
    }
}
