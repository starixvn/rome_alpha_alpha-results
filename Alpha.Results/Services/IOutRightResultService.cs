namespace Alpha.Results.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Fanex.Result.Core.Sportsbook.DTO;
    using Models.Dtos;
    using Models.Requests;

    public interface IOutrightResultService
    {
        BalanceUpDateDto GetBalanceUpDate();

        IEnumerable<OutRight> GetOutrights(DateTime fromDate, DateTime toDate);

        string GetResults(IEnumerable<OutRight> outrights, ViewOutrightResultQuery request);

        MemoryStream GetExcelResults(DownloadOutrightResultExcelQuery request);
    }
}