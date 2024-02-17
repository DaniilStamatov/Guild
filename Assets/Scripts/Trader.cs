using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Trader
{
    public Strategy Strategy { get;  }
    public string Name { get;  }

    public int Profit;
    public Dictionary<Trader, List<bool>> TradeHistory { get;  }

    public Trader(string name, Strategy strategy)
    {
        this.Name = name;
        this.Strategy = strategy;
        TradeHistory = new Dictionary<Trader, List<bool>>();
    }


    public bool Cooperate(Trader oponent)
    {
        double errorChance = Random.value;
        if (errorChance <= 0.05)
        {
            return !Strategy.Cooperate(this, oponent);
        }
        return Strategy.Cooperate(this, oponent);
    }
    public void UpdateProfit(int amount)
    {
        Profit += amount;
    }

    public void ResetProfit()
    {
        Profit = 0;
    }

    public void ResetTradeHistory()
    {
        TradeHistory.Clear();
    }
   
}
