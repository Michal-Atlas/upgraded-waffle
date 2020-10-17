using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractise
{
    public class TradeHistory
    {
        private readonly List<Transaction> _transactions;

        public TradeHistory(List<Transaction> transactions)
        {
            _transactions = transactions;
        }

        public void Test()
        {
            var list = new List<int>
            {
                1,2,3,4,5,5
            };

            list.Add(5);

            list.Where((number) => number == 5);
        }


        /// <summary>
        /// Find all transactions in 2011 and order it by value
        /// </summary>
        /// <returns></returns>
        public List<Transaction> FindAllTransactionsIn2011AndSortByValueAsc()
        {
            return new List<Transaction>(
                _transactions
                    .Where(x => x.Year == 2011)
                    .OrderBy(x => x.Value));
        }

        /// <summary>
        /// List unique cities
        /// </summary>
        /// <returns></returns>
        public List<string> GetUniqueCitiesSortedAsc()
        {
            return new List<string>(
                _transactions
                    .Select(x=>x.Trader.City)
                    .Distinct()
                    .OrderBy(x=>x));
        }

        /// <summary>
        /// Get single string of traders in format “Traders: name1 name2 … ”
        /// String shall start with "Traders:" and use space as separator. E.g.: "Traders: Bob George"
        /// </summary>
        /// <returns></returns>
        public string GetSingleStringFromUniqueTradersNamesSortByNameAsc()
        {
            return $"Traders: " + String.Join(" ",_transactions
                .Select(x => x.Trader.Name).Distinct()
                .OrderBy(x => x)
                .ToList());
        }

        /// <summary>
        /// Does trader exists for specified <see cref="cityName"/>
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public bool IsSomeTraderFromCity(string cityName)
        {
            return _transactions
                .Exists(x=>x.Trader.City == cityName);
        }

        /// <summary>
        /// Get traders grouped by city
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<Trader>> GetTradersByTown()
        {
           return new Dictionary<string, List<Trader>>(
               _transactions
                   .Select(x=>x.Trader).Distinct()
                   .GroupBy(x=>x.City)
                   .ToDictionary(x=>x.Key, y=>y.ToList()));
        }

        /// <summary>
        /// Get number of traders grouped by city
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, long> GetTradersCountsByTown()
        {
            return new Dictionary<string, long>(
                _transactions
                    .Select(x=>x.Trader).Distinct()
                    .GroupBy(x=>x.City)
                    .ToDictionary(key=> key.Key, y => (long)y.Count())
                );
        }

    }
}
