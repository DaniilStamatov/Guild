using System.Collections.Generic;

namespace DefaultNamespace
{
    public class GrudgeStrategy : Strategy
    {
        private bool isCheating;
        public override bool Cooperate(Trader trader, Trader oponent)
        {
            if (trader.TradeHistory.ContainsKey(oponent) && trader.TradeHistory.TryGetValue(oponent, out var deals))
            {
                if (deals.Contains(false))
                {
                    return false;
                }
            }

            return true;
        }
    }
}