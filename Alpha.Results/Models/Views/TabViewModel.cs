namespace Alpha.Results.Site.Models.Views
{
    public class TabViewModel
    {
        private string _selectedTabName;

        public TabViewModel(string selectedTabName, bool isEnabledKenoTab, bool isEnableCockfighting)
        {
            _selectedTabName = selectedTabName;
            IsEnabledKenoTab = isEnabledKenoTab;
            IsEnableCockfighting = isEnableCockfighting;
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
    }
}