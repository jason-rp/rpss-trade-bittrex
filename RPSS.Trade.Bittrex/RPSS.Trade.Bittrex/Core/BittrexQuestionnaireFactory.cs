using System;
using System.Collections.Generic;
using RPSS.Trade.Bittrex.Core.Interfaces;

namespace RPSS.Trade.Bittrex.Core
{
    public static class BittrexQuestionnaireFactory
    {

        public static Decision GetBittrexQuestionnaire()
        {
            var accountDecision =  GetAccountInfoDecision();

            var question =
                GetStartDecision(branches: new Dictionary<int, IDecision> {{1, accountDecision}, {2, accountDecision}});

            return question;
        }

        public static Decision GetAccountInfoDecision(Dictionary<int, IDecision> branches = null)
        {
            branches = branches ?? new Dictionary<int, IDecision> { };

            // question and decision
            Action<IDecision, IDecision> question = (d, a) =>
            {
                if (d is AccountInformationDecision decision)
                {
                    // ask question
                    Console.WriteLine("{0}", decision.Question);
                    var ans = Console.ReadLine() ?? string.Empty;

                    //var branchChoice = Convert.ToInt32(ans);
                    var branchChoice = (int) BranchChoiceEnum.BranchA;

                    // assign/calculate properties of the decision
                    decision.AccountInfo = (AccountInfoEnum) Convert.ToInt32(ans);
                    decision.Amount = 7.4f;

                    // assign branch choice given users answers
                    decision.Result = branchChoice;
                }
            };

            var breadTypeDecision = new AccountInformationDecision
            {
                Question = string.Format("[/1] {0} ?", Enum<AccountInfoEnum>.EnumsStringSummary()),
                Mutator = question,
                Branches = branches
            };

            // Return
            return breadTypeDecision;
        }

        public static Decision GetStartDecision(Dictionary<int, IDecision> branches = null)
        {
            branches = branches ?? new Dictionary<int, IDecision> { };

            Action<IDecision, IDecision> question = (d, a) =>
            {
                var decision = d as BittrexStartDecision;

                if (decision != null)
                {
                    // ask question
                    Console.WriteLine("{0}", decision.Question);
                    var ans = Console.ReadLine() ?? string.Empty;

                    // branch choice ...
                    var branchChoice = Convert.ToInt32(ans);
                    //var branchChoice = (int)BranchChoiceEnum.NotKnown;

                    // assign/calculate properties of the decision
                    decision.BittrexGroupOder = (BittrexGroupOderEnum) branchChoice;
                    decision.Amount = 3.2f;

                    // assign branch choice given users answers
                    decision.Result = branchChoice;
                }
            };
            var questionnaire = new BittrexStartDecision
            {
                Question = string.Format("[/1] {0} ?", Enum<BittrexGroupOderEnum>.EnumsStringSummary()),
                Mutator = question,
                Branches = branches
            };

            return questionnaire;
        }
    }
}
