namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;

    public class DownloadOutrightResultExcelQuery : ViewOutrightResultQuery, IRequest<OutrightResultExcelViewModel>
    {
        public string TemplatePath { get; set; }
    }
}