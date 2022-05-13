using System.Collections.Immutable;
using Trillium.CodeAnalysis;
using Trillium.Symbols;

namespace Trillium.Binding
{
    internal sealed class BoundProgram
    {
        public BoundProgram(BoundProgram previous,
                            ImmutableArray<Diagnostic> diagnostics,
                            FunctionSymbol mainFunction,
                            FunctionSymbol scriptFunction,
                            ImmutableDictionary<FunctionSymbol, BoundBlockStatement> functions)
        {
            Previous = previous;
            Diagnostics = diagnostics;
            MainFunction = mainFunction;
            ScriptFunction = scriptFunction;
            Functions = functions;
        }

        public BoundProgram Previous { get; }
        public ImmutableArray<Diagnostic> Diagnostics { get; }
        public FunctionSymbol MainFunction { get; }
        public FunctionSymbol ScriptFunction { get; }
        public ImmutableDictionary<FunctionSymbol, BoundBlockStatement> Functions { get; }
    }
}
