using AlphaPlus.User.Models;
using System.Web.Mvc;

namespace Alpha.Results.Site.Helpers
{
    public static class DarkModeHelper
    {
        public static string GetDarkModeName()
            => UserSession.Current.DarkModeName;

        public static bool IsDarkMode()
            => !string.IsNullOrWhiteSpace(GetDarkModeName());
    }
}