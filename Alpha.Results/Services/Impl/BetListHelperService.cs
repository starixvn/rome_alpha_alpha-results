namespace Alpha.Results.Services.Implement
{
    using Alpha.Results.Constants;

    public class BetListHelperService
    {
        public static bool IsMetricGamingBetType(int betType)
        {
            return BetTypeConstants.MetricGaming60sofKick <= betType &&
                betType <= BetTypeConstants.MetricGamingEndBetType;
        }
    }
}