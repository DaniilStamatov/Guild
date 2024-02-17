namespace DefaultNamespace
{
    public class AltruistStrategy : Strategy
    {
        public override bool Cooperate(Trader trader, Trader oponent)
        {
            return true;
        }

  
    }
}