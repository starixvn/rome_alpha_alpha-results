namespace Alpha.Results.Site.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using MediatR;
    using Models.Requests;
    using Models.Views;
    using Sunplus.Agent.Model.BL.Definitions;
    using Sunplus.Agent.Model.Entities;
    using Sunplus.Agent.Model.Entities.Permission;

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

            var sportsStatus = new Dictionary<int, bool>
            {
                { (int)SportType.NumberGame,  UserPermission.IsShowNumberGame },
                { (int)SportType.LiveCasino,  UserPermission.IsShowLiveCasino },
                { (int)SportType.GoldDeluxe,  UserPermission.IsShowGoldDeluxeSettingForCredit }
            };

            request.SportsStatus = sportsStatus;
            request.DisableHorseRacingWin = AppSettings.Disable151_31;

            var viewModel = _mediator.Send(request);

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