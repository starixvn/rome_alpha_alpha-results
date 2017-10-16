namespace Alpha.Results.Site.Models.Requests
{
    using System.Collections.Generic;
    using MediatR;
    using Views;

    public class ExcelNormalResultQuery : NormalResultQuery, IRequest<NormalResultExcelViewModel>
    {
        public ExcelNormalResultQuery()
        {
        }

        internal ExcelNormalResultQuery(
            IDictionary<int, bool> sportStatus,
            bool disableHorseRacingWin,
            string language)
            : base(sportStatus, disableHorseRacingWin, language)
        {
        }

        public string ExcelTitle { get; set; }

        public string TemplatePath { get; set; }
    }
}
