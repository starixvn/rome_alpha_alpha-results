namespace Alpha.Results.Site.Services.Impl.Products
{
    using System;
    using System.Collections.Generic;
    using Fanex.Logging;
    using Fanex.Result.Core.CockFighting;
    using Fanex.Result.Core.CockFighting.Exceptions;
    using Models.Requests;

    public class CockfightingService : ICockfightingResultService
    {
        private readonly ICockFightingAPI _cockfightingApi;
        private readonly ILogger _logger;

        private readonly static IDictionary<string, string> _languageCodes = new Dictionary<string, string>
        {
            { "E", "EN" },
            { "J", "JP" },
            { "CT", "CH" },
            { "CS", "CS" },
            { "TH", "TH" },
            { "KO", "KO" },
            { "VI", "VI" },
        };

        public CockfightingService(ICockFightingAPI cockFightingApi, ILogger logger)
        {
            _cockfightingApi = cockFightingApi;
            _logger = logger;
        }

        public string GetResultUrl(CockfightingResultQuery request)
        {
            var languageCode = "EN";

            if (_languageCodes.ContainsKey(request.LanguageKey))
            {
                languageCode = _languageCodes[request.LanguageKey];
            }

            try
            {
                return _cockfightingApi.GetResultToken(request.CustomerId.ToString(), languageCode);
            }
            catch(CockFightingException ex)
            {
                _logger.Error(ex.Message, ex.InnerException);

                return string.Empty;
            }
        }
    }
}