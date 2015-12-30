namespace Alpha.Results.Services.Impl.Products
{
    using System;
    using System.IO;
    using System.Linq;
    using Alpha.Results.Criteria;
    using Alpha.Results.DataAccesses;
    using DataAccesses.Impl;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Models.Requests;

    /// <summary>
    /// The class RacingResultService.
    /// </summary>
    public class RacingResultService : IProductResultService
    {
        private readonly IRacingResultDataAccess _dataAccess;

        public RacingResultService(IRacingResultDataAccess dataAccess)
        {
            _dataAccess = dataAccess ?? new RacingResultDataAccess();
        }

        public RacingResultService()
            : this(null)
        {
        }

        public string GetResult(ViewNormalResultQuery request)
        {
            var criteria = GetCriteria(request);

            var results = _dataAccess.GetRacingResults(criteria).ToList();

            var resultSetting = new ResultSetting
            {
                SportType = (SportType)request.SportId,
                LanguageCode = request.Language,
                VisibleDetailedLink = true,
                VisibleFreeHeader = true,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };

            return ResultEngine.HtmlParser(results, resultSetting);
        }

        public MemoryStream ExportExcel(DownloadNormalResultExcelQuery request)
        {
            var resultSetting = new ResultSetting
            {
                SportType = (SportType)request.SportId,
                LanguageCode = request.Language,
                ExcelTitle = request.ToExcelTitle(),
                ExcelTemplatePath = request.TemplatePath,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };

            var results = _dataAccess.GetRacingResults(GetCriteria(request)).ToList();

            return ResultEngine.ExcelParser(results, resultSetting);
        }

        private static GetRacingResultCriteria GetCriteria(ViewNormalResultQuery request)
        {
            return new GetRacingResultCriteria()
            {
                FromDate = request.ResultDate,
                SportType = request.SportId,
                LeagueID = request.LeagueId
            };
        }

        public string GetResultDetails(ViewNormalResultDetailsQuery detailsRequest)
        {
            var criteria = new GetRacingResultDetailsCriteria()
            {
                MatchId = detailsRequest.MatchId,
                RaceNo = GetRaceNumber(detailsRequest.Race)
            };

            var results = _dataAccess.GetRacingResultDetails(criteria);

            ResultSetting resultSetting = new ResultSetting
            {
                SportType = (SportType)detailsRequest.SportId,
                IsOutRight = false,
                IsParlayPopUp = false,
                IsPopUp = true,
                VisiblePopUpTitle = false,
                LanguageCode = detailsRequest.Language,
                VisibleMatchCodeIDColumn = false,
                VisibleFreeHeader = true,
                VisibleDetailedLink = true,
                HighlightWinnerTeam = true
            };

            return ResultEngine.HtmlParser(results, resultSetting);
        }

        private int GetRaceNumber(string raceNumber)
        {
            if (string.IsNullOrEmpty(raceNumber) || raceNumber == "0")
            {
                return 0;
            }

            try
            {
                return int.Parse(raceNumber);
            }
            catch (Exception exception)
            {
                if (exception is NotFiniteNumberException || exception is FormatException)
                {
                    return 0;
                }

                throw;
            }
        }
    }
}