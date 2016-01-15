namespace Alpha.Results.Site.Controllers
{
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Mvc;
    using MediatR;
    using Models.Requests;
    using Models.Views;

    public class OutrightController : BaseController
    {
        private readonly IMediator _mediator;

        public OutrightController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [HttpGet]
        public ActionResult Index(OutrightResultQuery request = null)
        {
            request = request ?? new OutrightResultQuery();

            var viewModel = _mediator.Send(request);

            return View(viewModel);
        }

        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [HttpGet]
        public ActionResult ExcelResults(ExcelOutrightResultQuery request)
        {
            request.TemplatePath = Server.MapPath(@"~/App_Data/Fanex.Result/");

            var viewModel = _mediator.Send<OutrightResultExcelViewModel>(request);

            return File(viewModel.ExcelResults, "application/vnd.ms-excel", viewModel.ExcelName);
        }
    }
}