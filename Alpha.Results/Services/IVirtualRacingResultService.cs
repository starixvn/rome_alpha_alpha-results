namespace Alpha.Results.Services.Result
{
    using System;
    using System.IO;

    /// <summary>
    /// The interface IVirtualRacingResultService.
    /// </summary>
    public interface IVirtualRacingResultService
    {
        string GetResult(DateTime fromDate, int sportType, int leagueId);

        MemoryStream ExportExcel(DateTime fromDate, int sportType, int leagueId, string excelTemplatePath);
    }
}