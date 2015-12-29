namespace Alpha.Results.Services
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using Fanex.Result.Core.Sportsbook.DTO;
	using Models;
	using Models.Dtos;

	public interface IOutrightResultService
    {
		BalanceUpDateDto GetBalanceUpDate();

		IEnumerable<OutRight> GetOutrights(DateTime fromDate, DateTime toDate);

		string GetResults(IEnumerable<OutRight> outrights, OutrightRequest request);

		MemoryStream GetExcelResults(IEnumerable<OutRight> outrights, OutrightRequest request, string templatePath);
	}
}