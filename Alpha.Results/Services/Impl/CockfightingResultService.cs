namespace Alpha.Results.Site.Services.Impl
{
    using System.Collections.Generic;
    using Fanex.Logging;
    using Fanex.Result.Core.CockFighting;
    using Fanex.Result.Core.CockFighting.Exceptions;
    using Models.Requests;

    public class CockfightingResultService : ICockfightingResultService
    {
        private const string DefaultLanguageKey = "en";

        private static readonly IDictionary<string, string> LanguageCodes = new Dictionary<string, string>
        {
            { "E", DefaultLanguageKey },
            { "J", "jp" },
            { "CT", "ch" },
            { "CS", "cs" },
            { "TH", "th" },
            { "KO", "ko" },
            { "VI", "vi" },
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

                var languageCode = request.LanguageKey != null && LanguageCodes.ContainsKey(request.LanguageKey.ToUpper())
                    ? LanguageCodes[request.LanguageKey]
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