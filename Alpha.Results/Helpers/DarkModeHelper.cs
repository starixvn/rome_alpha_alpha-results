namespace Alpha.Results.Site.Helpers
{
    using Sunplus.Agent.Model.Entities;
    using Web.Configurations;

    public static class DarkModeHelper
    {
        public static string GetDarkModeName()
            => AppSettings.IsOfferDarkMode ? UserSession.Current.DarkModeName : string.Empty;

        public static bool IsDarkMode()
            => AppSettings.IsOfferDarkMode && !string.IsNullOrWhiteSpace(UserSession.Current.DarkModeName);
    }
}