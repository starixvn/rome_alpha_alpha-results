namespace Alpha.Results.Services.Impl
{
    using Products;
    using Sunplus.Agent.Model.BL.Definitions;

    public class ResultServiceFactory : IResultServiceFactory
    {
        public const int MetricGaming60sofKick = 801;
        public const int MetricGamingEndBetType = 899;

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
                    if (MetricGaming60sofKick <= betTypeId 
                        && betTypeId <= MetricGamingEndBetType)
                    {
                        return new MetricGamingResultService();
                    }

                    return new SportsbookResultService();

                case SportType.BasketBall:
                case SportType.Netball:
                case SportType.FootBall:
                case SportType.Rugby:
                case SportType.IceHockey:
                case SportType.FieldHockey:
                case SportType.Tennis:
                case SportType.VolleyBall:
                case SportType.Badminton:
                case SportType.Squash:
                case SportType.BaseBall:
                case SportType.Golf:
                case SportType.Motorsports:
                case SportType.HRFixedOdds:
                case SportType.Billard:
                case SportType.Cycling:
                case SportType.Fencing:
                case SportType.Judo:
                case SportType.ModernPentathlon:
                case SportType.Rowing:
                case SportType.Sailing:
                case SportType.Shooting:
                case SportType.Taekwondo:
                case SportType.Triathlon:
                case SportType.Wrestling:
                case SportType.Winter:
                case SportType.ESports:
                case SportType.VirtualSports:
                case SportType.VirtualTennis:
                default:
                    return new SportsbookResultService();

                case SportType.HorseRacing:
                case SportType.Greyhound:
                case SportType.Harness:
                    return new RacingResultService();

                case SportType.NumberGame:
                    return new NumberGameResultService();

                case SportType.LiveCasino:
                    return new NumberGameResultService();

                case SportType.VirtualHorsesRacing:
                case SportType.VirtualGreyhounds:
                case SportType.VirtualMotors:
                case SportType.VirtualCycling:
                case SportType.VirtualSpeedway:
                    return new VirtualRacingResultService();

                case SportType.GoldDeluxe:
                    return new GoldDeluxePopupResultService();
            }
        }
    }
}