using System;
using System.Diagnostics;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json;
using WxChatOfficial.Util;

namespace WxChatOfficial.Web.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public string Validate(string signature,string timestamp,string nonce,string echostr)
        {
            //1. 将token、timestamp、nonce三个参数进行字典序排序
            string[] arr = {timestamp, nonce, WeChatUtil.Token};
            Array.Sort(arr);
            //2. 将三个参数字符串拼接成一个字符串进行sha1加密
            StringBuilder sb = new StringBuilder();
            foreach (var temp in arr)
            {
                sb.Append(temp);
            }

            string sha1 = EncryptionSha1.EncryptString(sb.ToString()).ToLower();
            if (sha1.Equals(signature))
            {
                //接入成功
                Trace.WriteLine("接入成功");
                return echostr;
            }
            //接入失败
            return null;

        }

        public ActionResult Page1()
        {
            return View();
        }

        public ActionResult Page2()
        {
            return View();
        }


        [HttpGet]
        public void GetSignature(string url,string callback)
        {
            var appid = WeChatUtil.AppId;
            var timeStamp = WeChatUtil.GetTimeStamp();
            var nonceStr = WeChatUtil.GetNonceStr();
            var signature = WeChatUtil.GetSignature(timeStamp, nonceStr, url);
            var obj = JsonConvert.SerializeObject(new {appid = appid, timeStamp = timeStamp , nonceStr = nonceStr, signature= signature });
            var jsonp = $"{callback}({obj})";
            HttpContext.Response.ContentType= "application/json";
            HttpContext.Response.Write(jsonp);
        }

        


    }
}