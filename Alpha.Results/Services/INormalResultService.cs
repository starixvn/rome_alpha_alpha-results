namespace Alpha.Results.Services
{
    using System;
    using System.Collections.Generic;
    using Models;

    public interface INormalResultService
    {
        IEnumerable<Sport> GetSports(DateTime resultDate, IDictionary<int, bool> sportsStatus);

        IEnumerable<League> GetLeagues(DateTime resultDate, int sportId, string language, bool disableHouseRacingWin);

        string GetResults(NormalRequest request);

        string GetResultDetails(NormalDetailsRequest detailRequest);

        byte[] GetExcelResults(NormalRequest request, string templatePath);
    }
}