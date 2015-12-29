namespace Alpha.Results.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Commands;
    using Fanex.Result.Core.Sportsbook.DTO;
    using Models.Dtos;

    public interface IOutrightResultService
    {
        BalanceUpDateDto GetBalanceUpDate();

        IEnumerable<OutRight> GetOutrights(DateTime fromDate, DateTime toDate);

        string GetResults(IEnumerable<OutRight> outrights, ViewOutrightResultCommand request);

        MemoryStream GetExcelResults(IEnumerable<OutRight> outrights, ViewOutrightResultCommand request, string templatePath);
    }
}