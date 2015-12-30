namespace Alpha.Results.Models.Views
{
    public class NormalResultExcelViewModel
    {
        public byte[] ExcelResults { get; set; }

        public string ExcelName
        {
            get
            {
                return "Result.xls";
            }
        }
    }
}