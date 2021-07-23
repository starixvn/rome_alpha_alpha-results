namespace Alpha.Results.Site.Controllers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Mvc;
    using Alpha.Web.Filters;
    using MediatR;
    using Models.Requests;
    using Models.Views;
    using Sunplus.Agent.Model.Entities;

    [PartialUMExceptionFilter]
    public class OutrightController : ResultBaseController
    {
        public OutrightController(IMediator mediator, IUserSession userSession)
            : base(mediator, userSession)
        {
        }

        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [HttpGet]
        public ActionResult Index(OutrightResultQuery request = null)
            => View(request ?? new OutrightResultQuery());

        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [HttpGet]
        public ActionResult ExcelResults(ExcelOutrightResultQuery request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null");
            }

            request.TemplatePath = Helpers.UrlHelper.ResultTemplatePath;

            var viewModel = mediator.Send<OutrightResultExcelViewModel>(request);

            return File(viewModel.ExcelResults, "application/vnd.ms-excel", viewModel.ExcelName);
        }
    }
}
