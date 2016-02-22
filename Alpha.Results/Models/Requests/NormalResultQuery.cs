namespace Alpha.Results.Site.Models.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Web;
    using MediatR;
    using Services.Impl;
    using Sunplus.Agent.Model.BL.Definitions;
    using Sunplus.Agent.Model.Entities;
    using Sunplus.Agent.Model.Entities.Permission;
    using Sunplus.Agent.Utilities;
    using Views;

    public class NormalResultQuery : IRequest<NormalResultViewModel>
    {
        private IDictionary<int, bool> _sportsStatus;
        private bool? _disableHorseRacingWin;

        public NormalResultQuery()
        {
            ResultDate = DateTime.Now;
        }

        internal NormalResultQuery(IDictionary<int, bool> sportStatus, bool disableHorseRacingWin) : this()
        {
            _sportsStatus = sportStatus;
            _disableHorseRacingWin = disableHorseRacingWin;
        }

        public DateTime ResultDate { get; set; }

        public int SportId { get; set; }

        public int LeagueId { get; set; }

        public int BetTypeId { get; set; }

        public string Language
        {
            get
            {
                if (Thread.CurrentThread.CurrentCulture.Name != UserSessionFactory.CurrentSession.Language)
                {
                    Logs.WriteInfo($"Thread Language: {Thread.CurrentThread.CurrentCulture.Name} \r\n"
                        + $"- Session Language Factory: {UserSessionFactory.CurrentSession.Language} \r\n"
                        + $"- Session Language: {UserSession.Current.Language} \r\n"
                        + $"- Username: {UserSession.Current.UserName} \r\n"
                        + $"- Username: {HttpContext.Current.User.Identity.Name}");
                }

                return Thread.CurrentThread.CurrentCulture.Name;
            }
        }

        public IDictionary<int, bool> SportsStatus
        {
            get
            {
                var sportsStatus = _sportsStatus ?? new Dictionary<int, bool>
                {
                    { (int)SportType.NumberGame,  UserPermission.IsShowNumberGame },
                    { (int)SportType.LiveCasino,  UserPermission.IsShowLiveCasino },
                    { (int)SportType.GoldDeluxe,  UserPermission.IsShowGoldDeluxeSettingForCredit }
                };

                return sportsStatus;
            }
        }

        public bool DisableHorseRacingWin
        {
            get
            {
                return _disableHorseRacingWin.HasValue
                    ? _disableHorseRacingWin.Value
                    : AppSettings.Disable151_31;
            }
        }
    }
}