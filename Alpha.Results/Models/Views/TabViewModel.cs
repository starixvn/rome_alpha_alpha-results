namespace Alpha.Results.Site.Models.Views
{
    public class TabViewModel
    {
        private string selectedTabName;
        private bool isEnabledKenoTab;

        public TabViewModel(string selectedTabName, bool isEnabledKenoTab)
        {
            this.selectedTabName = selectedTabName;
            this.isEnabledKenoTab = isEnabledKenoTab;
        }

        public string SelectedTabName
        {
            get
            {
                return this.selectedTabName.ToLower();
            }
        }

        public bool IsEnabledKenoTab
        {
            get
            {
                return this.isEnabledKenoTab;
            }
        }
    }
}