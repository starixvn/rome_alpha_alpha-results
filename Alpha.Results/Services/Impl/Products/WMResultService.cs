namespace Alpha.Results.Site.Services.Impl.Products
{
    using System;
    using System.IO;
    using Fanex.Common.Helper;
    using Fanex.Result.Core.WM;
    using Models.Requests;

    public class WMResultService : IProductResultService
    {
        private readonly IWMResultBuilder resultBuilder;

        public WMResultService(IWMResultBuilder resultBuilder = null)
        {
            this.resultBuilder = resultBuilder ?? new WMResultBuilder();
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

            return resultBuilder.Render(detailsRequest.TransDesc, detailsRequest.BetCheck, detailsRequest.BetTypeId, detailsRequest.Language);
        }
    }
}
