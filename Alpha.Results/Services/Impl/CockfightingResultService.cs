namespace Alpha.Results.Site.Services.Impl
{
    using System.Collections.Generic;
    using Fanex.Logging;
    using Fanex.Result.Core.CockFighting;
    using Fanex.Result.Core.CockFighting.Exceptions;
    using Models.Requests;

    public class CockfightingResultService : ICockfightingResultService
    {
        private const string DefaultLanguageKey = "EN";

        private static readonly IDictionary<string, string> _languageCodes = new Dictionary<string, string>
        {
            { "E", DefaultLanguageKey },
            { "J", "JP" },
            { "CT", "CH" },
            { "CS", "CS" },
            { "TH", "TH" },
            { "KO", "KO" },
            { "VI", "VI" },
        };

        private readonly ICockFightingAPI _cockfightingApi;
        private readonly ILogger _logger;

        public CockfightingResultService(ICockFightingAPI cockFightingApi, ILogger logger)
        {
            _cockfightingApi = cockFightingApi;
            _logger = logger;
        }

        public string GetResultUrl(CockfightingResultQuery request)
        {
            try
            {
                if (request.IsKeepAlive.HasValue && request.IsKeepAlive.Value)
                {
                    return _cockfightingApi.ExtendToken(request.CustomerId.ToString());
                }

                var languageCode = _languageCodes.ContainsKey(request.LanguageKey)
                    ? _languageCodes[request.LanguageKey]
                    : DefaultLanguageKey;

                return _cockfightingApi.GetResultToken(request.CustomerId.ToString(), languageCode);
            }
            catch (CockFightingException ex)
            {
                _logger.Error(ex.Message, ex.InnerException);

                return string.Empty;
            }
        }
    }
}