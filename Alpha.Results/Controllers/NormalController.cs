namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using MediatR;
    using Models.Requests;
    using Models.Views;

    public class NormalController : BaseController
    {
        private readonly IMediator _mediator;

        public NormalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult Index(NormalResultQuery request = null)
        {
            request = request ?? new NormalResultQuery();

            var viewModel = _mediator.Send(request);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult ResultDetails(NormalResultDetailsQuery request)
        {
            var viewModel = _mediator.Send<NormalDetailViewModel>(request);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult ExcelResults(ExcelNormalResultQuery request)
        {
            var viewModel = _mediator.Send<NormalResultExcelViewModel>(request);

            return File(viewModel.ExcelResults, "application/vnd.ms-excel", viewModel.ExcelName);
        }
    }
}