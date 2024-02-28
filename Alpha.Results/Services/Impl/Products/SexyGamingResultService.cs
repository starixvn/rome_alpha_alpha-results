namespace Alpha.Results.Site.Services.Impl.Products
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using Alpha.Results.Site.Models;
    using Fanex.Common.Helper;
    using Fanex.Result.Core.SexyGaming;
    using Models.Requests;

    public class SexyGamingResultService : IProductResultService
    {
        private readonly ISexyGamingResultBuilder resultBuilder;

        public SexyGamingResultService(ISexyGamingResultBuilder resultBuilder = null)
        {
            this.resultBuilder = resultBuilder ?? new SexyGamingResultBuilder();
        }

        public MemoryStream ExportExcel(ExcelNormalResultQuery request)
        {
            throw new NotImplementedException();
        }

        public string GetResult(NormalResultQuery request)
        {
            throw new NotImplementedException();
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Justification = "Reviewed")]
        public ResultDetailModel GetResultDetails(NormalResultDetailsQuery detailsRequest)
        {
            Check.Argument.IsNotNull(detailsRequest, "detailsRequest");

            return new ResultDetailModel(resultBuilder.Render(detailsRequest.TransDesc, detailsRequest.BetCheck, detailsRequest.BetTypeId, detailsRequest.Language));
        }
    }
}
