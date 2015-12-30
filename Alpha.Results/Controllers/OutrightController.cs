namespace Alpha.Results.Site.Controllers
{
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

        [HttpGet]
        public ActionResult Index(OutrightResultQuery request = null)
        {

            var viewModel = _mediator.Send<OutrightResultViewModel>(request);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult ExcelResults(ExcelOutrightResultQuery request)
        {

            var viewModel = _mediator.Send<OutrightResultExcelViewModel>(request);

            return File(viewModel.ExcelResults, "application/vnd.ms-excel", viewModel.ExcelName);
        }
    }
}