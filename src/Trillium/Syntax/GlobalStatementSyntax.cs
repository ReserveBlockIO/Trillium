using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trillium.Syntax
{
    public sealed class GlobalStatementSyntax : MemberSyntax
    {
        public GlobalStatementSyntax(StatementSyntax statement)
        {
            Statement = statement;
        }

        public override SyntaxKind Kind => SyntaxKind.GlobalStatement;
        public StatementSyntax Statement { get; }
    }
}
