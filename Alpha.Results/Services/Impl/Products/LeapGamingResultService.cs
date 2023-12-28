namespace Alpha.Results.Site.Services.Impl.Products
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Alpha.Results.Site.Models;
    using Fanex.Common.Helper;
    using Fanex.Data.Repository;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.LeapGaming.DTO;
    using Models.Requests;

    public class LeapGamingResultService : IProductResultService
    {
        private readonly IResultEngineAdapter _resultEngineAdapter;

        public LeapGamingResultService(
            IResultEngineAdapter resultEngineAdapter = null)
        {
            //// Still using poorman DI here because result service factory need to create it manual
            _resultEngineAdapter = resultEngineAdapter ?? new ResultEngineAdapter();
        }

        public MemoryStream ExportExcel(ExcelNormalResultQuery request)
        {
            throw new NotImplementedException();
        }

        public string GetResult(NormalResultQuery request)
        {
            throw new NotImplementedException();
        }

        public ResultDetailModel GetResultDetails(NormalResultDetailsQuery detailsRequest)
        {
            Check.Argument.IsNotNull(detailsRequest, "detailsRequest");

            var resultSetting = new ResultSetting
            {
                SportType = SportType.LeapGamingVirtualSports,
                IsPopUp = true,
                LanguageCode = detailsRequest.Language
            };

            var leapgamings = new List<LeapGaming> { new LeapGaming { TransDesc = detailsRequest.TransDesc } };
            return new ResultDetailModel(_resultEngineAdapter.HtmlParser(leapgamings, resultSetting));
        }
    }
}