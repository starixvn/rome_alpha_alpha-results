namespace Alpha.Results.Site.Services
{
    using System.IO;
    using Alpha.Results.Site.Models;
    using Models.Requests;

    public interface IProductResultService
    {
        string GetResult(NormalResultQuery request);

        MemoryStream ExportExcel(ExcelNormalResultQuery request);

        ResultDetailModel GetResultDetails(NormalResultDetailsQuery detailsRequest);
    }
}