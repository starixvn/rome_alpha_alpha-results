namespace Alpha.Results.Site.Services.Impl.Products
{
    using System;
    using System.IO;
    using Fanex.Common.Helper;
    using Fanex.Result.Core.BBin;
    using Models.Requests;

    public class BBinResultService : IProductResultService
    {
        private readonly IBBinResultBuilder resultBuilder;

        public BBinResultService(IBBinResultBuilder resultBuilder = null)
        {
            this.resultBuilder = resultBuilder ?? new BBinResultBuilder();
        }

        public MemoryStream ExportExcel(ExcelNormalResultQuery request)
        {
            throw new NotImplementedException();
        }

        public string GetResult(NormalResultQuery request)
        {
            throw new NotImplementedException();
        }

        public string GetResultDetails(NormalResultDetailsQuery detailsRequest)
        {
            Check.Argument.IsNotNull(detailsRequest, "detailsRequest");

            return resultBuilder.Render(detailsRequest.TransDesc, detailsRequest.BetCheck, detailsRequest.Language);
        }
    }
}
