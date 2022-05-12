using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trillium.Symbols
{
    public abstract class Symbol
    {
        private protected Symbol(string name)
        {
            Name = name;
        }

        public abstract SymbolKind Kind { get; }
        public string Name { get; }
        public override string ToString() => Name;
    }
}
