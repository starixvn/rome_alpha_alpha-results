namespace Alpha.Results.Site.Services.Impl.Products
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using Fanex.Common.Helper;
    using Fanex.Result.Core.AllBetCasino;
    using Models.Requests;

    public class AllBetCasinoResultService : IProductResultService
    {
        public MemoryStream ExportExcel(ExcelNormalResultQuery request)
        {
            throw new NotImplementedException();
        }

        public string GetResult(NormalResultQuery request)
        {
            throw new NotImplementedException();
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Justification = "Reviewed")]
        public string GetResultDetails(NormalResultDetailsQuery detailsRequest)
        {
            Check.Argument.IsNotNull(detailsRequest, "detailsRequest");

            var allbetResultService = new AllbetResultBuilder();

            return allbetResultService.Render(detailsRequest.TransDesc, detailsRequest.BetCheck, detailsRequest.BetTypeId.ToString(), detailsRequest.Language);
        }
    }
}