namespace Alpha.Results.Site.Models.Views
{
    using App_GlobalResources;
    using HandHistory;

    public class HandHistoryResultViewModel
    {
        public HandHistoryResultViewModel(
            string productName,
            HandHistoryModel handHistrory)
        {
            Title = $"{productName} {Resources.Result}";
            HandHistory = handHistrory;
        }

        public string Title { get; }

        public HandHistoryModel HandHistory { get; }
    }
}
