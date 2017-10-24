namespace Alpha.Results.Site.Services.Impl
{
    using System;
    using Constants;
    using Fanex.Result.Core.Base.Models;
    using Fanex.Result.Core.GlobalGaming;
    using Fanex.Result.Core.GlobalGaming.DTO;
    using Models.HandHistory;
    using Models.Requests;

    public class FishingWorldResultService : IFishingWorldResultService
    {
        private readonly Base3rdResultApi _globalGamingResultApi;

        public FishingWorldResultService(Base3rdResultApi globalGamingResultApi)
        {
            _globalGamingResultApi = globalGamingResultApi ?? new GlobalGamingResultApi();
        }

        public HandHistoryModel GetResult(FishingWorldResultQuery request)
        {
            try
            {
                var siteId = GetSiteId(request.RoleId);

                var iframe = _globalGamingResultApi.GetResultUrl(new GlobalGamingDTO
                {
                    CustId = request.CustId.ToString(),
                    GameId = request.RefNo,
                    SiteId = siteId.ToString(),
                    Language = request.Language
                });

                return new HandHistoryModel(iframe, true, string.Empty);
            }
            catch (Exception ex)
            {
                return new HandHistoryModel(string.Empty, false, ex.Message);
            }
        }

        private static int GetSiteId(int roleId) =>
            roleId.Equals(RoleIdConstants.Agent) ? 3000 :
            roleId.Equals(RoleIdConstants.Master) ? 3100 :
            3200;
    }
}
