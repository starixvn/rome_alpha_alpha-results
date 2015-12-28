namespace Alpha.Results.Services.Impl.Products
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Alpha.Results.Criteria;
    using Alpha.Results.LocalResources;
    using Alpha.Results.Repositories;
    using Alpha.Results.Repositories.Impl.Result;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.Racing.DTO;
    using Models;
    using Sunplus.Agent.Model.BL.Cache;
    using Sunplus.Agent.Model.Entities;

    /// <summary>
    /// The class VirtualRacingResultService.
    /// </summary>R
    public class VirtualRacingResultService : IProductResultService
    {
        private IVirtualRacingResultDataAccess _racingResultDataAccess;

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
            IList<Racing> racings = this._racingResultDataAccess.GetVirtualRacingResult(criteria);
            ResultSetting resultSetting = GetFanexResultSetting(criteria.SportType);

            return ResultEngine.HtmlParser<Racing>(racings.ToList(), resultSetting);
        }

        public MemoryStream ExportExcel(NormalRequest request, string excelTemplatePath)
        {
            return ResultEngine.ExcelParser(
                this._racingResultDataAccess.GetVirtualRacingResult(GetCriteria(request)).ToList(),
                GetExportExcelSetting(request.SportId, excelTemplatePath, GetExcelTitle(request)));
        }

        private static GetVirtualRacingResultCriteria GetCriteria(NormalRequest request)
        {
            return new GetVirtualRacingResultCriteria()
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
        private static ResultSetting GetFanexResultSetting(int sportType)
        {
            return new ResultSetting
            {
                SportType = (SportType)sportType,
                LanguageCode = UserSession.Current.Language,
                VisibleDetailedLink = true,
                VisibleFreeHeader = true,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };
        }

        /// <summary>
        /// Gets the export excel setting.
        /// </summary>
        /// <param name="sportType">Type of the sport.</param>
        /// <param name="excelTemplatePath">The excel template path.</param>
        /// <param name="excelTitle">The excel title.</param>
        /// <returns>Result Setting Model.</returns>
        private static ResultSetting GetExportExcelSetting(int sportType, string excelTemplatePath, string excelTitle)
        {
            return new ResultSetting
            {
                SportType = (SportType)sportType,
                LanguageCode = UserSession.Current.Language,
                ExcelTitle = excelTitle,
                ExcelTemplatePath = excelTemplatePath,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };
        }

        private static string GetExcelTitle(NormalRequest request)
        {
            string leagueName = request.LeagueId == 0 ? "Show All Leagues" : CacheRef.GetLeagueName(request.LeagueId);
            return ResultLang.result + " - " + request.ResultDate.ToString("MM/dd/yyyy")
                + " | " + CacheRef.GetSportName(request.SportId) + " - " + leagueName;
        }

        public string GetResultDetails(NormalDetailsRequest detailsRequest)
        {
            var criteria = new GetRacingPopupResultCriteria()
            {
                MatchId = detailsRequest.MatchId,
                RaceNo = GetRaceNumber(detailsRequest.Race)
            };

            var results = this._racingResultDataAccess.GetVirtualRacingPopupResult(criteria);

            var resultSetting = new ResultSetting
            {
                SportType = (SportType)detailsRequest.SportId,
                IsOutRight = false,
                IsParlayPopUp = false,
                IsPopUp = true,
                VisiblePopUpTitle = false,
                LanguageCode = UserSession.Current.Language,
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