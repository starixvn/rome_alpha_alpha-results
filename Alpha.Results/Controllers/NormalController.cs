using System.IO.MemoryMappedFiles;

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

    public class NormalController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}