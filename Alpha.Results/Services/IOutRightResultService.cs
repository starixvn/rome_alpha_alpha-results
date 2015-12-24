namespace Alpha.Results.Services.Result
{
    using Fanex.Result.Core.Sportsbook.DTO;
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// The interface IOutRightResultService.
    /// </summary>
    public interface IOutRightResultService
    {
        string GetResult(DateTime fromDate, DateTime toDate, int sportId, int leagueId, out List<OutRight> outRights);

        MemoryStream ExportExcel(DateTime fromDate, DateTime toDate, int sportId, int leagueId, string excelTemplatePath);
    }
}