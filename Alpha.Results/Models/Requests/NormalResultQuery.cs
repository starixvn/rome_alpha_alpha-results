namespace Alpha.Results.Site.Models.Requests
{
    using MediatR;
    using Services.Impl;
    using Sunplus.Agent.Model.BL.Definitions;
    using Sunplus.Agent.Model.Entities.Permission;
    using System;
    using System.Collections.Generic;
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
                return UserSessionFactory.CurrentSession.Language;
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