using System;
using System.Linq;

namespace RPSS.Trade.Bittrex.Core
{
    public static class Enum<T>
    {
        public static string EnumsStringSummary()
        {
            return Enum.GetValues(typeof(T))
                .Cast<int>()
                .Aggregate(string.Empty,
                    (current, val) => current + String.Format("{1}-{0}, ", val, Enum.GetName(typeof(T), val)));
        }
    }
}
