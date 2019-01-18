using System;
using System.Collections.Generic;

namespace RPSS.Trade.Bittrex.Core.Interfaces
{
    public interface IDecision
    {
        int Result { get; set; }

        float Amount { get; set; }

        string Question { get; set; }

        Action<IDecision, IDecision> Mutator { get; set; }

        Dictionary<int, IDecision> Branches { get; set; }

        IDecision Evaluate();

        string GetDecisionSummary();

        List<IDecision> ChosenOnes(List<IDecision> branches);

        IDecision GetNext(IDecision d);

        IDecision EvaluateNextOneGetFollowOnBranch(IDecision questionnaire);

        string Explantion();
    }
}
