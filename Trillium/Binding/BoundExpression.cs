using Trillium.Symbols;

namespace Trillium.Binding
{
    internal abstract class BoundExpression : BoundNode
    {
        public abstract TypeSymbol Type { get; }
    }

}
