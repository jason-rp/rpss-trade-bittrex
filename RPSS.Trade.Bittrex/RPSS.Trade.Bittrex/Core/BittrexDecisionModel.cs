using System;

namespace RPSS.Trade.Bittrex.Core
{

    public enum AccountInfoEnum
    {
        GetBalances = 1, GetBalance = 2, GetDepositaddress = 3
    }

    public class AccountInformationDecision : Decision
    {
        public AccountInfoEnum AccountInfo { get; set; }

        public override string GetDecisionSummary()
        {
            return string.Format(
                "Branch:{4} : {1} ; Enum: {3} ;{0}"
                , Environment.NewLine
                , GetType().ToString()
                , Question
                , AccountInfo
                , Result
                , Amount
            );
        }
    }
}
