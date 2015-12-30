namespace Alpha.Results.Services
{
    using System.IO;
    using Models.Requests;

    public interface IProductResultService
    {
        string GetResult(ViewNormalResultQuery request);

        MemoryStream ExportExcel(DownloadNormalResultExcelQuery request);

        string GetResultDetails(ViewNormalResultDetailsQuery detailsRequest);
    }
}