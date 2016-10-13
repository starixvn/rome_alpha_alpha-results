namespace Alpha.Results.Site.Controllers
{
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Threading;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Filters;
    using System.Web.Routing;
    using System.Web.Security;
    using Sunplus.Agent.Model.Entities;

    public class BaseController : Controller
    {
        private const string DefaultLanguage = "en-US";

        private CultureInfo defaultCulture = CultureInfo.CreateSpecificCulture(DefaultLanguage);

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Justification = "Reviewed!")]
        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            base.OnAuthentication(filterContext);

            if (!filterContext.HttpContext.User.Identity.IsAuthenticated
                || UserSession.Current.UserId <= 0)
            {
                UnAuthentication(filterContext);
            }
        }

        private void UnAuthentication(AuthenticationContext filterContext)
        {
            HttpResponseBase response = filterContext.HttpContext.Response;

            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                response.Clear();
                response.Write("{ \"message\": \"You are not authorized on this function!\" }");
                filterContext.Result = new HttpUnauthorizedResult();
                filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
                response.TrySkipIisCustomErrors = true;
                response.End();
            }
            else
            {
                filterContext.Result = new RedirectResult(FormsAuthentication.LoginUrl);
            }
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

            Thread.CurrentThread.CurrentCulture.DateTimeFormat = defaultCulture.DateTimeFormat;
            Thread.CurrentThread.CurrentCulture.NumberFormat = defaultCulture.NumberFormat;

            base.Initialize(requestContext);
        }
    }
}