namespace Alpha.Results.Site.Services.Impl
{
    using System;
    using System.Net;
    using System.Web;
    using App_GlobalResources;
    using Configurations.RNGCasino;
    using Constants;
    using Fanex.Common;
    using Fanex.Logging;
    using Models.HandHistory;
    using Models.HandHistory.RNGCasino;
    using Models.Requests;
    using Newtonsoft.Json;

    public class RNGCasinoResultService : IRNGCasinoResultService
    {
        private readonly ILogger _logger;

        public RNGCasinoResultService(ILogger logger)
        {
            _logger = logger;
        }

        public HandHistoryModel GetResult(RNGCasinoResultQuery request)
        {
            var token = GetToken(request.RoleId);

            if (token == null)
            {
                return new HandHistoryModel(string.Empty, false, Resources.RNGCasinoAPI_FailedToConnect);
            }

            if (!string.Equals(token.Result.ErrorCode, "0"))
            {
                return new HandHistoryModel(string.Empty, false, token.Result.ErrorDescription);
            }

            var parameters = GetHandHistoryParameters(token.Result.Token, request.RefNo, request.Language);
            var iframe = string.Format(RNGCasinoSection.Instance.HandHistoryAPI, parameters);

            return new HandHistoryModel(iframe, true, string.Empty);
        }

        private TokenResponse GetToken(int roleId)
        {
            try
            {
                var rngCasinoSection = RNGCasinoSection.Instance;
                var siteId = GetSiteId(roleId);
                var getTokenAPI = string.Format(rngCasinoSection.TokenAPI);

                var requestInfo = new Request
                {
                    Timestamp = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff"),
                    Auth = new Auth
                    {
                        Login = "Login",
                        Password = rngCasinoSection.Configurations["PassToGetToken"].Value,
                        SiteId = siteId
                    },
                    Call = new Call
                    {
                        Seq = rngCasinoSection.Seq,
                        VendorId = Converter.ToInt(rngCasinoSection.VendorId)
                    }
                };

                var responseString = CallHttpPost(JsonConvert.SerializeObject(requestInfo), getTokenAPI);
                var result = JsonConvert.DeserializeObject<TokenResponse>(responseString);

                return result;
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message, exception.InnerException);
            }

            return null;
        }

        private string CallHttpPost(string parameters, string url)
        {
            var responseString = string.Empty;

            using (WebClient webClient = new WebClient())
            {
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                responseString = webClient.UploadString(url, parameters);
            }

            return responseString;
        }

        private string GetHandHistoryParameters(string token, string refno, string language)
        {
            var encryptedKey = RNGCasinoSection.Instance.EncryptedKey;
            var param = string.Format(
                RNGCasinoSection.Instance.Parameters,
                token,
                refno,
                GetLanguage(language));
            var result = HttpUtility.UrlEncode(IBCCrypt.IBCCrypt.Encrypt(param, encryptedKey));

            return result;
        }

        private string GetLanguage(string lang)
        {
            switch (lang)
            {
                case "en-US":
                    return "en";
                case "zh-TW":
                    // Traditional
                    return "ch";
                case "zh-CN":
                    // Simplified
                    return "cs";
                case "ja-JP":
                    return "jp";
                case "ko-KR":
                    return "ko";
                case "vi-VN":
                    return "vi";
                case "th-TH":
                    // Thai
                    return "th";
                default:
                    return "en";
            }
        }

        private int GetSiteId(int roleId)
        {
            var siteIds = RNGCasinoSection.Instance.SiteId.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            var index = roleId.Equals(RoleIdConstants.Agent) ? 2
                    : roleId.Equals(RoleIdConstants.Master) ? 1 : 0;

            return Converter.ToInt(siteIds[index]);
        }
    }
}
