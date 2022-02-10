using Alpha.Results.Site.Models.Views;
using MediatR;

namespace Alpha.Results.Site.Models.Requests
{
    public class FishingWorldResultQuery: Fanex.Result.ThirdParty.Models.Requests.ThirdPartyResultBaseQuery, IRequest<ThirdPartyProductViewModel>
    {
    }
}