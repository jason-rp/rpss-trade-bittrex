using RPSS.Trade.Bittrex.Core;
using Topshelf;
using Topshelf.Hosts;
using Topshelf.Logging;

namespace RPSS.Trade.Bittrex
{
    public class BittrexWathcherService
    {
        private static readonly LogWriter LogWriter = HostLogger.Get<BittrexWathcherService>();
        private BittrexWatcher _bittrexWatcher;
        public  void Start()
        {
            LogWriter.InfoFormat("Start");
            _bittrexWatcher = new BittrexWatcher();

            var f =  _bittrexWatcher.GetBalances();

            var ff = 1;
        }

        public bool Stop()
        {
            return true;
        }
    }
}
