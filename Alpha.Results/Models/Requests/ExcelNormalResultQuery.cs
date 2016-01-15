namespace Alpha.Results.Site.Models.Requests
{
    using MediatR;
    using Views;

    public class ExcelNormalResultQuery : NormalResultQuery, IRequest<NormalResultExcelViewModel>
    {
        public string ExcelTitle { get; set; }

        public string TemplatePath { get; set; }
    }
}