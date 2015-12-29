namespace Alpha.Results.Services
{
    using System.IO;
    using Commands;

    public interface IProductResultService
    {
        string GetResult(ViewNormalResultCommand request);

        MemoryStream ExportExcel(ViewNormalResultCommand request, string excelTemplatePath);

        string GetResultDetails(ViewNormalResultDetailsCommand detailsRequest);
    }
}