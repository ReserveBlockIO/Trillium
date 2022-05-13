using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trillium.Binding
{
    internal sealed class BoundBlockStatement : BoundStatement
    {
        public BoundBlockStatement(ImmutableArray<BoundStatement> statements)
        {
            Statements = statements;
        }

        public override BoundNodeKind Kind => BoundNodeKind.BlockStatement;
        public ImmutableArray<BoundStatement> Statements { get; }
    }
}
