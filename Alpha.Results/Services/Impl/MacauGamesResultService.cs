namespace Alpha.Results.Site.Services.Impl
{
    using System;
    using Fanex.Result.Core.Voidbridge;
    using Models.HandHistory;
    using Models.Requests;

    public class MacauGamesResultService : IMacauGamesResultService
    {
        private readonly VoidbridgeApi _voidbridgeApi;

        public MacauGamesResultService(VoidbridgeApi voidbridgeApi)
        {
            _voidbridgeApi = voidbridgeApi;
        }

        public HandHistoryModel GetResult(MacauGamesResultQuery request)
        {
            try
            {
                var iframe = _voidbridgeApi.GetBetHistoryUrl(request.CustId.ToString(), request.RefNo, request.Language, request.SiteId.ToString());

                return new HandHistoryModel(iframe, true, string.Empty);
            }
            catch (Exception ex)
            {
                return new HandHistoryModel(string.Empty, false, ex.Message);
            }
        }
    }
}
