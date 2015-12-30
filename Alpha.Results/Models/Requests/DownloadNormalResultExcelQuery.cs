namespace Alpha.Results.Models.Requests
{
    using MediatR;
    using Views;

    public class DownloadNormalResultExcelQuery : ViewNormalResultQuery, IRequest<NormalResultExcelViewModel>
    {
        public string TemplatePath { get; set; }
    }
}