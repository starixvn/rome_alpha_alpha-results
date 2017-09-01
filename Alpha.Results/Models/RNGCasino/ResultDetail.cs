namespace Alpha.Results.Site.Models.RNGCasino
{
    public class ResultDetail
    {
        public ResultDetail()
        {
            ResultCode = 0;
            ResultMessage = string.Empty;
        }

        public int ResultCode { get; set; }

        public string ResultMessage { get; set; }
    }
}
