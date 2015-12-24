namespace Alpha.Results.Services.Result
{
    using System;
    using System.IO;

    /// <summary>
    /// The interface INumberGameResultService.
    /// </summary>
    public interface INumberGameResultService
    {
        string GetResult(DateTime fromDate, int leagueId, int sportType);

        MemoryStream ExportExcel(DateTime fromDate, int sportType, int leagueId, string excelTemplatePath);
    }
}