﻿using System.Collections.Immutable;
using Trillium.CodeAnalysis;
using Trillium.Text;

namespace Trillium.Syntax
{
    public sealed class SyntaxTree
    {
        private delegate void ParseHandler(SyntaxTree syntaxTree,
                                           out CompilationUnitSyntax root,
                                           out ImmutableArray<Diagnostic> diagnostics);
        
        private SyntaxTree(SourceText text, bool preventLoopsAndRecursion, ParseHandler handler)
        {
            Text = text;
            PreventLoopsAndRecursion = preventLoopsAndRecursion;

            handler(this, out var root, out var diagnostics);

            Diagnostics = diagnostics;
            Root = root;
        }

        public SourceText Text { get; }
        public ImmutableArray<Diagnostic> Diagnostics { get; }
        public CompilationUnitSyntax Root { get; }

        public readonly bool PreventLoopsAndRecursion;

        public static SyntaxTree Load(string fileName)
        {
            var text = File.ReadAllText(fileName);
            var sourceText = SourceText.From(text, fileName);
            return Parse(sourceText);
        }

        private static void Parse(SyntaxTree syntaxTree, out CompilationUnitSyntax root, out ImmutableArray<Diagnostic> diagnostics)
        {
            var parser = new Parser(syntaxTree);
            root = parser.ParseCompilationUnit();
            diagnostics = parser.Diagnostics.ToImmutableArray();
        }

        public static SyntaxTree Parse(string text, bool preventLoopsAndRecursion = false)
        {
            var sourceText = SourceText.From(text);
            return Parse(sourceText, preventLoopsAndRecursion);
        }

        public static SyntaxTree Parse(SourceText text, bool preventLoopsAndRecursion = false)
        {
            return new SyntaxTree(text, preventLoopsAndRecursion, Parse);
        }

        public static ImmutableArray<SyntaxToken> ParseTokens(string text)
        {
            var sourceText = SourceText.From(text);
            return ParseTokens(sourceText);
        }

        public static ImmutableArray<SyntaxToken> ParseTokens(string text, out ImmutableArray<Diagnostic> diagnostics, bool preventLoopsAndRecursion = false)
        {
            var sourceText = SourceText.From(text);
            return ParseTokens(sourceText, out diagnostics, preventLoopsAndRecursion);
        }

        public static ImmutableArray<SyntaxToken> ParseTokens(SourceText text, bool preventLoopsAndRecursion = false)
        {
            return ParseTokens(text, out _, preventLoopsAndRecursion);
        }

        public static ImmutableArray<SyntaxToken> ParseTokens(SourceText text, out ImmutableArray<Diagnostic> diagnostics, bool preventLoopsAndRecursion = false)
        {
            var tokens = new List<SyntaxToken>();

            void ParseTokens(SyntaxTree st, out CompilationUnitSyntax root, out ImmutableArray<Diagnostic> d)
            {
                root = null;

                var l = new Lexer(st);
                while (true)
                {
                    var token = l.Lex();
                    if (token.Kind == SyntaxKind.EndOfFileToken)
                    {
                        root = new CompilationUnitSyntax(st, ImmutableArray<MemberSyntax>.Empty, token);
                        break;
                    }

                    tokens.Add(token);
                }

                d = l.Diagnostics.ToImmutableArray();
            }

            var syntaxTree = new SyntaxTree(text, preventLoopsAndRecursion, ParseTokens);
            diagnostics = syntaxTree.Diagnostics.ToImmutableArray();
            return tokens.ToImmutableArray();
        }
    }
}