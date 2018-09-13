namespace Alpha.Results.Site.Services
{
    using Models;

    public interface IAuthorizationService
    {
        bool IsBelonging(Actor actor, int custId, int subAccountId, long transId = 0);
    }
}
