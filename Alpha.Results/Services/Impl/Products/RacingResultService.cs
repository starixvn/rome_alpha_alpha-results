namespace Alpha.Results.Services.Impl.Products
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Alpha.Results.Criteria;
    using Alpha.Results.Repositories;
    using Alpha.Results.Repositories.Impl.Result;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.Racing.DTO;
    using Models;

    /// <summary>
    /// The class RacingResultService.
    /// </summary>
    public class RacingResultService : IProductResultService
    {
        private IRacingResultDataAccess _dataAccess;

        public RacingResultService(IRacingResultDataAccess dataAccess)
        {
            this._dataAccess = dataAccess ?? new RacingResultDataAccess();
        }

        public RacingResultService()
            : this(null)
        {
        }

        public string GetResult(NormalRequest request)
        {
            var criteria = GetCriteria(request);
            IList<Racing> racings = _dataAccess.GetRacingResult(criteria);
            ResultSetting resultSetting = GetFanexResultSetting(criteria.SportType, request.Language);

            return ResultEngine.HtmlParser<Racing>(racings.ToList(), resultSetting);
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

            return ResultEngine.ExcelParser(
                _dataAccess.GetRacingResult(GetCriteria(request)).ToList(),
                resultSetting);
        }

        private static GetRacingResultCriteria GetCriteria(NormalRequest request)
        {
            return new GetRacingResultCriteria()
            {
                FromDate = request.ResultDate,
                SportType = request.SportId,
                IsShowAll = true,
                LeagueID = request.LeagueId
            };
        }

        /// <summary>
        /// Gets the FANEX result setting.
        /// </summary>
        /// <param name="sportType">Type of the sport.</param>
        /// <returns>Result Setting Model.</returns>
        private static ResultSetting GetFanexResultSetting(int sportType, string language)
        {
            return new ResultSetting
            {
                SportType = (SportType)sportType,
                LanguageCode = language,
                VisibleDetailedLink = true,
                VisibleFreeHeader = true,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };
        }

        public string GetResultDetails(NormalDetailsRequest detailsRequest)
        {
            var criteria = new GetRacingPopupResultCriteria()
            {
                MatchId = detailsRequest.MatchId,
                RaceNo = GetRaceNumber(detailsRequest.Race)
            };
            var results = this._dataAccess.GetRacingPopupResult(criteria);
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