namespace Alpha.Results.Site.Models.Requests
{
    using System.Web;
    using Alpha.Results.Site.Models.Views;
    using MediatR;

    public class ExcelOutrightResultQuery : OutrightResultQuery, IRequest<OutrightResultExcelViewModel>
    {
        public string TemplatePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(@"~/App_Data/Fanex.Result/");

            }
        }
    }
}
