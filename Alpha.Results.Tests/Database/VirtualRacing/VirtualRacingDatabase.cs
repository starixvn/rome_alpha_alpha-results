namespace Alpha.Results.Site.Tests.Database.VirtualRacing
{
    using System.Data;
    using Helpers;

    public static class VirtualRacingDatabase
    {
        private static DataSet virtualRacingResultData = FileHelper.LoadDataSet(@"\Database\VirtualRacing\VirtualRacingResult.xml");

        public static DataSet VirtualRacingResultData => virtualRacingResultData;
    }
}
