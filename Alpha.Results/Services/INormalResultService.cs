namespace Alpha.Results.Services
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Models.Requests;

    public interface INormalResultService
    {
        IEnumerable<Sport> GetSports(DateTime resultDate, IDictionary<int, bool> sportsStatus);

        IEnumerable<League> GetLeagues(DateTime resultDate, int sportId, string language, bool disableHorseRacingWin);

        string GetResults(ViewNormalResultQuery request);

        string GetResultDetails(ViewNormalResultDetailsQuery detailRequest);

        byte[] GetExcelResults(DownloadNormalResultExcelQuery request);
    }
}