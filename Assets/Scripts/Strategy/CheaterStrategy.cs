namespace DefaultNamespace
{
    public class CheaterStrategy : Strategy
    {
        public override bool Cooperate(Trader trader, Trader oponent)
        {
            return false;
        }

    }
}