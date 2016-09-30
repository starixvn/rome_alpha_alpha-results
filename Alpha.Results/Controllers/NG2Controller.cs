using System.Configuration;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Alpha.Results.Site.Controllers
{
    public class NG2Controller : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            string rootPath = Response.ApplyAppPathModifier("~");
            string ng2SiteResultPath = ConfigurationManager.AppSettings["NG2SiteResultPath"];

            return View(
                "~/Views/NG2/Index.cshtml", 
                null,
                Regex.Replace(rootPath, HttpRuntime.AppDomainAppVirtualPath, ng2SiteResultPath, RegexOptions.IgnoreCase));
        }
    }
}