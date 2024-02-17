using System.Linq;

namespace DefaultNamespace
{
    public class SlyStrategy : Strategy
    {
        public override bool Cooperate(Trader trader, Trader oponent)
        {
            
            if (trader.TradeHistory.ContainsKey(oponent) && trader.TradeHistory.TryGetValue(oponent, out var deals))
            {
                if (deals.Count < 4)
                {
                    if (deals.Count == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                if (deals.Count >= 5)
                {
                    for (int i = 0; i < deals.Count - 1; i++)
                    {
                        if (deals[i].Equals(false))
                        {
                            return false;
                        }
                    }

                    return deals.Last();
                }
               
            }

            return false; 
        }

       
    }
}