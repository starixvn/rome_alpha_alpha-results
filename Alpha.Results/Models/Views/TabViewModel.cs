namespace Alpha.Results.Site.Models.Views
{
    using System;

    public class TabViewModel
    {
        private readonly string _selectedTabName;

        public TabViewModel(
            string selectedTabName,
            bool isEnabledKenoTab,
            bool isEnableLottery,
            bool isEnableVirtualGames,
            bool isEnableTableGames,
            bool isEnableSportsLottery,
            Func<int, string> getProductName)
        {
            _selectedTabName = selectedTabName;
            IsEnabledKenoTab = isEnabledKenoTab;            
            IsEnableLottery = isEnableLottery;
            IsEnableVirtualGames = isEnableVirtualGames;
            IsEnableTableGames = isEnableTableGames;
            IsEnableSportsLottery = isEnableSportsLottery;
            GetProductName = getProductName;
        }

        public string SelectedTabName
        {
            get
            {
                return _selectedTabName.ToLower();
            }
        }

        public bool IsEnabledKenoTab { get; set; }        

        public bool IsEnableLottery { get; }

        public bool IsEnableVirtualGames { get; }

        public bool IsEnableTableGames { get; }

        public bool IsEnableSportsLottery { get; }

        public Func<int, string> GetProductName { get; }
    }
}
