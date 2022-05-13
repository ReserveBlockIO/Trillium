using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trillium.Binding
{
    internal sealed class BoundWhileStatement : BoundLoopStatement
    {
        public BoundWhileStatement(BoundExpression condition, BoundStatement body, BoundLabel breakLabel, BoundLabel continueLabel)
            : base(breakLabel, continueLabel)
        {
            Condition = condition;
            Body = body;
        }

        public override BoundNodeKind Kind => BoundNodeKind.WhileStatement;
        public BoundExpression Condition { get; }
        public BoundStatement Body { get; }
    }
}
