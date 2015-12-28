namespace Alpha.Results.Services
{
	using Fanex.Result.Core.Sportsbook.DTO;
	using Models.Dtos;
	using System;
	using System.Collections.Generic;

	public interface IOutRightService
    {
		BalanceUpDateDto GetBalanceUpDate();

		IEnumerable<OutRight> GetOutRights(DateTime fromDate, DateTime toDate);

		string GetResults(IEnumerable<OutRight> outrights, int sportId, int leagueId);

		//string GetResults(DateTime fromDate, DateTime toDate, int sportId, int leagueId, out List<OutRight> outRights);

        //MemoryStream ExportExcel(DateTime fromDate, DateTime toDate, int sportId, int leagueId, string excelTemplatePath);
    }
}