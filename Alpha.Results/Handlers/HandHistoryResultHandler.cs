namespace Alpha.Results.Site.Handlers
{
    using System;
    using App_GlobalResources;
    using MediatR;
    using Models.Requests;
    using Models.Views;
    using Services;

    public class HandHistoryResultHandler :
        IRequestHandler<RNGCasinoResultQuery, HandHistoryResultViewModel>,
        IRequestHandler<MacauGamesResultQuery, HandHistoryResultViewModel>,
        IRequestHandler<FishingWorldResultQuery, HandHistoryResultViewModel>
    {
        private readonly IRNGCasinoResultService _rngCasinoResultService;
        private readonly IMacauGamesResultService _macauGamesResultService;
        private readonly IFishingWorldResultService _fishingWorldResultService;

        public HandHistoryResultHandler(
            IRNGCasinoResultService rngCasinoResultService,
            IMacauGamesResultService macauGamesResultService,
            IFishingWorldResultService fishingWorldResultService)
        {
            _rngCasinoResultService = rngCasinoResultService;
            _macauGamesResultService = macauGamesResultService;
            _fishingWorldResultService = fishingWorldResultService;
        }

        public HandHistoryResultViewModel Handle(RNGCasinoResultQuery message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message), "RnGCasinoResultQuery cannot be null");
            }

            var result = _rngCasinoResultService.GetResult(message);

            return new HandHistoryResultViewModel(Resources.Product_6, result);
        }

        public HandHistoryResultViewModel Handle(MacauGamesResultQuery message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message), "MacauGamesResultQuery cannot be null");
            }

            var result = _macauGamesResultService.GetResult(message);

            return new HandHistoryResultViewModel(Resources.Voidbridge, result);
        }

        public HandHistoryResultViewModel Handle(FishingWorldResultQuery message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message), "FishingWorldResultQuery cannot be null");
            }

            var result = _fishingWorldResultService.GetResult(message);

            return new HandHistoryResultViewModel(Resources.FishingWorld, result);
        }
    }
}
