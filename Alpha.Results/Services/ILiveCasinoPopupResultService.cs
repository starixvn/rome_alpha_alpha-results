namespace Alpha.Results.Services.Result
{
    /// <summary>
    /// The interface ILiveCasinoPopupResultService.
    /// </summary>
    public interface ILiveCasinoPopupResultService
    {
        string GetResult(int matchId, int betType, string league);
    }
}