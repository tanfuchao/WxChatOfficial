using System;
using System.Threading;

namespace WxChatOfficial.Util
{
    /// <summary>
    /// 验证码类
    /// </summary>
    public static class RandomString
    {
		/// <summary>
		/// create a random key
		/// </summary>
		private static readonly Random Random = new Random(~unchecked((int)DateTime.Now.Ticks));

        private static readonly char[] NumberList = {'1','2','3','4','5','6','7','8','9'};
        private static readonly char[] CharList = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private static readonly char[] MixedList = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' }; //remove I & O

		#region 生成随机数字
		/// <summary>
		/// 生成随机数字
		/// </summary>
		/// <param name="length">生成长度</param>
		public static string Number(int length)
        {
            return Create(length, false,NumberList);
        }

        /// <summary>
        /// 生成随机数字
        /// </summary>
        /// <param name="length">生成长度</param>
        /// <param name="sleep">是否要在生成前将当前线程阻止以避免重复</param>
        public static string Number(int length, bool sleep)
        {
            return Create(length, sleep, NumberList);
        }
		#endregion

		#region 生成随机字母与数字
		/// <summary>
		/// 生成随机字母与数字
		/// </summary>
		/// <param name="length">生成长度</param>
		public static string Mixed(int length)
        {
            return Create(length, false,MixedList);
        }

        /// <summary>
        /// 生成随机字母与数字
        /// </summary>
        /// <param name="length">生成长度</param>
        /// <param name="sleep">是否要在生成前将当前线程阻止以避免重复</param>
        public static string Mixed(int length, bool sleep)
        {
            return Create(length, sleep, MixedList);
        }
		#endregion

		#region 生成随机纯字母随机数
		/// <summary>
		/// 生成随机纯字母随机数
		/// </summary>
		/// <param name="length">生成长度</param>
		public static string Char(int length)
        {
            return Create(length, false, CharList);
        }

        /// <summary>
        /// 生成随机纯字母随机数
        /// </summary>
        /// <param name="length">生成长度</param>
        /// <param name="sleep">是否要在生成前将当前线程阻止以避免重复</param>
        public static string Char(int length, bool sleep)
        {
            return Create(length, sleep, CharList);
        }
		#endregion

		/// <summary>
		/// Create the CAPTCHA specified Length, Sleep and List.
		/// </summary>
		/// <returns>The create.</returns>
		/// <param name="length">Length.</param>
		/// <param name="sleep">If set to <c>true</c> sleep.</param>
		/// <param name="list">List create CAPTCHA based on</param>
		private static string Create(int length, bool sleep, char[] list)
		{
			if (sleep) Thread.Sleep(3);
			char[] pattern = list;
			string result = string.Empty;
			int n = pattern.Length;

			for (int i = 0; i < length; i++)
			{
				int rnd = Random.Next(0, n);
				result += pattern[rnd];
			}
			return result;
		}



    }


}