namespace Alpha.Results.Site.Services.Impl
{
    using System;
    using Fanex.Result.Core.GlobalGaming;
    using Fanex.Result.Core.GlobalGaming.DTO;
    using Models.HandHistory;
    using Models.Requests;

    public class FishingWorldResultService : IFishingWorldResultService
    {
        public HandHistoryModel GetResult(FishingWorldResultQuery request)
        {
            try
            {
                var globalGamingResultApi = new GlobalGamingResultApi();

                var iframe = globalGamingResultApi.GetResultUrl(new GlobalGamingDTO
                {
                    CustId = request.CustId.ToString(),
                    GameId = request.RefNo,
                    SiteId = request.SiteId.ToString(),
                    Language = request.Language
                });

                return new HandHistoryModel(iframe, true, string.Empty);
            }
            catch (Exception ex)
            {
                return new HandHistoryModel(string.Empty, false, ex.Message);
            }
        }
    }
}
