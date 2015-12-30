namespace Alpha.Results.Models.Requests
{
    using MediatR;
    using Views;

    public class DownloadNormalResultExcelQuery : ViewNormalResultQuery, IRequest<NormalResultExcelViewModel>
    {
        public string ExcelTitle { get; set; }

        public string TemplatePath { get; set; }
    }
}