namespace Alpha.Results.Site.Models.Requests
{
    using System;
    using System.Collections.Generic;
    using MediatR;
    using Sunplus.Agent.Model.BL.Definitions;
    using Sunplus.Agent.Model.Entities;
    using Sunplus.Agent.Model.Entities.Permission;
    using Views;

    public class NormalResultQuery : IRequest<NormalResultViewModel>
    {
        public NormalResultQuery()
        {
            ResultDate = DateTime.Now;
        }

        public DateTime ResultDate { get; set; }

        public int SportId { get; set; }

        public int LeagueId { get; set; }

        public int BetTypeId { get; set; }

        public string Language
        {
            get
            {
                return UserSession.Current.Language;
            }
        }

        public IDictionary<int, bool> SportsStatus
        {
            get
            {
                var sportsStatus = new Dictionary<int, bool>
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
                return AppSettings.Disable151_31;
            }
        }
    }
}