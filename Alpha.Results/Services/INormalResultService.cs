namespace Alpha.Results.Site.Services
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Models.Requests;

    public interface INormalResultService
    {
        IEnumerable<Sport> GetSports(DateTime resultDate, IDictionary<int, bool> sportsStatus);

        IEnumerable<League> GetLeagues(DateTime resultDate, int sportId, string language, bool disableHorseRacingWin);

        string GetResults(NormalResultQuery request);

        string GetResultDetails(NormalResultDetailsQuery detailRequest);

        byte[] GetExcelResults(ExcelNormalResultQuery request);
    }
}