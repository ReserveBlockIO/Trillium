using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Trillium.Symbols
{
    internal static class BuiltinFunctions
    {
        public static readonly FunctionSymbol Print = new FunctionSymbol("print", ImmutableArray.Create(new ParameterSymbol("text", TypeSymbol.String)), TypeSymbol.Void);
        public static readonly FunctionSymbol Input = new FunctionSymbol("input", ImmutableArray<ParameterSymbol>.Empty, TypeSymbol.String);
        public static readonly FunctionSymbol Rand = new FunctionSymbol("rand", ImmutableArray.Create(new ParameterSymbol("max", TypeSymbol.Int)), TypeSymbol.Int);
        public static readonly FunctionSymbol DateProcess = new FunctionSymbol("dateProc", ImmutableArray.Create(new ParameterSymbol("max", TypeSymbol.String)), TypeSymbol.Bool);
        public static readonly FunctionSymbol GetContractMethods = new FunctionSymbol("getMethods", ImmutableArray<ParameterSymbol>.Empty, TypeSymbol.String);
        public static readonly FunctionSymbol CreateSignature = new FunctionSymbol("createSig", ImmutableArray.Create(new ParameterSymbol("text", TypeSymbol.String), new ParameterSymbol("text", TypeSymbol.String)), TypeSymbol.String);
        public static readonly FunctionSymbol ValidateSignature = new FunctionSymbol("validateSig", ImmutableArray.Create(new ParameterSymbol("text", TypeSymbol.String), new ParameterSymbol("text", TypeSymbol.String), new ParameterSymbol("text", TypeSymbol.String)), TypeSymbol.Bool);
        public static readonly FunctionSymbol Send = new FunctionSymbol("send", ImmutableArray.Create(new ParameterSymbol("text", TypeSymbol.String)), TypeSymbol.Void);

        internal static IEnumerable<FunctionSymbol> GetAll()
            => typeof(BuiltinFunctions).GetFields(BindingFlags.Public | BindingFlags.Static)
                                       .Where(f => f.FieldType == typeof(FunctionSymbol))
                                       .Select(f => (FunctionSymbol)f.GetValue(null));
    }
}
