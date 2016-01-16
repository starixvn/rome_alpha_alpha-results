namespace Alpha.Results.Site.Handlers
{
    using System;
    using MediatR;
    using Models.Requests;
    using Models.Views;
    using Services;

    public class CockfightingResultHandler :
        IRequestHandler<CockfightingResultQuery, CockfightingResultViewModel>
    {
        private readonly ICockfightingResultService _cockfightingResultService;

        public CockfightingResultHandler(ICockfightingResultService cockfightingResultService)
        {
            _cockfightingResultService = cockfightingResultService;
        }

        public CockfightingResultViewModel Handle(CockfightingResultQuery message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message), "CockfightingResultQuery cannot be null");
            }

            var resultUrl = _cockfightingResultService.GetResultUrl(message);

            return new CockfightingResultViewModel
            {
                IsSuccess = !string.IsNullOrEmpty(resultUrl),
                Url = resultUrl
            };
        }
    }
}