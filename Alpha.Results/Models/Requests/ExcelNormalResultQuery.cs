namespace Alpha.Results.Site.Models.Requests
{
    using System.Web;
    using MediatR;
    using Views;

    public class ExcelNormalResultQuery : NormalResultQuery, IRequest<NormalResultExcelViewModel>
    {
        public string ExcelTitle { get; set; }

        public string TemplatePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(@"~/App_Data/Fanex.Result/");
            }
        }
    }
}