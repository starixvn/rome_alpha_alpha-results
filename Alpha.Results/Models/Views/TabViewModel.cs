namespace Alpha.Results.Site.Models.Views
{
    public class TabViewModel
    {
        private readonly string _selectedTabName;

        public TabViewModel(
            string selectedTabName,
            bool isEnabledKenoTab,
            bool isEnableCockfighting,
            bool isEnableNG2,
            bool isEnableLottery)
        {
            _selectedTabName = selectedTabName;
            IsEnabledKenoTab = isEnabledKenoTab;
            IsEnableCockfighting = isEnableCockfighting;
            IsEnableNG2 = isEnableNG2;
            IsEnableLottery = isEnableLottery;
        }

        public string SelectedTabName
        {
            get
            {
                return _selectedTabName.ToLower();
            }
        }

        public bool IsEnabledKenoTab { get; set; }

        public bool IsEnableCockfighting { get; set; }

        public bool IsEnableNG2 { get; }

        public bool IsEnableLottery { get; }
    }
}
