namespace Alpha.Results.Site.Handlers
{
    using Alpha.Results.Site.Helpers;
    using Fanex.Result.Core.VirtualGames;
    using Fanex.Result.Core.VirtualGames.Ultilities;
    using MediatR;
    using Models.Requests;

    public class VirtualGamesResultHandler :
         IRequestHandler<VirtualGamesResultQuery, string>
    {
        private readonly IVirtualGamesResult result;
        private readonly BrowserHelper browserHelper;

        public VirtualGamesResultHandler(IVirtualGamesResult result, BrowserHelper browserHelper)
        {
            this.result = result;
            this.browserHelper = browserHelper;
        }

        public string Handle(VirtualGamesResultQuery message)
            => result.GetResult(GetPlatform(), message.Language);

        private string GetPlatform()
        {
            var isMobile = browserHelper.IsMobile();
            if (isMobile)
            {
                return VirtualGamesDeviceConstants.Mobile;
            }

            var isTablet = browserHelper.IsTablet();
            return isTablet ? VirtualGamesDeviceConstants.Tablet : VirtualGamesDeviceConstants.Desktop;
        }
    }
}
