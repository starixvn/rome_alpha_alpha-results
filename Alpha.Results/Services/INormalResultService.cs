namespace Alpha.Results.Services
{
    using System;
    using System.Collections.Generic;
    using Commands;
    using Models;

    public interface INormalResultService
    {
        IEnumerable<Sport> GetSports(DateTime resultDate, IDictionary<int, bool> sportsStatus);

        IEnumerable<League> GetLeagues(DateTime resultDate, int sportId, string language, bool disableHorseRacingWin);

        string GetResults(ViewNormalResultCommand request);

        string GetResultDetails(ViewNormalResultDetailsCommand detailRequest);

        byte[] GetExcelResults(ViewNormalResultCommand request, string templatePath);
    }
}