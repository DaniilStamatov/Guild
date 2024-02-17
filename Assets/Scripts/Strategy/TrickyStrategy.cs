using System.Collections.Generic;
using System.Linq;

namespace DefaultNamespace
{
    public class TrickyStrategy : Strategy
    {
        private bool _isFirstMove = true;
       
        public override bool Cooperate(Trader trader,  Trader oponent)
        {
            if (trader.TradeHistory.ContainsKey(trader) && trader.TradeHistory.TryGetValue(trader, out var deals))
            {
                var lastDecision = deals.Last();
                return lastDecision;
            }

            return true;
        }

    }
}