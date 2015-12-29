namespace Alpha.Results.Services
{
	using Fanex.Result.Core.Sportsbook.DTO;
	using Models;
	using Models.Dtos;
	using System;
	using System.Collections.Generic;
	using System.IO;

	public interface IOutRightResultService
    {
		BalanceUpDateDto GetBalanceUpDate();

		IEnumerable<OutRight> GetOutRights(DateTime fromDate, DateTime toDate);

		string GetResults(IEnumerable<OutRight> outrights, OutRightRequest request);

		MemoryStream GetExcelResults(IEnumerable<OutRight> outrights, OutRightRequest request, string templatePath);
	}
}