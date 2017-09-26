namespace Alpha.Results.Site.Models.HandHistory
{
    public class HandHistoryModel
    {
        public HandHistoryModel(
            string iframe,
            bool isSuccess,
            string resultMessage)
        {
            Iframe = iframe;
            IsSuccess = isSuccess;
            ResultMessage = resultMessage;
        }

        public string Iframe { get; }

        public bool IsSuccess { get; }

        public string ResultMessage { get; }
    }
}
