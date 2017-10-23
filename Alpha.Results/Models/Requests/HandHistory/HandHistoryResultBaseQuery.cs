using Alpha.Results.Site.Models.Views;
using MediatR;

namespace Alpha.Results.Site.Models.Requests
{
    public class HandHistoryResultBaseQuery : IRequest<HandHistoryResultViewModel>
    {
        public int CustId { get; set; }

        public int RoleId { get; set; }

        public string RefNo { get; set; }

        public string Language { get; set; }
    }
}
