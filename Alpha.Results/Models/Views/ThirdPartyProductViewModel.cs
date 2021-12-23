namespace Alpha.Results.Site.Models.Views
{
    public class ThirdPartyProductViewModel
    {
        public ThirdPartyProductViewModel(string title, string result, bool isSuccess = true)
        {
            Title = title;
            Result = result;
            IsSuccess = isSuccess;
        }

        public string Title { get; }
        public string Result { get; }
        public bool IsSuccess { get; }
    }
}