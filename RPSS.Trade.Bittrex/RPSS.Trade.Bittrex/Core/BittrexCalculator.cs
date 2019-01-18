using System;
using RPSS.Trade.Bittrex.Core.Models;

namespace RPSS.Trade.Bittrex.Core
{
    public class BittrexCalculator
    {
        private readonly BittrexClient _bittrexClient;

        public BittrexCalculator()
        {
            _bittrexClient = new BittrexClient();
        }

        public void AutoOpenOrder()
        {
            Console.Write("Currency Code:");
            var currencyCode = Console.ReadLine();

            Console.WriteLine(GetBalance(currencyCode).Result.Available);
        }
        
        public ApiResult<AccountBalanceModel[]> GetBalances()
        {
            return _bittrexClient.GetBalances().Result;
        }

        public ApiResult<AccountBalanceModel> GetBalance(string currency)
        {
            return _bittrexClient.GetBalance(currency).Result;
        }



    }
}
