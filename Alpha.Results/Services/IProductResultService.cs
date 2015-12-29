namespace Alpha.Results.Services
{
    using System.IO;
    using Commands;

    public interface IProductResultService
    {
        string GetResult(ViewNormalResultQuery request);

        MemoryStream ExportExcel(ViewNormalResultQuery request, string excelTemplatePath);

        string GetResultDetails(ViewNormalResultDetailsQuery detailsRequest);
    }
}