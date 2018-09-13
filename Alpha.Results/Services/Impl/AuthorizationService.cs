namespace Alpha.Results.Site.Services.Impl
{
    using Criteria;
    using DataAccesses;
    using Fanex.Data.Repository;
    using Models;

    public class AuthorizationService : IAuthorizationService
    {
        private readonly IAuthorizationDataAccess authorizationDataAccess;

        public AuthorizationService(IAuthorizationDataAccess authorizationDataAccess)
        {
            this.authorizationDataAccess = authorizationDataAccess;
        }

        public bool IsBelonging(Actor actor, int custId, int subAccountId, long transId = 0)
        {
            ICriteria criteria = new CheckBelongingCriteria(actor.ActorId, custId, subAccountId, transId);
            var belongingInfo = authorizationDataAccess.IsBelonging(criteria);

            return !(belongingInfo.RoleId == 0 || belongingInfo.RoleId >= actor.ActorRoleId)
                && belongingInfo.IsActive;
        }
    }
}