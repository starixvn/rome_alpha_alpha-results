namespace Alpha.Results.Site.Services.Impl
{
    using Products;
    using Sunplus.Agent.Model.BL.Definitions;
    using System.Diagnostics.CodeAnalysis;

    public class ResultServiceFactory : IResultServiceFactory
    {
        public const int MetricGaming60SecondOfKick = 801;
        public const int MetricGamingEndBetType = 899;

        [SuppressMessage("StyleCop.CSharp.Nexcel.NexcelCustomRules", "SP2101:MethodMustNotContainMoreLinesThan", Justification = "Reviewed.")]
        public IProductResultService CreateProductResultService(int sportId, int betTypeId)
        {
            if (betTypeId == (int)BetType.Mix_Parlay
                || betTypeId == (int)BetType.Combine_Mix_Parlay)
            {
                return new ParlayResultService();
            }

            switch ((SportType)sportId)
            {
                case SportType.Soccer:
                    if (MetricGaming60SecondOfKick <= betTypeId
                        && betTypeId <= MetricGamingEndBetType)
                    {
                        return new MetricGamingResultService();
                    }

                    return new SportsbookResultService();

                case SportType.HorseRacing:
                case SportType.Greyhound:
                case SportType.Harness:
                    return new RacingResultService();

                case SportType.NumberGame:
                    return new NumberGameResultService();

                case SportType.LiveCasino:
                    return new LiveCasinoResultService();

                case SportType.VirtualHorsesRacing:
                case SportType.VirtualGreyhounds:
                case SportType.VirtualMotors:
                case SportType.VirtualCycling:
                case SportType.VirtualSpeedway:
                    return new VirtualRacingResultService();

                case SportType.GoldDeluxe:
                    return new GoldDeluxeResultService();

                default:
                    return new SportsbookResultService();
            }
        }
    }
}