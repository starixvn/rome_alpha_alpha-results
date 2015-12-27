namespace Alpha.Results.Services
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Models.Dtos;

    public interface INormalService
    {
        IEnumerable<Sport> GetSports(DateTime resultDate, IDictionary<int, bool> sportsStatus);

        IEnumerable<League> GetLeagues(DateTime resultDate, int sportId, string language, bool disableHouseRacingWin);

        BalanceUpDateDto GetBalanceUpDate();

        string GetHtmlResults(NormalRequest request);

        string GetHtmlResultDetails(NormalDetailRequest detailRequest);

        byte[] GetExcelResults(NormalRequest request, string templatePath);
    }
}