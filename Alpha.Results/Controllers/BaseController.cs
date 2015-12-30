namespace Alpha.Results.Site.Controllers
{
    using System.Globalization;
    using System.Threading;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Sunplus.Agent.Model.Entities;

    public class BaseController : Controller
    {
        private const string DefaultLanguage = "en-US";

        private static readonly CultureInfo DefaultCulture = CultureInfo.CreateSpecificCulture(DefaultLanguage);

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //// Should check authentication here
            //// Base controller should separate into another dll for re-using.
            base.OnActionExecuting(filterContext);
        }

        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength = int.MaxValue
            };
        }

        protected override void Initialize(RequestContext requestContext)
        {
            string cultureName = UserSession.Current.Language;
            if (string.IsNullOrEmpty(cultureName))
            {
                cultureName = DefaultLanguage; // default
                UserSession.Current.Language = cultureName;
            }

            // Modify current thread's cultures
            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            Thread.CurrentThread.CurrentCulture.DateTimeFormat = DefaultCulture.DateTimeFormat;
            Thread.CurrentThread.CurrentCulture.NumberFormat = DefaultCulture.NumberFormat;

            base.Initialize(requestContext);
        }
    }
}