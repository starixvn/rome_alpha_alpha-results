namespace Alpha.Results.Controllers
{
    using System.Web.Mvc;
    using MediatR;
    using Models.Requests;
    using Models.Views;
    using Sunplus.Agent.Model.Entities;

    public class OutrightController : BaseController
    {
        private readonly IMediator _mediator;

        public OutrightController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult Index(ViewOutrightResultQuery request = null)
        {
            request = request ?? new ViewOutrightResultQuery();
            request.Language = UserSession.Current.Language;

            var viewModel = _mediator.Send<OutrightViewModel>(request);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult ExcelResults(DownloadOutrightResultExcelQuery request)
        {
            request.TemplatePath = Server.MapPath(@"~/App_Data/Fanex.Result/");
            request.Language = UserSession.Current.Language;

            var viewModel = _mediator.Send<OutrightResultExcelViewModel>(request);

            return File(viewModel.ExcelResults, "application/vnd.ms-excel", viewModel.ExcelName);
        }
    }
}