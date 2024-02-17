using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Guild : MonoBehaviour
    {
        
        List<Trader> traders = new List<Trader>();

        [SerializeField] private Text outputText;

        private void Start()
        {
            SetTraders();
            RunYear();
        }

        public void SetTraders()
        {
            for (int i = 0; i < 10; i++)
            {
                    traders.Add(new Trader("Альтруист", new AltruistStrategy()));
                    traders.Add(new Trader("Кидала", new CheaterStrategy()));
                    traders.Add(new Trader("Хитрец", new TrickyStrategy()));
                    traders.Add(new Trader("Непредсказуемый", new UnpredictableStrategy()));
                    traders.Add(new Trader("Злопамятный", new GrudgeStrategy()));
                    traders.Add(new Trader("Ушлый", new SlyStrategy()));
            }
        }

        private void ConductDeals()
        {
            foreach (Trader trader1 in traders)
            {
                foreach (Trader trader2 in traders)
                {
                    if (trader1 != trader2)
                    {
                        for (int i = 0; i < Random.Range(5, 10); i++)
                        {
                            bool cooperate1 = trader1.Cooperate(trader2);
                            bool cooperate2 = trader2.Cooperate(trader1);
                            if (!trader1.TradeHistory.ContainsKey(trader2))
                            {
                                trader1.TradeHistory[trader2] = new List<bool>();
                            }
                
                            if (!trader2.TradeHistory.ContainsKey(trader1))
                            {
                                trader2.TradeHistory[trader1] = new List<bool>();
                            }
                
                            trader1.TradeHistory[trader2].Add(cooperate2);
                            trader2.TradeHistory[trader1].Add(cooperate1);

                            if (cooperate1 && cooperate2)
                            {
                                trader1.UpdateProfit(4);
                                trader2.UpdateProfit(4);
                            }
                            else if (cooperate1 && !cooperate2)
                            {
                                trader1.UpdateProfit(1);
                                trader2.UpdateProfit(5);
                            }
                            else if (!cooperate1 && cooperate2)
                            {
                                trader1.UpdateProfit(5);
                                trader2.UpdateProfit(1);
                            }
                            else
                            {
                                trader1.UpdateProfit(2);
                                trader2.UpdateProfit(2);
                            }
                        }
                    }
                }
            }
        }

        public void RunYear()
        {
            
            ConductDeals();
            PrintTraders();
            RefreshTable();
            PrintTraders();
            foreach (var trader in traders)
            {
                trader.ResetProfit();
                trader.ResetTradeHistory();
            }
        }

        private void RefreshTable()
        {
            traders.Sort((t1, t2) => t2.Profit.CompareTo(t1.Profit));

            // Удаление наименее прибыльных 20% трейдеров
            int numTradersToDelete = (int)(traders.Count * 0.2);
            int numTradersToReplace = (int)(traders.Count * 0.2);

            traders.RemoveRange(traders.Count - numTradersToDelete, numTradersToDelete);

            // Копирование поведения 20% самых успешных трейдеров
            for (int i = 0; i < numTradersToReplace; i++)
            {
                // Получение нового трейдера, копирующего поведение успешного трейдера
                Trader newTrader = new Trader(traders[i].Name, traders[i].Strategy);

                // Замена наименее прибыльного трейдера на нового трейдера
                traders.Add(newTrader);
            }
        }

        private void PrintTraders()
        {
            string table = "<size=20>Таблица лидеров</size>\n";
            table += "<size=14>---------------------------------------------------------------------------------</size>\n";
            table += "<size=14>| Место | Имя | Стратегия | Прибыль |</size>\n";
            table += "<size=14>---------------------------------------------------------------------------------</size>\n";
            for (int i = 0; i < traders.Count; i++)
            {
                table += $"| {i + 1} | {traders[i].Name} | {traders[i].Strategy} | {traders[i].Profit} |\n";
            }
            table += "<size=14>---------------------------------------------------------------------------------</size>\n";

            outputText.text = table;
        }
    }
}