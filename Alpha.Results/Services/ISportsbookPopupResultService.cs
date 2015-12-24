namespace Alpha.Results.Services.Result
{
    using Alpha.Results.Models;

    /// <summary>
    /// The interface ISportsBookPopupResultService.
    /// </summary>
    public interface ISportsbookPopupResultService
    {
        string GetResult(ResultRequest resultRequest);
    }
}