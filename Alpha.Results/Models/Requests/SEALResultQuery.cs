namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

    public class SEALResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public SEALResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
