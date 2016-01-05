namespace Alpha.Results.Site.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Fanex.Result.Core.Sportsbook.DTO;
    using Models.Dtos;
    using Models.Requests;

    public interface IOutrightResultService
    {
        BalanceUpAndMoveBetsDate GetBalanceUpDate();

        IEnumerable<Outright> GetOutrights(DateTime fromDate, DateTime toDate);

        string GetResults(IEnumerable<Outright> outrights, OutrightResultQuery request);

        MemoryStream GetExcelResults(ExcelOutrightResultQuery request);
    }
}