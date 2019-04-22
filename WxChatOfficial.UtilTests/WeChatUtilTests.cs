using Microsoft.VisualStudio.TestTools.UnitTesting;
using WxChatOfficial.Util;

namespace WxChatOfficial.UtilTests
{
    [TestClass()]
    public class WeChatUtilTests
    {
        [TestMethod()]
        public void GetSignatureTest()
        {
            WeChatUtil.GetSignature("1", "2", "3");
        }
    }
}