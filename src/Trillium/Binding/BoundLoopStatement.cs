using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trillium.Binding
{
    internal abstract class BoundLoopStatement : BoundStatement
    {
        protected BoundLoopStatement(BoundLabel breakLabel, BoundLabel continueLabel)
        {
            BreakLabel = breakLabel;
            ContinueLabel = continueLabel;
        }

        public BoundLabel BreakLabel { get; }
        public BoundLabel ContinueLabel { get; }
    }
}
