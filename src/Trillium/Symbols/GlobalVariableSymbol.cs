using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trillium.Symbols
{
    public sealed class GlobalVariableSymbol : VariableSymbol
    {
        internal GlobalVariableSymbol(string name, bool isReadOnly, TypeSymbol type)
            : base(name, isReadOnly, type)
        {
        }

        public override SymbolKind Kind => SymbolKind.GlobalVariable;
    }
}
