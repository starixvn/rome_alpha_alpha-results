namespace Alpha.Results.Controllers
{
    using Sunplus.Agent.Model.Entities;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Reflection;
    using System.Security;
    using System.Threading;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class BaseController : Controller
    {
        private const string DefaultLanguage = "en-US";

        private static readonly CultureInfo DefaultCulture = CultureInfo.CreateSpecificCulture(DefaultLanguage);

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //ValidateSecurityCode(filterContext);
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
                MaxJsonLength = Int32.MaxValue
            };
        }

        protected static List<string> GetActionListByController<T>()
        {
            var listAction = new List<string>();

            Type t = typeof(T);
            MethodInfo[] mi = t.GetMethods();
            foreach (MethodInfo m in mi)
            {
                if (m.IsPublic)
                    if (m.ReturnParameter != null && typeof(ActionResult).IsAssignableFrom(m.ReturnParameter.ParameterType))
                    {
                        listAction.Add(m.Name);
                    }
            }

            return listAction;
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

        ////private void ValidateSecurityCode(ActionExecutingContext filterContext)
        ////{
        ////    string redirectURL = SecurityCodeChecker.GetRedirectUrl();
        ////    if (redirectURL != null)
        ////    {
        ////        if (Request.IsAjaxRequest())
        ////        {
        ////            throw new SecurityException();
        ////        }

        ////        filterContext.Result = new RedirectResult(redirectURL);
        ////    }
        ////}
    }
}