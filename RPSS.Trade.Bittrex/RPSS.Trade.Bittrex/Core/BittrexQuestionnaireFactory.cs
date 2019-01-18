using System;
using System.Collections.Generic;
using RPSS.Trade.Bittrex.Core.Interfaces;

namespace RPSS.Trade.Bittrex.Core
{
    public static class BittrexQuestionnaireFactory
    {

        public static Decision GetBittrexQuestionnaire()
        {
            return GetAccountInfoDecision();
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
    }
}
