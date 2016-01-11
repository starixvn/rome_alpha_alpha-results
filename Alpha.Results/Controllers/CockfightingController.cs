namespace Alpha.Results.Site.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Sunplus.Agent.Model.Entities;

    public class CockfightingController : BaseController
    {
        private readonly ICockfightingService _cockFightingService;

        public CockfightingController()
        {
            _cockFightingService = new CockFightingService();
        }

        public ActionResult Result()
        {
            var criteria = new GetResultCriteria
            {
                RoleId = UserSession.Current.RoleId,
                CustomerId = UserSession.Current.CustId,
                Date = string.Format("{0:yyyyMMdd}", DateTime.Now),
                Language = GetLanguageCode().ToLower()
            };

            var resultIframe = _cockFightingService.GetResult(criteria);
            return View("~/Areas/Report/Views/Result/CockFighting/Result.cshtml", resultIframe);
        }

        public ActionResult ResultContent(bool? isKeepAlive = false)
        {
            try
            {
                var customerId = UserSession.Current.CustId.ToString();

                ICockFightingAPI api = new CockFightingAPI();
                if (isKeepAlive.HasValue && isKeepAlive.Value)
                {
                    return Json(api.ExtendToken(customerId), JsonRequestBehavior.AllowGet);
                }

                var languageCode = GetLanguageCode().ToLower();
                return Json(
                    new
                    {
                        Url = api.GetResultToken(customerId, languageCode),
                        IsSuccess = true
                    },
                    JsonRequestBehavior.AllowGet
                );
            }
            catch (Exception exception)
            {
                exception.Write();
            }

            return Json(new { IsSuccess = false }, JsonRequestBehavior.AllowGet);
        }

        private string GetLanguageCode()
        {
            string languageCode = string.Empty;
            switch (UserSession.Current.LangKey)
            {
                case "E":
                    languageCode = "EN";
                    break;
                case "J":
                    languageCode = "JP";
                    break;
                case "CT":
                    languageCode = "CH";
                    break;
                case "CS":
                    languageCode = "CS";
                    break;
                case "TH":
                    languageCode = "TH";
                    break;
                case "KO":
                    languageCode = "KO";
                    break;
                case "VI":
                    languageCode = "VI";
                    break;
                default:
                    languageCode = "EN";
                    break;
            }

            return languageCode;
        }
    }
}