namespace Alpha.Results.Services.Result
{
    using System;
    using System.IO;
    using Models;
    /// <summary>
    /// The interface ISportsBookResultService.
    /// </summary>
    public interface ISportsbookResultService
    {
        string GetResult(DateTime fromDate, int sportType, int leagueId);

        MemoryStream ExportExcel(DateTime fromDate, int sportType, int leagueId, string excelTemplatePath);

        string GetResultDetails(ResultRequest resultRequest);

    }
}