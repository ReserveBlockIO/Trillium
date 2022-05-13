using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trillium.CodeAnalysis;
using Trillium.Symbols;

namespace Trillium.Binding
{
    internal sealed class BoundVariableDeclaration : BoundStatement
    {
        public BoundVariableDeclaration(VariableSymbol variable, BoundExpression initializer)
        {
            Variable = variable;
            Initializer = initializer;
        }

        public override BoundNodeKind Kind => BoundNodeKind.VariableDeclaration;
        public VariableSymbol Variable { get; }
        public BoundExpression Initializer { get; }
    }
}
