namespace Alpha.Results.Services.Result
{
    /// <summary>
    /// The interface IRacingPopupResultService.
    /// </summary>
    public interface IRacingPopupResultService
    {
        string GetResult(int matchId, int raceNumber, int sportType);

        string GetResultForVirtualRacing(int matchId, int raceNumber, int sportType);
    }
}