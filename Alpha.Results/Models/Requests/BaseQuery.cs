
namespace Alpha.Results.Site.Models.Requests
{
    using System;
    using Sunplus.Agent.Model.Entities;

    public class BaseQuery
    {
        public BaseQuery(IUserSession userSession)
        {
            Language = userSession.Language;
            IsDarkMode = userSession.DarkModeName.Equals("-dark", StringComparison.InvariantCultureIgnoreCase);
        }

        public string Language { get; }

        public bool IsDarkMode { get; }
    }
}