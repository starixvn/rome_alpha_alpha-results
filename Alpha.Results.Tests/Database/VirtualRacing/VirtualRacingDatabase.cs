namespace Alpha.Results.Site.Tests.Database.SportsBook
{
    using System.Data;
    using Helpers;

    public static class VirtualRacingDatabase
    {
        private static DataSet _data = FileHelper.LoadDataSet(@"\Database\VirtualRacing\ResultData.xml");

        public static DataSet SportsBookResultData => _data;

        public static DataSet SportsBookResultDetailData 
            => FileHelper.LoadDataSet(@"\Database\VirtualRacing\ResultDetailData.xml");

    }
}
