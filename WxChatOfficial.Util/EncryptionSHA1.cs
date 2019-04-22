using System.Web.Security;

namespace WxChatOfficial.Util
{

    /// <summary>
    /// SHA1
    /// 单向加密
    /// </summary>
    public class EncryptionSha1
    {
        /// <summary>
        /// 获得一个字符串的加密密文

        /// 此密文为单向加密，即不可逆(解密)密文
        /// </summary>
        /// <param name="plainText">待加密明文</param>
        /// <returns>已加密密文</returns>
        public static string EncryptString(string plainText)
        {
            return EncryptStringSha1(plainText);
        }
        /// <summary>
        /// 获得一个字符串的加密密文

        /// 此密文为单向加密，即不可逆(解密)密文
        /// </summary>
        /// <param name="plainText">待加密明文</param>
        /// <returns>已加密密文</returns>
        public static string EncryptStringSha1(string plainText)
        {
            string encryptText = "";
            if (string.IsNullOrEmpty(plainText)) return encryptText;
            //该方法已过时,以后再找代替方法
            encryptText = FormsAuthentication.HashPasswordForStoringInConfigFile(plainText, "SHA1");
            return encryptText;
        }
        /// <summary>
        /// 判断明文与密文是否相符

        /// </summary>
        /// <param name="plainText">待检查的明文</param>
        /// <param name="encryptText">待检查的密文</param>
        /// <returns>bool</returns>
        public static bool EqualEncryptString(string plainText, string encryptText)
        {
            return EqualEncryptStringSha1(plainText, encryptText);
        }
        /// <summary>
        /// 判断明文与密文是否相符

        /// </summary>
        /// <param name="plainText">待检查的明文</param>
        /// <param name="encryptText">待检查的密文</param>
        /// <returns>bool</returns>
        public static bool EqualEncryptStringSha1(string plainText, string encryptText)
        {
            if (string.IsNullOrEmpty(plainText) || string.IsNullOrEmpty(encryptText))
            {
                return false;
            }
            var result = EncryptStringSha1(plainText).Equals(encryptText);
            return result;
        }
    }

}
