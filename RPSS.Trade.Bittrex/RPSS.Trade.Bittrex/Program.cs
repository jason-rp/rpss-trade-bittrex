using Topshelf;
using Topshelf.Hosts;

namespace RPSS.Trade.Bittrex
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(n =>
            {
                n.UseLog4Net();
                n.Service<BittrexWathcherService>(i =>
                {
                    i.ConstructUsing(() => new BittrexWathcherService());
                    i.WhenStarted(e => e.Start());
                    i.WhenStopped(e => e.Stop());
                });

                n.SetServiceName("RPSS.Bittrex.Watcher");
                n.SetDisplayName("RPSS.Bittrex.Watcher");
                n.SetDescription("RPSS Bittrex Watcher");

                n.StartManually();
            });
        }
        
    }
}
