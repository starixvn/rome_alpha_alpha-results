namespace Alpha.Results.Site.Controllers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Mvc;
    using Alpha.Web.Filters;
    using MediatR;
    using Models.Requests;
    using Models.Views;

    [PartialUMExceptionFilter]
    public class NormalController : ResultBaseController
    {
        public NormalController(IMediator mediator) : base(mediator)
        {
        }

        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [HttpGet]
        public ActionResult Index(NormalResultQuery request = null)
            => View(request ?? new NormalResultQuery());

        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [HttpGet]
        public ActionResult ResultDetails(NormalResultDetailsQuery request)
            => View<NormalDetailViewModel>(request);

        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [HttpGet]
        public ActionResult ExcelResults(ExcelNormalResultQuery request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null");
            }

            request.TemplatePath = Helpers.UrlHelper.ResultTemplatePath;

            var viewModel = mediator.Send<NormalResultExcelViewModel>(request);

            return File(viewModel.ExcelResults, "application/vnd.ms-excel", viewModel.ExcelName);
        }
    }
}
