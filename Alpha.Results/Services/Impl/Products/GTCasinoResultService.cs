using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Alpha.Results.Site.Models;
using Alpha.Results.Site.Models.Requests;
using Fanex.Common.Helper;
using Fanex.Result.Core.GTCasino;

namespace Alpha.Results.Site.Services.Impl.Products
{
    public class GTCasinoResultService : IProductResultService
    {
        private readonly IGTCasinoResultBuilder gTCasinoResultBuilder;

        public GTCasinoResultService(IGTCasinoResultBuilder gTCasinoResultBuilder = null)
        {
            this.gTCasinoResultBuilder = gTCasinoResultBuilder ?? new GTCasinoResultBuilder();
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

            return new ResultDetailModel(gTCasinoResultBuilder.Render(detailsRequest.TransDesc, ParseTranId3rd(detailsRequest.BetCheck), detailsRequest.BetTypeId.ToString(), detailsRequest.Language));
        }

        private static string ParseTranId3rd(string transId3rd)
        {
            const string transId3rdSeparator = "|$|";
            if (transId3rd == null || !transId3rd.Contains(transId3rdSeparator))
            {
                return transId3rd;
            }

            var transIdParts = transId3rd.Split(new string[] { transId3rdSeparator }, StringSplitOptions.RemoveEmptyEntries);

            return transIdParts[transIdParts.Length - 1];
        }
    }
}