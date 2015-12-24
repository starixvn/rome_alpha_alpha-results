namespace Alpha.Results.Models
{
    public class Result
    {
        public Result()
        {
            ErrorCode = 0;
            ErrorMessage = "Successfull";
        }

        public Result(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }
    }
}