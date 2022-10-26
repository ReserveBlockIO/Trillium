using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trillium.Syntax;

namespace TrilliumTest.Extensions
{
    public static class SyntaxNodeExtensions
    {
        public static IEnumerable<SyntaxNode> Descendants(this SyntaxNode node)
        {
            yield return node;
            foreach (var child in node.GetChildren())
                foreach (var descendant in Descendants(child))
                    yield return descendant;
        }
    }
}
