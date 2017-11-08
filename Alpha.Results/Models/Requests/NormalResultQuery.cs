namespace Alpha.Results.Site.Models.Requests
{
    using System;
    using System.Collections.Generic;
    using Configurations;
    using Constants;
    using MediatR;
    using Sunplus.Agent.Model.Entities;
    using Sunplus.Agent.Model.Entities.Permission;
    using Views;

    public class NormalResultQuery : IRequest<NormalResultViewModel>
    {
        private readonly IDictionary<int, bool> _sportsStatus;
        private readonly bool? _disableHorseRacingWin;
        private readonly string _language;

        public NormalResultQuery()
        {
            ResultDate = DateTime.Now;
        }

        internal NormalResultQuery(
            IDictionary<int, bool> sportStatus,
            bool disableHorseRacingWin,
            string language) : this()
        {
            _sportsStatus = sportStatus;
            _disableHorseRacingWin = disableHorseRacingWin;
            _language = language;
        }

        public DateTime ResultDate { get; set; }

        public string TransDesc { get; set; }

        public string BetCheck { get; set; }

        public int SportId { get; set; }

        public int LeagueId { get; set; }

        public int BetTypeId { get; set; }

        public string Language
        {
            get
            {
                return string.IsNullOrEmpty(_language) ? UserSession.Current.Language : _language;
            }
        }

        public IDictionary<int, bool> SportsStatus
        {
            get
            {
                var sportsStatus = _sportsStatus ?? new Dictionary<int, bool>
                {
                    { SportTypeIdConstants.NumberGame,  UserPermission.IsShowNumberGame },
                    { SportTypeIdConstants.LiveCasino,  UserPermission.IsShowLiveCasino },
                    { SportTypeIdConstants.GoldDeluxe,  UserPermission.IsShowGoldDeluxeSettingForCredit },
                    { SportTypeIdConstants.VirtualSports, UserPermission.HasPermissionOnProduct(ProductIdConstants.VirtualSports) }
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

        public DateTime MoveBetsDate { get; set; }
    }
}
