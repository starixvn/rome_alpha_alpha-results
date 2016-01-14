namespace Alpha.Results.Site.Handlers
{
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
            var resultUrl = _cockfightingResultService.GetResultUrl(message);

            return new CockfightingResultViewModel
            {
                IsSuccess = !string.IsNullOrEmpty(resultUrl),
                Url = resultUrl
            };
        }
    }
}