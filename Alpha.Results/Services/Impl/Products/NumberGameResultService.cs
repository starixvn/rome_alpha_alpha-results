namespace Alpha.Results.Services.Impl.Products
{
    using System.IO;
    using System.Linq;
    using Alpha.Results.Criteria;
    using Alpha.Results.LocalResources;
    using Alpha.Results.Repositories;
    using Alpha.Results.Repositories.Impl.Result;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Models;
    using Sunplus.Agent.Model.BL.Cache;
    using Sunplus.Agent.Model.Entities;

    /// <summary>
    /// The class NumberGameResultService.
    /// </summary>
    public class NumberGameResultService : IProductResultService
    {
        private INumberGameResultDataAccess _numberGameResultDataAccess;

        public NumberGameResultService(INumberGameResultDataAccess numberGameResultDataAccess)
        {
            this._numberGameResultDataAccess = numberGameResultDataAccess ?? new NumberGameResultDataAccess();
        }

        public NumberGameResultService()
            : this(null)
        {
        }

        public string GetResult(NormalRequest request)
        {
            return ResultEngine.HtmlParser(
                this._numberGameResultDataAccess.GetNumberGameResult(GetCriteria(request)).ToList(),
                GetFanexResultSetting(request.SportId));
        }

        public MemoryStream ExportExcel(NormalRequest request, string excelTemplatePath)
        {
            return ResultEngine.ExcelParser(
                this._numberGameResultDataAccess.GetNumberGameResult(GetCriteria(request)).ToList(),
                GetExportExcelSetting(request.SportId, excelTemplatePath, GetExcelTitle(request)));
        }

        private static GetNumberGameResultCriteria GetCriteria(NormalRequest request)
        {
            return new GetNumberGameResultCriteria()
            {
                FromDate = request.ResultDate,
                LeagueID = request.LeagueId,
                Language = UserSession.Current.Language
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
            var criteria = new GetNumberGamePopupResultCriteria()
            {
                MatchID = detailsRequest.MatchId
            };

            return ResultEngine.HtmlParser(
                this._numberGameResultDataAccess.GetNumberGamePopupResult(criteria),
                new ResultSetting
                {
                    SportType = SportType.NumberGame,
                    IsOutRight = false,
                    IsParlayPopUp = false,
                    IsPopUp = true,
                    VisiblePopUpTitle = false,
                    LanguageCode = UserSession.Current.Language,
                    VisibleMatchCodeIDColumn = false,
                    VisibleFreeHeader = true,
                    VisibleDetailedLink = true,
                    HighlightWinnerTeam = true
                });
        }
    }
}