

using RPSS.Trade.Bittrex.Core.Interfaces;

namespace RPSS.Trade.Bittrex.Core
{
    public static class DecisionExtension
    {
        public static IDecision GetFollowOnDecisionBranch(this IDecision decision, int key)
        {
            // the following decision-node to exec if any ...
            IDecision followOn = null;

            // which branch to go down ? Note : user choices on on [1,2,3...] but the index is zero based, therefore take away 1
            var index = key;

            if (decision.Branches.ContainsKey(index))
            {
                followOn = decision.Branches[index];
            }

            // Return
            return followOn;
        }
    }
}
