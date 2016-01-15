namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;

    public class ExcelOutrightResultQuery : OutrightResultQuery, IRequest<OutrightResultExcelViewModel>
    {
        public string TemplatePath { get; set; }
    }
}