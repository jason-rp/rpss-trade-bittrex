using System.Collections.Generic;
using RPSS.Trade.Bittrex.Core.Models;

namespace RPSS.Trade.Bittrex.Core
{
    public class BittrexWatcher
    {
        private readonly BittrexClient _bittrexClient;

        public BittrexWatcher()
        {
            _bittrexClient = new BittrexClient();
        }

        public ApiResult<AccountBalanceModel[]> GetBalances()
        {
            return _bittrexClient.GetBalances().Result;
        }
    }
}
