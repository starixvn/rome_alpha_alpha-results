namespace Alpha.Results.Services
{
    using System.IO;
    using Models;

    public interface IProductResultService
    {
        string GetResult(NormalRequest request);

        MemoryStream ExportExcel(NormalRequest request, string excelTemplatePath);

        string GetResultDetails(NormalDetailsRequest detailsRequest);
    }
}