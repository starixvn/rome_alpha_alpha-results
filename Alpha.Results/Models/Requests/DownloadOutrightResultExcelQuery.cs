namespace Alpha.Results.Models.Requests
{
    using Alpha.Results.Models.Views;
    using MediatR;

    public class DownloadOutrightResultExcelQuery : ViewOutrightResultQuery, IRequest<OutrightResultExcelViewModel>
    {
        public string TemplatePath { get; set; }
    }
}