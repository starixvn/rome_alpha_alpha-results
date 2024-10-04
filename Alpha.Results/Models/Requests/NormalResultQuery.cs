namespace Alpha.Results.Site.Models.Requests
{
    using System;
    using System.Collections.Generic;
    using AlphaPlus.User.Models;
    using Constants;
    using MediatR;
    using Views;

    public class NormalResultQuery : IRequest<NormalResultViewModel>
    {
        private readonly IDictionary<int, bool> _sportsStatus;
        private readonly string _language;

        public NormalResultQuery()
        {
            ResultDate = DateTime.Now;
        }

        internal NormalResultQuery(
            IDictionary<int, bool> sportStatus,
            string language) : this()
        {
            _sportsStatus = sportStatus;
            _language = language;
        }

        public DateTime ResultDate { get; set; }

        public DateTime EndTime { get; set; }

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
                    { SportTypeIdConstants.NumberGame,  UserPermission.IsEnableProduct(Constants.ProductIdConstants.NumberGame) },
                    { SportTypeIdConstants.VirtualSports, UserPermission.HasPermissionOnProduct(Constants.ProductIdConstants.VirtualSports) }
                };

                return sportsStatus;
            }
        }       

        public DateTime MoveBetsDate { get; set; }
        public DateTime BalanceUpDate { get; set; }
    }
}
