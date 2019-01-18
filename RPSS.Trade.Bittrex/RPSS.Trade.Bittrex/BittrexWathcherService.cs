using System;
using System.Linq;
using RPSS.Trade.Bittrex.Core;
using RPSS.Trade.Bittrex.Core.Interfaces;
using Topshelf;
using Topshelf.Hosts;
using Topshelf.Logging;

namespace RPSS.Trade.Bittrex
{
    public class BittrexWathcherService
    {
        private static readonly LogWriter LogWriter = HostLogger.Get<BittrexWathcherService>();
        private BittrexCalculator _bittrexWatcher;
        public  void Start()
        {
            LogWriter.InfoFormat("Start");
            _bittrexWatcher = new BittrexCalculator();

            var question = BittrexQuestionnaireFactory.GetStartDecision();

            Console.ReadLine();

            IDecision q = question;
            while (q != null)
            {
                if (q.Result == 0)
                {
                    q.Mutator(q, null);
                }

                var nxt = q.GetFollowOnDecisionBranch(q.Result);
                q = nxt;
            }

            var explanation = question.Explantion();
            Console.WriteLine("{0}", explanation);

            var chosenOnes = question.ChosenOnes(null);
            var cost = chosenOnes.Aggregate(0.0f, (current, chosenOne) => current + chosenOne.Amount);
            Console.WriteLine("cost: {0}", cost);
            

            // press a key to continue
            Console.ReadLine();

            

            //while (true)
            //{
            //    _bittrexWatcher.AutoOpenOrder();
            //}
        }

        public bool Stop()
        {
            return true;
        }
    }
}
