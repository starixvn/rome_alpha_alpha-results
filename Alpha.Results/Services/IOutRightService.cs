namespace Alpha.Results.Services
{
	using Fanex.Result.Core.Sportsbook.DTO;
	using Models;
	using Models.Dtos;
	using System;
	using System.Collections.Generic;
	using System.IO;

	public interface IOutRightService
    {
		BalanceUpDateDto GetBalanceUpDate();

		IEnumerable<OutRight> GetOutRights(DateTime fromDate, DateTime toDate);

		string GetResults(IEnumerable<OutRight> outrights, int sportId, int leagueId);

		MemoryStream ExportExcel(OutrightRequest request, string excelTemplatePath);
	}
}