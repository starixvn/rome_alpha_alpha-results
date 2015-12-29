namespace Alpha.Results.Services.Impl.Products
{
    using System;
    using System.IO;
    using System.Linq;
    using Alpha.Results.Criteria;
    using Alpha.Results.DataAccesses;
    using Alpha.Results.DataAccesses.Impl.Result;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Models;

    /// <summary>
    /// The class VirtualRacingResultService.
    /// </summary>R
    public class VirtualRacingResultService : IProductResultService
    {
        private readonly IVirtualRacingResultDataAccess _racingResultDataAccess;

        public VirtualRacingResultService(IVirtualRacingResultDataAccess racingResultDataAccess)
        {
            this._racingResultDataAccess = racingResultDataAccess ?? new VirtualRacingResultDataAccess();
        }

        public VirtualRacingResultService()
            : this(null)
        {
        }

        public string GetResult(NormalRequest request)
        {
            var criteria = GetCriteria(request);

            var results = _racingResultDataAccess.GetVirtualRacingResults(criteria).ToList();

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

        public MemoryStream ExportExcel(NormalRequest request, string excelTemplatePath)
        {
            var resultSetting = new ResultSetting
            {
                SportType = (SportType)request.SportId,
                LanguageCode = request.Language,
                ExcelTitle = request.ToExcelTitle(),
                ExcelTemplatePath = excelTemplatePath,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };

            var results = _racingResultDataAccess.GetVirtualRacingResults(GetCriteria(request)).ToList();

            return ResultEngine.ExcelParser(results, resultSetting);
        }

        private static GetVirtualRacingResultCriteria GetCriteria(NormalRequest request)
        {
            return new GetVirtualRacingResultCriteria()
            {
                FromDate = request.ResultDate,
                SportType = request.SportId,
                LeagueID = request.LeagueId
            };
        }

        public string GetResultDetails(NormalDetailsRequest detailsRequest)
        {
            var criteria = new GetRacingResultDetailsCriteria()
            {
                MatchId = detailsRequest.MatchId,
                RaceNo = GetRaceNumber(detailsRequest.Race)
            };

            var results = _racingResultDataAccess.GetVirtualRacingResultDetails(criteria);

            var resultSetting = new ResultSetting
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