using System;

namespace Stocks
{
    public class Stock
    {
        /*public static void Main()
        {
            int[] stockPrices = { 10, 7, 5, 8, 11, 9 };
            int got = Stock.GetMaxProfit(stockPrices);
            int exp = 6;
            Console.WriteLine((exp, got));
        }*/
        public static int GetMaxProfit(int[] stockPrices)
        {
            if (stockPrices.Length < 2)
            {
                throw new ArgumentException();}
            int min = int.MaxValue;
            int diff = int.MinValue;
            for (int i = 0; i < stockPrices.Length; i++) {
                if (stockPrices[i] < min) {
                    for (int j = i+1; j < stockPrices.Length; j++) {
                        if ((stockPrices[j] - stockPrices[i]) > diff)
                        {
                            diff = stockPrices[j] - stockPrices[i];
                        }
                    }
                }
            }
           return diff;
        }
    }
}