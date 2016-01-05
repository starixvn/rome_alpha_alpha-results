namespace Alpha.Results.Site.Services
{
    using System;
    using Models.Dtos;

    public interface IReportDateService
    {
        BalanceUpAndMoveBetsDate GetBalanceUpDate();

        DateTime GetBalanceUpDay();

        DateTime GetMoveBetsDate();
    }
}