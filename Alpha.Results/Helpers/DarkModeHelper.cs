using AlphaPlus.User.Models;
using System.Web.Mvc;

namespace Alpha.Results.Site.Helpers
{
    public class DarkModeHelper
    {
        private readonly IUserSession userSession;

        public DarkModeHelper(IUserSession userSession)
        {
            this.userSession = userSession;
        }

        public string GetDarkModeName()
            => userSession.DarkModeName;

        public bool IsDarkMode()
            => !string.IsNullOrWhiteSpace(userSession.DarkModeName);
    }
}