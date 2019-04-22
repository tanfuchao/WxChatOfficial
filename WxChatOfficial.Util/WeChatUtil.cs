using System;
using Newtonsoft.Json;
using WxChatOfficial.Util.cache;
using WxChatOfficial.Util.dto;

namespace WxChatOfficial.Util
{
    public class WeChatUtil
    {
        public static readonly string Token = "trumgu2019";
        public static readonly string AppId = "wx98ad47ad0d632f08";
        public static readonly string Appsecret = "d6d7f965d4a0974f7d1809d786cbaf7e";
        

        //获取普通accessToken的url
        private static string GetAccessTokenUrl()
        {
            string url =
                $"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={AppId}&secret={Appsecret}";
            return url;
        }

        //获取js_ticket的url
        private static string GetTicketUrl()
        {
            string url = $"https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={GetAccessToken()}&type=jsapi";
            return url;
        }

        //获取accessToken
        public static string GetAccessToken()
        {
            string accessToken;
            ICacheManager cache = new MemoryCacheManager();
            var contains = cache.Contains("access_token");
            if (contains)
            {
                accessToken = cache.GetCache<string>("access_token");
            }
            else
            {
                var result = HttpHelper.HttpGet(GetAccessTokenUrl(), "");
                var accessTokenModel = JsonConvert.DeserializeObject<AccessTokenModel>(result);
                accessToken = accessTokenModel.access_token;
                long expiresIn = accessTokenModel.expires_in;
                cache.SetCache("access_token", accessToken,TimeSpan.FromSeconds(expiresIn-60));
            }
            return accessToken;
        }

        //获取js_api_ticket
        public static string GetJsApiTicket()
        {
            string ticket;
            ICacheManager cache = new MemoryCacheManager();
            var contains = cache.Contains("js_api_ticket");
            if (contains)
            {
                ticket =cache.GetCache<string>("js_api_ticket");
            }
            else
            {
                var httpGet = HttpHelper.HttpGet(GetTicketUrl(), "");
                var jsApiTicketModel = JsonConvert.DeserializeObject<JsApiTicketModel>(httpGet);
                if (jsApiTicketModel.errcode == 0)
                {
                    ticket = jsApiTicketModel.ticket;
                    long expiresIn = jsApiTicketModel.expires_in;
                    cache.SetCache("js_api_ticket", ticket,TimeSpan.FromSeconds(expiresIn-60));
                }
                else
                {
                    ticket = null;
                }
            }

//            var httpGet = HttpHelper.HttpGet(GetTicketUrl(), "");
//            var jsApiTicketModel = JsonConvert.DeserializeObject<JsApiTicketModel>(httpGet);
//            ticket = jsApiTicketModel.errcode == 0 ? jsApiTicketModel.ticket : null;

            return ticket;
        }

        //js_sdk config中的nonceStr
        public static string GetNonceStr()
        {
            return RandomString.Mixed(8);
        }

        //js_sdk config中的timeStamp
        public static string GetTimeStamp()
        {
            return TimeHelper.ConvertDateTime(DateTime.Now);
        }

        //获取签名
        public static string GetSignature(string timestamp,string nonceStr,string url)
        {
            string str =
                $"jsapi_ticket={GetJsApiTicket()}" +
                $"&noncestr={nonceStr}" +
                $"&timestamp={timestamp}" +
                $"&url={url}";
            return EncryptionSha1.EncryptStringSha1(str).ToLower();
        }
    }
}
