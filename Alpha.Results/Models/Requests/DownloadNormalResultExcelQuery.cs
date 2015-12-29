namespace Alpha.Results.Models.Requests
{
    using Commands;
    using MediatR;
    using ViewModels;

    public class DownloadNormalResultExcelQuery : ViewNormalResultQuery, IRequest<NormalResultExcelViewModel>
    {
        public string TemplatePath { get; set; }
    }
}