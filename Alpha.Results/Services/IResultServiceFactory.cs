namespace Alpha.Results.Services
{
    public interface IResultServiceFactory
    {
        IProductResultService CreateProductResultService(int sportId, int betTypeId);
    }
}