namespace Alpha.Results.Models.Views
{
    public class OutrightResultExcelViewModel
    {
        public byte[] ExcelResults { get; set; }

        public string ExcelName
        {
            get
            {
                return "OutrightResults.xls";
            }
        }
    }
}