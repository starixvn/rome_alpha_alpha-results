namespace Alpha.Results.Site.Services
{
    public interface ICacheRefService
    {
        string GetSportName(int sportTypeId);

        string GetBetTypeName(int betTypeId);

        string GetLeagueName(int leagueId);

        string GetLeague3rdName(int league3rdId);

        string GetProductName(int productId);
    }
}