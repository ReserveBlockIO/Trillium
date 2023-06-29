using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trillium.Utilities
{
    internal class ClassUtility
    {
        public class Token
        {
            public string Name { get; set; }
            public string Ticker { get; set; }
            public int DecimalPlaces { get; set; }
            public int TotalSupply { get; set; }
            public bool IsVotingEnabled { get; set; }
            public bool IsBurningEnabled { get; set; }
            public string? TokenImageURL { get; set; }
            public string? TokenImageBase { get; set; }
            public bool IsTotalSupplyInfinite { get { return TotalSupply == 0 ? true : false; } }
        }
    }
}
