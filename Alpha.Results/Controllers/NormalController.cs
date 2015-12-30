namespace Alpha.Results.Controllers
{
    using System.Web.Mvc;
    using MediatR;
    using Models.Requests;
    using Models.Views;
    using Sunplus.Agent.Model.Entities;

    public class NormalController : BaseController
    {
        private readonly IMediator _mediator;

        public NormalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult Index(ViewNormalResultQuery request = null)
        {
            request = request ?? new ViewNormalResultQuery();
            request.Language = UserSession.Current.Language;

            var viewModel = _mediator.Send<NormalViewModel>(request);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult ResultDetails(ViewNormalResultDetailsQuery request)
        {
            request.Language = UserSession.Current.Language;

            var viewModel = _mediator.Send<NormalDetailViewModel>(request);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult ExcelResults(DownloadNormalResultExcelQuery request)
        {
            request.Language = UserSession.Current.Language;
            request.TemplatePath = Server.MapPath(@"~/App_Data/Fanex.Result/");

            var viewModel = _mediator.Send<NormalResultExcelViewModel>(request);

            return File(viewModel.ExcelResults, "application/vnd.ms-excel", viewModel.ExcelName);
        }
    }
}