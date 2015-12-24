namespace Alpha.Results.Services.Result
{
    using System;
    using System.IO;

    /// <summary>
    /// The interface IRacingResultService.
    /// </summary>
    public interface IRacingResultService
    {
        string GetResult(DateTime fromDate, int sportType, int leagueId);

        MemoryStream ExportExcel(DateTime fromDate, int sportType, int leagueId, string excelTemplatePath);
    }
}