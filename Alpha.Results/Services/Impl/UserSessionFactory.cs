namespace Alpha.Results.Site.Services.Impl
{
    using Sunplus.Agent.Model.Entities;

    public static class UserSessionFactory
    {
        private static IUserSession _userSession;

        public static IUserSession CurrentSession
        {
            get
            {
                if (_userSession == null)
                {
                    _userSession = UserSession.Current;
                }

                return _userSession;
            }
        }
    }
}