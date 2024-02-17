using System;

namespace DefaultNamespace
{
    public class UnpredictableStrategy : Strategy
    {
        private static readonly Random random = new Random();

        public override bool Cooperate(Trader trader, Trader oponent)
        {
            return random.Next(2) == 0;
        }
    }
}