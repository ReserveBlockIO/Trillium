﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trillium.Binding
{
    internal sealed class BoundDoWhileStatement : BoundLoopStatement
    {
        public BoundDoWhileStatement(BoundStatement body, BoundExpression condition, BoundLabel breakLabel, BoundLabel continueLabel)
            : base(breakLabel, continueLabel)
        {
            Body = body;
            Condition = condition;
        }

        public override BoundNodeKind Kind => BoundNodeKind.DoWhileStatement;
        public BoundStatement Body { get; }
        public BoundExpression Condition { get; }
    }
}
